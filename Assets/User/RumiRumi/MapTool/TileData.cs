using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _arrayPos;   //タイルの配列座標
    public bool _isTurnOver;    //タイルの反転可能かの有無
    [SerializeField]
    public bool isRope;     //ロープの有無

    [SerializeField]
    private int imageID;
    private int _objectCount;
    private GameObject child;   //子オブジェクトの格納
    public int _imageID
    {
        get { return imageID; }
        set
        {
            imageID = value;
            SearchSetSprite(imageID);
        }
    }  //現在のイメージID

    private Image image;

    public bool _isRope
    {
        get { return isRope; }
        set
        {
            isRope = value;
            //子オブジェクトがある（ロープオブジェクトがある）場合のみ処理
            if (child != null)
            {
                if (isRope && (_imageID == 1 || _imageID == 2 || _imageID == 3))   //ロープがあって、ロープの表示がオフ担っていたら表示する
                {
                    child.SetActive(true);
                }
                else
                {
                    child.SetActive(false);
                }
            }
            else
            {
                if (_objectCount == 0 && isRope && (_imageID == 1 || _imageID == 2 || _imageID == 3))
                {
                    SearchSetRope();
                }
                else
                {
                    isRope = false;
                }
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
        _objectCount = transform.childCount;
        if(_objectCount == 0 && isRope)
        {
            SearchSetRope();
        }
        else if (_objectCount != 0)
            child = transform.GetChild(0).gameObject;
        else
            child =  null;
    }

    /// <summary>画像の検索と差し替え</summary>
    public void SearchSetSprite(int imageID)
    {
        string _name = GameManager.instance.dictionary.ImageName(imageID); //辞書から画像名を検索
        Sprite sprite = Resources.Load<Sprite>("Textures/" + _name) as Sprite;    //辞書から受け取った名前をもとにファイルを検索
        image.sprite = sprite;  //画像を差し替える
    }
    public void SearchSetRope()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Rope");
        GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
        child = prefab;
    }
}
