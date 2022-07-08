using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMaster : MonoBehaviour
{
    [HideInInspector]
    public enum TurnFaceType   //���݂̃^�C���̏�ԁi�\���j
    {
        Front = 0,
        Back,
        Goal
    }

    public      List<Sprite> spriteLists  = new List<Sprite>();    //�^�C���̃C���[�W�摜�i�\���j
    [HideInInspector]
    public      Image        mapImage     = null;
    private      TileData     _tileData;                              //�����̃^�C���f�[�^���i�[
    //[HideInInspector]
    public      TurnFaceType _turnFaceType = TurnFaceType.Front;    //�������ꂽ�Ƃ��ɕ\�̏�Ԃɂ����
    [HideInInspector]
    public bool         _isEnableTurn = true;                  //���݂̃^�C�������Ԃ��邩�itrue�͗��Ԃ���j
    public  bool              isEnableTurn  => _isEnableTurn;        //�ǂݎ���p

    #region �^�C���̃X�v���C�g�����n�֐�
    private        Sprite First  = null;
    private        Sprite Second = null;
    private        Sprite Third  = null;
    private string        _name  = "";
    private string        TileSpriteName;
    #endregion

    private void Awake()
    {
        mapImage = GetComponent<Image>();
        _tileData = GetComponent<TileData>();
    }

    private void Start()
    {
        
        SearchSetSprite(GetComponent<TileData>().imageID);
        _tileData.childCount = transform.childCount;
        if (_tileData.isEnableRope)
            SearchSetRope();
        else if(_tileData.isEnableStone)
            SearchSetStone();
        else if(_tileData.isEnablePlayer)
            SearchSetPlayer();
        else if (_tileData.childCount != 0)
            _tileData.child = transform.GetChild(0).gameObject;
        else
            _tileData.child = null;

        //�S�[���������ꍇ��MapManager��GoalPos�ɃS�[�����W���i�[
        if (_tileData.imageID == (int)MapType.ImageIdType.goal_01)
            GeneralManager.instance.mapManager.GoalPos = _tileData.tilePos;
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="first">�\�̉摜</param>
    /// <param name="second">���̉摜</param>
    public void InitSprite(Sprite first, Sprite second = null, Sprite third = null) //������ = null ������̂͂Ȃ��Ă����v�Ȃ悤�ɁI
    {
        spriteLists.Add(first);    //�\�̉摜���i�[
        if (null != second) //�\��invisible�ł͂Ȃ���������ꍇ
            spriteLists.Add(second);
        if (null != third) //�S�[��������ꍇ
            spriteLists.Add(third);
        mapImage.sprite = spriteLists[(int)TurnFaceType.Front];   //�\�̉摜���C���[�W��\��
    }

    /// <summary>
    /// ���]�������̃C���[�W�ύX
    /// </summary>
    public void TurnImage(bool rope = false)
    {
        if (spriteLists.Count < 2)
            return;
        else
        {
            if (TurnFaceType.Front == _turnFaceType && spriteLists[(int)TurnFaceType.Back].name == "goal_02" && rope) 
            {
                if (_turnFaceType != TurnFaceType.Goal)
                {
                    ChangeClearGoal();
                    GeneralManager.instance.mapManager.TurnObjectSetList();
                }
            }
            else if (_isEnableTurn)   //���]���邱�Ƃ��o����ꍇ
            {
                mapImage.sprite = spriteLists[(int)TurnFaceType.Back];    //���݂̃C���[�W�𗠂̉摜�ɂ���
                _turnFaceType = TurnFaceType.Back;  //���݂̏�Ԃ𗠂ɂ���
                _isEnableTurn = false;  //���]�ł��Ȃ�����
                ChangeImageID();
                GeneralManager.instance.mapManager.TurnObjectSetList();
            }
            else if (TurnFaceType.Back == _turnFaceType && spriteLists[(int)TurnFaceType.Front].name == "goal_01" && _turnFaceType != TurnFaceType.Goal)
            {
                mapImage.sprite = spriteLists[(int)TurnFaceType.Front];
                _turnFaceType = TurnFaceType.Front;
                _tileData.imageID = (int)MapType.ImageIdType.goal_03;
                GeneralManager.instance.mapManager.TurnObjectSetList();
            }
            else
            {
                return;
            }
        }
    }

    /// <summary>
    /// clear�����𖞂������S�[���ɕύX����֐�
    /// </summary>
    private void ChangeClearGoal()
    {
        Debug.Log("a");
        if (TurnFaceType.Front == _turnFaceType)    //�\�������ꍇ�̂ݓǂݍ��ށ@���łɃN���A�����𖞂������S�[���������ꍇ����΂Ȃ�
        {
            if (spriteLists[(int)TurnFaceType.Goal] == null) //�N���A�����𖞂������S�[�����摜���Ȃ��ꍇ
                return;
            else
            {
                mapImage.sprite = spriteLists[(int)TurnFaceType.Goal];    //���݂̃C���[�W���N���A�����𖞂������S�[���̉摜�ɂ���
                _turnFaceType = TurnFaceType.Goal;
                _tileData.isEnableProceed = true;   //�ʂ��悤�ɂ���
            }
        }
    }

    #region �^�C���̃X�v���C�g�����n�֐�
    /// <summary>
    /// ����First�X�v���C�g��������
    /// </summary>
    /// <param name="ImageID"></param>
    private void CommonFirstSpriteSearch(int ImageID)
    {
        GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)ImageID;
        string TileSpriteName = GeneralManager.instance.mapType.imageName.ToString();
        First = Resources.Load<Sprite>("Textures/" + TileSpriteName.ToString()) as Sprite;
    }

    /// <summary>
    /// ����Second�X�v���C�g��������
    /// </summary>
    /// <param name="ImageID"></param>
    private void CommonSecondSpriteSearch()
    {
        TileSpriteName = GeneralManager.instance.mapType.imageName.ToString();
        Second = Resources.Load<Sprite>("Textures/" + TileSpriteName.ToString()) as Sprite;
    }

    /// <summary>
    /// �S�[���ȊO�̃^�C���������ꍇ
    /// </summary>
    private void SetSprite(int ImageID)
    {
        CommonFirstSpriteSearch(ImageID);

        switch (ImageID)
        {
            #region ���̏ꍇ
            case 1:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.wall_02;
                CommonSecondSpriteSearch();
                break;
            case 3:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.wall_03;
                CommonSecondSpriteSearch();
                break;
            #endregion
            #region �ǂ̏ꍇ
            case 4:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.aisle_02;
                CommonSecondSpriteSearch();
                break;
            case 5:
                break;
            case 6:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.aisle_03;
                CommonSecondSpriteSearch();
                break;
            #endregion
            #region �Α��̏ꍇ
            case 12:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_11;
                CommonSecondSpriteSearch();
                break;
            case 13:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_12;
                CommonSecondSpriteSearch();
                break;
            case 14:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_13;
                CommonSecondSpriteSearch();
                break;
            case 15:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_14;
                CommonSecondSpriteSearch();
                break;
            #endregion
            #region ��ꂽ�Α��̏ꍇ
            case 16:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_01;
                CommonSecondSpriteSearch();
                break;
            case 17:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_02;
                CommonSecondSpriteSearch();
                break;
            case 18:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_03;
                CommonSecondSpriteSearch();
                break;
            case 19:
                GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.statue_04;
                CommonSecondSpriteSearch();
                break;
            #endregion
            default:    //����ȊO
                break;
        }
    }

    /// <summary>
    /// �S�[���^�C���������ꍇ
    /// </summary>
    /// <param name="imageId"></param>
    /// <returns></returns>
    private void SetGoalSprite(int ImageID)
    {
        CommonFirstSpriteSearch(ImageID);
        GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.goal_02;
        CommonSecondSpriteSearch();
        GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)MapType.ImageIdType.goal_03;
        TileSpriteName = GeneralManager.instance.mapType.imageName.ToString();
        Third = Resources.Load<Sprite>("Textures/" + TileSpriteName.ToString()) as Sprite;
    }
    #endregion
    public class IdPack
    {
        public MapType.ImageIdType ImageIdType;
        public bool IsEnableProceed;
        public IdPack(MapType.ImageIdType imageIdType, bool isEnableProceed)
        {
            ImageIdType = imageIdType;
            IsEnableProceed = isEnableProceed;
        }
    }
    private List<IdPack> _packLists = new List<IdPack>()
    {
        new IdPack(MapType.ImageIdType.invisible,false),
        new IdPack(MapType.ImageIdType.wall_02,false),
        new IdPack(MapType.ImageIdType.invisible,false),
        new IdPack(MapType.ImageIdType.wall_03,false),
        new IdPack(MapType.ImageIdType.aisle_02,true),
        new IdPack(MapType.ImageIdType.invisible,false),
        new IdPack(MapType.ImageIdType.aisle_03,true),
        new IdPack(MapType.ImageIdType.goal_02,false),
        new IdPack(MapType.ImageIdType.goal_01,false),
        new IdPack(MapType.ImageIdType.invisible,false),
        new IdPack(MapType.ImageIdType.invisible,false),
        new IdPack(MapType.ImageIdType.invisible,false),
        new IdPack(MapType.ImageIdType.statue_11,false),
        new IdPack(MapType.ImageIdType.statue_12,false),
        new IdPack(MapType.ImageIdType.statue_13,false),
        new IdPack(MapType.ImageIdType.statue_14,false),
        new IdPack(MapType.ImageIdType.statue_01,false),
        new IdPack(MapType.ImageIdType.statue_02,false),
        new IdPack(MapType.ImageIdType.statue_03,false),
        new IdPack(MapType.ImageIdType.statue_04,false),
    };
    private void ChangeImageID()
    {
        _tileData.isEnableProceed = _packLists[_tileData.imageID].IsEnableProceed;
        _tileData.imageID = (int)_packLists[_tileData.imageID].ImageIdType;
    }

    #region �������̊֐��i�Q�[�����ɂ͐G��Ȃ���j

    /// <summary>
    /// ���ʏ���������
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
    /// ���[�v���K�v�ȏꍇ�͔z�u����֐�
    /// </summary>
    public void SearchSetRope()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Rope");
        GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
        _tileData.child = prefab;
    }

    /// <summary>
    /// �₪�K�v�ȏꍇ�͔z�u����֐�
    /// </summary>
    public void SearchSetStone()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Stone");
        GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
        _tileData.child = prefab;
    }

    /// <summary>
    /// �v���C���[���K�v�ȏꍇ�͔z�u����֐�
    /// </summary>
    public void SearchSetPlayer()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Player");
        GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);

        _tileData.child = prefab;
    }

    /// <summary>
    /// �摜�̌����ƍ����ւ�
    /// </summary>
    public void SearchSetSprite(int imageID)
    {

        if (imageID == 7)                                   //�S�[����������
        {
            SetGoalSprite(imageID);
            InitSprite(First, Second, Third);
        }
        else                                                //����ȊO
        {
            SetSprite(imageID);
            InitSprite(First, Second, Third);
        }
        ResetSpriteSearch();
    }
    #endregion
}