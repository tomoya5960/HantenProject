using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMaster : MonoBehaviour
{
    private enum TurnFaceType   //現在のタイルの状態（表裏）
    {
        Front = 0,
        Back,
        Goal
    }

    [SerializeField]
    private      List<Sprite> _spriteLists  = new List<Sprite>();    //タイルのイメージ画像（表裏）
    private      Image        _mapImage     = null;
    private      TileData     _tileData;                              //自分のタイルデータを格納
    private      TurnFaceType _turnFaceType = TurnFaceType.Front;    //生成されたときに表の状態にするよ
    private bool              _isEnableTurn = true;                  //現在のタイルが裏返せるか（trueは裏返せる）
    public  bool              isEnableTurn  => _isEnableTurn;        //読み取り専用

    [Header("プレイヤーの格納しているロープの仮、後で置き換えて")]
    public  bool              testRope;//testRopeをプレイヤーのロープに変更するべし
    #region タイルのスプライト生成系関数
    private        Sprite First  = null;
    private        Sprite Second = null;
    private        Sprite Third  = null;
    private string        _name  = "";
    private string        TileSpriteName;
    #endregion

    private void Awake()
    {
        _mapImage = GetComponent<Image>();
        _tileData = GetComponent<TileData>();
    }

    private void Start()
    {
        
        SearchSetSprite(GetComponent<TileData>().imageID);
        _tileData.childCount = transform.childCount;
        if (_tileData.isEnableRope)
        {
            SearchSetRope();
        }
        else if (_tileData.childCount != 0)
            _tileData.childRope = transform.GetChild(0).gameObject;
        else
            _tileData.childRope = null;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="first">表の画像</param>
    /// <param name="second">裏の画像</param>
    public void InitSprite(Sprite first, Sprite second = null, Sprite third = null) //引数に = null があるのはなくても大丈夫なように！
    {
        _spriteLists.Add(first);    //表の画像を格納
        if (null != second) //表がinvisibleではなく裏がある場合
            _spriteLists.Add(second);
        if (null != third) //ゴールがある場合
            _spriteLists.Add(third);
        _mapImage.sprite = _spriteLists[(int)TurnFaceType.Front];   //表の画像をイメージを表示
    }

    /// <summary>
    /// 反転した時のイメージ変更
    /// </summary>
    public void TurnImage()
    {
        if (_spriteLists.Count < 2)
            return;
        else
        {
            if (TurnFaceType.Front == _turnFaceType && _spriteLists[(int)TurnFaceType.Back].name == "goal_02" && _turnFaceType != TurnFaceType.Goal && testRope)    //testRopeをプレイヤーのロープに変更するべし
                ChangeClearGool();
            else if (_isEnableTurn)   //反転することが出来る場合
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Back];    //現在のイメージを裏の画像にする
                _turnFaceType = TurnFaceType.Back;  //現在の状態を裏にする
                _isEnableTurn = false;  //反転できなくする
                ChangeImageID();
            }
            else if (TurnFaceType.Back == _turnFaceType &&_spriteLists[(int)TurnFaceType.Front].name == "goal_01" && _turnFaceType != TurnFaceType.Goal)
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Front];
                _turnFaceType = TurnFaceType.Front;
                _tileData.imageID = (int)MapType.ImageIdType.goal_03;
            }
        }
    }

    /// <summary>
    /// clear条件を満たしたゴールに変更する関数
    /// </summary>
    private void ChangeClearGool()
    {
        if (TurnFaceType.Front == _turnFaceType)    //表だった場合のみ読み込む　すでにクリア条件を満たしたゴールだった場合もよばない
        {
            if (_spriteLists[(int)TurnFaceType.Goal] == null) //クリア条件を満たしたゴールが画像がない場合
                return;
            else
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Goal];    //現在のイメージをクリア条件を満たしたゴールの画像にする
                _turnFaceType = TurnFaceType.Goal;
            }
        }
    }

    #region タイルのスプライト生成系関数
    /// <summary>
    /// 共通Firstスプライト検索処理
    /// </summary>
    /// <param name="ImageID"></param>
    private void CommonFirstSpriteSearch(int ImageID)
    {
        GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)ImageID;
        string TileSpriteName = GeneralManager.Instance.mapType.imageName.ToString();
        First = Resources.Load<Sprite>("Textures/" + TileSpriteName.ToString()) as Sprite;
    }

    /// <summary>
    /// 共通Secondスプライト検索処理
    /// </summary>
    /// <param name="ImageID"></param>
    private void CommonSecondSpriteSearch()
    {
        TileSpriteName = GeneralManager.Instance.mapType.imageName.ToString();
        Second = Resources.Load<Sprite>("Textures/" + TileSpriteName.ToString()) as Sprite;
    }

    /// <summary>
    /// ゴール以外のタイルだった場合
    /// </summary>
    private void SetSprite(int ImageID)
    {
        CommonFirstSpriteSearch(ImageID);

        switch (ImageID)
        {
            #region 道の場合
            case 1:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.wall_02;
                CommonSecondSpriteSearch();
                break;
            case 3:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.wall_03;
                CommonSecondSpriteSearch();
                break;
            #endregion
            #region 壁の場合
            case 4:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.aisle_02;
                CommonSecondSpriteSearch();
                break;
            case 5:
                break;
            case 6:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.aisle_03;
                CommonSecondSpriteSearch();
                break;
            #endregion
            #region 石像の場合
            case 12:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_11;
                CommonSecondSpriteSearch();
                break;
            case 13:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_12;
                CommonSecondSpriteSearch();
                break;
            case 14:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_13;
                CommonSecondSpriteSearch();
                break;
            case 15:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_14;
                CommonSecondSpriteSearch();
                break;
            #endregion
            #region 壊れた石像の場合
            case 16:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_01;
                CommonSecondSpriteSearch();
                break;
            case 17:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_02;
                CommonSecondSpriteSearch();
                break;
            case 18:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_03;
                CommonSecondSpriteSearch();
                break;
            case 19:
                GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_04;
                CommonSecondSpriteSearch();
                break;
            #endregion
            default:    //それ以外
                break;
        }
    }

    /// <summary>
    /// ゴールタイルだった場合
    /// </summary>
    /// <param name="imageId"></param>
    /// <returns></returns>
    private void SetGoalSprite(int ImageID)
    {
        CommonFirstSpriteSearch(ImageID);
        GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.goal_02;
        CommonSecondSpriteSearch();
        GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.goal_03;
        TileSpriteName = GeneralManager.Instance.mapType.imageName.ToString();
        Third = Resources.Load<Sprite>("Textures/" + TileSpriteName.ToString()) as Sprite;
    }
    #endregion


    private void ChangeImageID()
    {
        switch (_tileData.imageID)
        {
            case 1:
                _tileData.imageID = (int)MapType.ImageIdType.wall_02;
                _tileData.isEnableProceed = false;
                break;
            case 3:
                _tileData.imageID = (int)MapType.ImageIdType.wall_03;
                _tileData.isEnableProceed = false;
                break;
            case 4:
                _tileData.imageID = (int)MapType.ImageIdType.aisle_02;
                _tileData.isEnableProceed = true;
                break;
            case 6:
                _tileData.imageID = (int)MapType.ImageIdType.aisle_03;
                _tileData.isEnableProceed = true;
                break;
            case 7:
                _tileData.imageID = (int)MapType.ImageIdType.goal_02;
                _tileData.isEnableProceed = false;
                break;
            case 8:
                _tileData.imageID = (int)MapType.ImageIdType.goal_01;
                _tileData.isEnableProceed = false;
                break;
            case 12:
                _tileData.imageID = (int)MapType.ImageIdType.statue_11;
                _tileData.isEnableProceed = false;
                break;
            case 13:
                _tileData.imageID = (int)MapType.ImageIdType.statue_12;
                _tileData.isEnableProceed = false;
                break;
            case 14:
                _tileData.imageID = (int)MapType.ImageIdType.statue_13;
                _tileData.isEnableProceed = false;
                break;
            case 15:
                _tileData.imageID = (int)MapType.ImageIdType.statue_14;
                _tileData.isEnableProceed = false;
                break;
            case 16:
                _tileData.imageID = (int)MapType.ImageIdType.statue_01;
                _tileData.isEnableProceed = false;
                break;
            case 17:
                _tileData.imageID = (int)MapType.ImageIdType.statue_02;
                _tileData.isEnableProceed = false;
                break;
            case 18:
                _tileData.imageID = (int)MapType.ImageIdType.statue_03;
                _tileData.isEnableProceed = false;
                break;
            case 19:
                _tileData.imageID = (int)MapType.ImageIdType.statue_04;
                _tileData.isEnableProceed = false;
                break;
            default:
                Debug.LogError("イメージID変更でエラーが起きてるぜ");
                break;
        }
    }

    #region 生成時の関数（ゲーム中には触らないやつ）
    /// <summary>
    /// 共通初期化処理
    /// </summary>
    private void ResetSpriteSearch()
    {
        First = null;
        Second = null;
        Third = null;
        _name = "";
        TileSpriteName = "";
    }

    /// <summary>
    /// ロープが必要な場合は配置する関数
    /// </summary>
    public void SearchSetRope()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Rope");
        GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
        _tileData.childRope = prefab;
    }

    /// <summary>
    /// 画像の検索と差し替え
    /// </summary>
    public void SearchSetSprite(int imageID)
    {

        if (imageID == 7)                                   //ゴールだったら
        {
            SetGoalSprite(imageID);
            InitSprite(First, Second, Third);
        }
        else                                                //それ以外
        {
            SetSprite(imageID);
            InitSprite(First, Second, Third);
        }
        ResetSpriteSearch();
    }
    #endregion
}
