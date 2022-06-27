using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    #region タイルデータ関連
    private EdiotTileData _sample_tile_data;                //見本のタイルデータ
    private EdiotTileData _mapTileData;                     //入れ替えるマップタイルデータ（格納用）
    private GameObject _clickedGameObject,_childObject;     //選択したタイルと強調表示（選択中に表示されるオブジェクト）
    private Image _image;
    #endregion

    #region 実際の操作関連
    private bool            _isChangeTile =false;   //右側のタイルを変更中に左側を選択できないようにするやつ
    private      GameObject _rope;                  //ロープのプレハブを格納
    private      GameObject _stone;
    private      GameObject _player;
    [SerializeField]
    public       GameObject beforePlayer;          //ひとつ前に置いたプレイヤーの親を格納
    [HideInInspector]
    public bool             isRope = false;         //タイルの上にロープを置くか選択してね
    [HideInInspector]
    public bool             isStone = false;         //タイルの上に岩を置くか選択してね
    [HideInInspector]
    public bool             isPlayer = false;        //プレイヤーを配置するか選択してね
    #endregion

    private void Awake()
    {
        _rope = (GameObject)Resources.Load("Prefabs/Rope");
        _stone = (GameObject)Resources.Load("Prefabs/Stone");
        _player = (GameObject)Resources.Load("Prefabs/Player");
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))     //クリックした場所に選択するタイルがあるか
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D Hit2d = Physics2D.Raycast((Vector2)Ray.origin, (Vector2)Ray.direction);

            if (Hit2d)
            {
                if (Hit2d.transform.gameObject.tag == "TileData")
                {
                    if (_childObject != null)
                    {
                        _childObject.SetActive(false);   //ほかの選択状態の子オブジェクトがある場合はfalseにする
                        _childObject = null;
                    }
                    if (!_isChangeTile)
                    {
                        _clickedGameObject = Hit2d.transform.gameObject; //タイルを格納
                        _childObject = _clickedGameObject.transform.GetChild(0).gameObject;   //子オブジェクト（選択しているタイルを強調表示するためのオブジェクト）を格納
                        _childObject.SetActive(true);    //強調表示する
                        _sample_tile_data = _clickedGameObject.GetComponent<EdiotTileData>();   //タイルデータを読み込み
                    }
                }

                if (Hit2d.transform.gameObject.tag == "MapTile" && _clickedGameObject != null)
                {
                    if (Hit2d.transform.gameObject.GetComponent<EdiotTileData>().isEnableRope == true)
                    {
                        if (!_isChangeTile)
                        {
                            SetData(Hit2d.transform.gameObject);  //置き換え
                            CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                            CheckStone(Hit2d.transform.gameObject);
                            CheckPlayer(Hit2d.transform.gameObject);
                            _isChangeTile = true;    //タイルを選択し、塗り始めている場合は他のタイルを選択できなくする
                        }
                        else
                        {
                            SetData(Hit2d.transform.gameObject);  //置き換え
                            CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                            CheckStone(Hit2d.transform.gameObject);
                            CheckPlayer(Hit2d.transform.gameObject);
                        }
                    }

                    if (!_isChangeTile)
                    {
                        SetData(Hit2d.transform.gameObject);  //置き換え
                        CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                        CheckStone(Hit2d.transform.gameObject);
                        CheckPlayer(Hit2d.transform.gameObject);
                        _isChangeTile = true;    //タイルを選択し、塗り始めている場合は他のタイルを選択できなくする
                    }
                    else
                    {
                        _image = Hit2d.transform.gameObject.GetComponent<Image>();
                        SetData(Hit2d.transform.gameObject);  //置き換え
                        CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                        CheckStone(Hit2d.transform.gameObject);
                        CheckPlayer(Hit2d.transform.gameObject);
                    }
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (_isChangeTile)
                _isChangeTile = false;   //他のタイルを選択できなくする状態を解除
        }

        if (Input.GetMouseButtonDown(1))    //選択をすべて解除
        {
            
            _clickedGameObject = null;   
            RisetData();
        }
    }

    /// <summary> 
    /// データの置き換え 
    /// </summary>
    private void SetData(GameObject _hit2d)
    {
        _mapTileData = _hit2d.GetComponent<EdiotTileData>();
        _mapTileData.imageID = _sample_tile_data.imageID;
        if (_mapTileData.imageID == 2 || _mapTileData.imageID == 5|| _mapTileData.imageID == 3)
            _mapTileData.isTurnOver = _sample_tile_data.isTurnOver;
      
        _mapTileData.isEnableProceed = _sample_tile_data.isEnableProceed;
        if (isRope && _mapTileData.imageID == 2)
            _mapTileData.isEnableRope = isRope;
        else if (!isRope)
            _mapTileData.isEnableRope = false;
        if (isStone && (_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
            _mapTileData.isEnableStone = isStone;
            _mapTileData.isEnableProceed = false;   //岩がある場合は通れないようにする
        }
        else if (!isStone)
            _mapTileData.isEnableStone = false;
        if (isPlayer && (_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
            _mapTileData.isEnablePlayer = isPlayer;
            if (beforePlayer != null && beforePlayer != _hit2d && beforePlayer.transform.childCount > 0)
            {
                beforePlayer.GetComponent<EdiotTileData>().isEnablePlayer = false;
                Destroy(beforePlayer.transform.GetChild(0).gameObject);
                beforePlayer = null;
            }
            else
                beforePlayer = _hit2d;
        }
        else if (!isPlayer)
            _mapTileData.isEnablePlayer = false;
    }

    /// <summary> データのリセット </summary>
    private void RisetData()
    {
        _childObject.SetActive(false);
        _childObject = null;
        _sample_tile_data = null;
        _mapTileData = null;
    }

    /// <summary>
    /// ロープを子に生成
    /// </summary>
    /// <param name="_hit2d"></param>
    private void CheckRope(GameObject _hit2d)
    {

        if (isRope && _hit2d.gameObject.transform.childCount == 0 &&_mapTileData.imageID == 2)
        {
            for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Stone")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Player")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
        }
        else if (!isRope|| _mapTileData.imageID != 2)
        {
            for(int num = 0;num < _hit2d.transform.childCount;num++)
            {
                if(_hit2d.transform.GetChild(num).gameObject.tag == "Rope")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
        }
    }

    /// <summary>
    /// 岩を子に生成
    /// </summary>
    /// <param name="_hit2d"></param>
    private void CheckStone(GameObject _hit2d)
    {
        if (isStone && _hit2d.gameObject.transform.childCount == 0 && (_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
             for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Rope")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Player")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);

            }
        }
        else if (!isStone || !(_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
            for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Stone")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
        }
    }

    /// <summary>
    /// プレイヤーを子に生成
    /// </summary>
    /// <param name="_hit2d"></param>
    private void CheckPlayer(GameObject _hit2d)
    {
        if (isPlayer && _hit2d.gameObject.transform.childCount == 0 && (_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
            for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Rope")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Stone")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }

        }
        else if (!isPlayer || !(_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
            for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Player")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
        }
    }
}
