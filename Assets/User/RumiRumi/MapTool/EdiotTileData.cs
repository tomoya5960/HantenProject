using UnityEngine;
using UnityEngine.UI;

public class EdiotTileData : MonoBehaviour
{
    #region タイルデータの中身
    private      Image 　　 image;              　  //現在のイメージIDが格納される
    [SerializeField]
    private int             _imageID        = 0;
    public  bool            isTurnOver      = true;    //タイルの反転可能かの有無
    private bool           _isEnableRope    = false;   //このタイルにロープが落ちているか
    private bool           _isEnableStone = false;
    private  int            _childCount     = 0;       //子オブジェクトのがず
    public  bool            isEnableProceed = true;        //通ることができるか
    private      GameObject _child       = null;       //子オブジェクトの格納
    #endregion

    public int imageID
    {
        get { return _imageID; }
        set
        {
            _imageID = value;
            SearchSetSprite(_imageID);
        }
    }
    public bool isEnableRope
    {
        get { return _isEnableRope; }
        set
        {
            _isEnableRope = value;
            if (_isEnableRope && _imageID == 2)
                SearchSetRope();

        }
    }
    public bool isEnableStone
    {
        get { return _isEnableStone; }
        set
        {
            _isEnableStone = value;
            if (_isEnableStone && (_imageID == 1 || _imageID == 2 || _imageID == 3))
                SearchSetStone();
        }
    }


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        _imageID = imageID;
        _childCount = transform.childCount;
        if (_childCount == 0 && isEnableRope)
        {
            SearchSetRope();
        }
        else if(_childCount == 0 && isEnableStone)
        {
            SearchSetStone();
        }
        else if (_childCount != 0)
            _child = transform.GetChild(0).gameObject;
        else
            _child = null;
    }

    /// <summary>
    /// 画像の検索と差し替え
    /// </summary>
    public void SearchSetSprite(int imageID)
    {
        GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)imageID;
        string _name = GeneralManager.instance.mapType.imageName.ToString();
        Sprite sprite = Resources.Load<Sprite>("Textures/" + _name) as Sprite;    //辞書から受け取った名前をもとにファイルを検索
        image.sprite = sprite;  //画像を差し替える
    }

    /// <summary>
    /// ロープの画像を検索し、格納する関数
    /// </summary>
    public void SearchSetRope()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Rope");
        if (prefabObj == null)
        {
            Debug.LogError($"<color=yellow>Prefabs/Rope がないよ</color>");
            return;
        }
        else
        {
            GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
            _child = prefab;
        }
    }

    public void SearchSetStone()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Stone");
        if (prefabObj == null)
        {
            Debug.LogError($"<color=yellow>Prefabs/Stone がないよ</color>");
            return;
        }
        else
        {
            GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
            _child = prefab;
        }
    }
}
