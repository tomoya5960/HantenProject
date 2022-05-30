using UnityEngine;
using UnityEngine.UI;

public class EdiotTileData : MonoBehaviour
{
    #region タイルデータの中身
    private      Image 　　 image;              　  //現在のイメージIDが格納される
    [SerializeField]
    private int             _imageID        = 0;
    public  bool            isTurnOver      = true;    //タイルの反転可能かの有無
    private bool            isEnableRope    = false;   //このタイルにロープが落ちているか
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

    public bool _isEnableRope
    {
        get { return isEnableRope; }
        set
        {
            isEnableRope = value;
            //子オブジェクトがある（ロープオブジェクトがある）場合のみ処理
            if (_child != null)
            {
                if (isEnableRope && _imageID == 2)   //ロープがあって、ロープの表示がオフ担っていたら表示する
                    _child.SetActive(true);

                else
                    _child.SetActive(false);
            }
            else
            {
                if (isEnableRope && _imageID == 2)
                    SearchSetRope();
                else
                    isEnableRope = false;
            }
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
        GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)imageID;
        string _name = GeneralManager.Instance.mapType.imageName.ToString();
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
}
