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
    [HideInInspector]
    public bool             isRope = false;         //タイルの上にロープを置くか選択してね
    #endregion

    private void Awake()
    {
        _rope = (GameObject)Resources.Load("Prefabs/Rope");
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
                    if (Hit2d.transform.gameObject.GetComponent<EdiotTileData>()._isEnableRope == true)
                    {
                        if (!_isChangeTile)
                        {
                            SetData(Hit2d.transform.gameObject);  //置き換え
                            CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                            _isChangeTile = true;    //タイルを選択し、塗り始めている場合は他のタイルを選択できなくする
                        }
                        else
                        {
                            SetData(Hit2d.transform.gameObject);  //置き換え
                            CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                        }
                    }

                    if (!_isChangeTile)
                    {
                        SetData(Hit2d.transform.gameObject);  //置き換え
                        CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                        _isChangeTile = true;    //タイルを選択し、塗り始めている場合は他のタイルを選択できなくする
                    }
                    else
                    {
                        _image = Hit2d.transform.gameObject.GetComponent<Image>();
                        SetData(Hit2d.transform.gameObject);  //置き換え
                        CheckRope(Hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
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
        _mapTileData._isEnableRope = isRope;
    }

    /// <summary> データのリセット </summary>
    private void RisetData()
    {
        _childObject.SetActive(false);
        _childObject = null;
        _sample_tile_data = null;
        _mapTileData = null;
    }

    private void CheckRope(GameObject _hit2d)
    {
        if (isRope && _hit2d.gameObject.transform.childCount == 0 &&
           _mapTileData.imageID == 2)
        {
            var SetChild = (GameObject)Instantiate(_rope, new Vector3(0, 0, 0), Quaternion.identity, _hit2d.transform);
            SetChild.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else if (!isRope && _hit2d.gameObject.transform.childCount != 0)
        {
            Destroy(_hit2d.transform.GetChild(0).gameObject);
        }
    }

}
