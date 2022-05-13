using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _arrayPos;   //タイルの配列座標
    public int _turnCount;
    public bool _isTurnOver;    //タイルの反転可能かの有無
    public bool _isRope;
    [SerializeField]
    private int _imageID;
    public int ImageID
    {
        get { return _imageID; }
        set {
            _imageID = value;
            SearchSetSprite(_imageID);
        } 
    }  //現在のイメージID

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        ImageID = _imageID;
    }

    /// <summary>画像の検索と差し替え</summary>
    public void SearchSetSprite(int _imageID)
    {
        string _name = GameManager.instance.dictionary.ImageName(_imageID); //辞書から画像名を検索
        Sprite sprite = Resources.Load<Sprite>("Textures/" + _name) as Sprite;    //辞書から受け取った名前をもとにファイルを検索
        image.sprite = sprite;  //画像を差し替える
    }


    /// <summary>反転できる回数が規定値に達した場合反転出来なくする処理および反転する処理</summary>
    public void HantenCheck()
    {
        //なんかそのうち追加するかも～
    }
}
