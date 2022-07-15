using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region�@�X�e�[�W�ŕK�{�ȕ�
    [Header("�X�e�[�W�i���o�[")]
    public int selectStageNum = 0;  //�X�e�[�W�ԍ����i�[
    [HideInInspector]
    public GameObject HantenUI;
    private int _stageTurnCount = 0;    //���]�ł���c��̉�
    [HideInInspector]
    public int stageTurnCount
    {
        get { return _stageTurnCount; }
        set
        {
            _stageTurnCount = value;
            if(HantenUI != null)
            HantenUI.GetComponent<HantensuuUI>().hantensuu = _stageTurnCount;
        }
    }
    
    [HideInInspector]
    public �@�@Vector2          PlayerPos = Vector2.zero;
    [HideInInspector]
    public �@�@Vector2          GoalPos = Vector2.zero;
    [HideInInspector]
    public �@  GameObject _jsonDatas;      //_loadOnlyJson�擾���邽�߂Ɏg����[��
    [Header("�o�߂����^�[����")]
    public int                        TurnNum = 0; //�o�߂����^�[����
    public GameObject[,] test = new GameObject[7,8];
    #endregion

    #region MAP�ɕK�v�ȕ�

    #region �}�b�v�̓񎟌��z��
    [HideInInspector]
    public MapPosition[] mapPosX = new MapPosition[7];
    [System.Serializable]
    public class MapPosition
    {
        public GameObject[] mapPosY = new GameObject[8];
    }
    #endregion

    #region �A�C�e���̓񎟌��z��
    [HideInInspector]
    public ItemPosition[] itemPosX = new ItemPosition[7];
    [System.Serializable]
    public class ItemPosition
    {
        public GameObject[] itemPosY = new GameObject[8];
    }
    #endregion

    #region �Z�[�u�Ɋւ��镨
    [HideInInspector]
    public List<Vector2> _playerVecList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> _playerPosList = new List<Vector2>();
    [HideInInspector]
    public List<int> _playerRoteSpriteNumList = new List<int>();
    [HideInInspector]
    public List<bool> _isplayerRopeList = new List<bool>();
    [HideInInspector]
    public List<int> _stageTurnContList = new List<int>();
    [HideInInspector]
    public List<string> stageData = new List<string>();
    [HideInInspector]
    public PlayerManager player;
    #endregion

    #endregion

    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    public bool Move(int vecTest)
    {
        var isMove = false;
        switch(vecTest)
        {
            case 0: //��
                if (mapPosX[(int)PlayerPos.x - 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x - 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    isMove =  true;
                break;
            case 1: //��
                if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
            case 2: //��
                if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
            case 3: //�E
                if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
        }
        player.GetComponent<PlayerManager>().characterAnimationControl.SetActionMode(true);
        return isMove;
    }

    /// <summary>
    /// �v���C���[�̉����X�����ǂ����`�F�b�N����֐�
    /// </summary>
    public bool IsIceFloor(int direction)
    {
        var isMove = false;
        if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().imageID == (int)MapType.ImageIdType.aisle_03)
        {
            switch (direction)
            {
                case 0://��
                    if(mapPosX[(int)PlayerPos.x - 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    } 
                    break;
                case 1://��
                    if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    }
                    break;
                case 2://��
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableProceed)
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    }
                    break;
                case 3://�E
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableProceed)
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    }
                    break;
            }
        }

        return isMove;
    }

    /// <summary>
    /// �v���C���[�̈ړ���Ɏ����Ƃ��Ȃ��ꏊ�̃^�C���ɉ��炩�̕��������Ă��邩
    /// </summary>
    public bool isUnderRope()
    {
        if (itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject != null)
        {
            if (itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject.tag == "Rope")
            {
                itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject.transform.parent.GetComponent<TileData>().isActiveself = false;
                itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject.SetActive(false);
                Debug.Log($"<color=green>���[�v�����܂���</color>");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// �N���A���������肷���B
    /// </summary>
    public void IsCheckClear()
    {
        if (PlayerPos == GoalPos)
        {
            Debug.Log("�S�[��������");
            GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_09);
            var color = GameFade.instance.m_image.color;
            color.a = 255;
            GameFade.instance.m_image.color = color;
            GameFade.instance.FadeOut(1);
        }
    }

    /// <summary>
    /// ���̃X�e�[�W�ł̔��]���g�p�����ۂɎg���֐�
    /// </summary>
    public void StageTurnNum()
    {
        if (stageTurnCount != 0) //���]�񐔂��c���Ă�����c��̎g�p�񐔂����炷
        {
            stageTurnCount--;
            Debug.Log("���]���܂����B");
        }
        else
            Debug.Log("���]�ł��܂���");
    }

    /// <summary>
    /// tileDataList�̃I�u�W�F�N�g��񎟌��z��ɍĐ��񂷂�֐�
    /// </summary>
    public void SetTileArray()
    {
        if (GameObject.Find("LoadData"))
            _jsonDatas = GameObject.Find("LoadData");
        var datas = _jsonDatas.GetComponent<LoadOnlyJson>();
        var TileNum = 0;
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                mapPosX[i].mapPosY[j] = datas.tileDataList[TileNum];
                mapPosX[i].mapPosY[j].GetComponent<TileData>().tilePos = new Vector2(i, j);
                TileNum++;
            }
        }
    }

    /// <summary>
    /// 1�O�ɖ߂�/�Z�[�u���鏈��
    /// </summary>
    public void TurnObjectSetList()
    {
        if (TurnNum < 0)
            return;
        else
        {
            TurnNum++;
            SetList();
        }
    }
    public void SetBeforeStageData()
    {
        if (TurnNum < 0)
            return;
        else
        {
            if(PlayerPos == _playerPosList[TurnNum -1])
            {
                return;
            }
            else
            {
                TurnNum++;
                SetList();
            }
        }
    }
    public void SetList()
    {
        if (TurnNum < _playerVecList.Count)
        {
            for (int num = _playerVecList.Count; num >= TurnNum; num--)
            {
                _playerVecList.Remove(_playerVecList[num - 1]);
                _playerPosList.Remove(_playerPosList[num - 1]);
                _isplayerRopeList.Remove(_isplayerRopeList[num - 1]);
                stageData.Remove(stageData[num - 1]);
                _stageTurnContList.Remove(_stageTurnContList[num - 1]);
            }
        }
        _jsonDatas.GetComponent<StageSave>().SaveTile();
        _playerVecList.Add(player.nowPos);
        _playerPosList.Add(PlayerPos);
        _isplayerRopeList.Add(player.isHaveRope);
        _playerRoteSpriteNumList.Add((int)player.GetComponent<Player>().dic);
        _stageTurnContList.Add(stageTurnCount);
    }
    public void LoadBeforeStageData()
    {
        if (TurnNum <= 1)
            return;
        else
        {
            TurnNum--;
            var roadTurnData = TurnNum - 1;
            _jsonDatas.GetComponent<StageSave>().OnLoad();
            player.nowPos = _playerVecList[roadTurnData];
            player.transform.localPosition = _playerVecList[roadTurnData];
            PlayerPos = _playerPosList[roadTurnData];
            player.isHaveRope = _isplayerRopeList[roadTurnData];
            player.playerPos = _playerPosList[roadTurnData];
            player.GetComponent<Player>().ChangePlayerSprite((Player.direction)_playerRoteSpriteNumList[roadTurnData]);
            stageTurnCount = _stageTurnContList[TurnNum];
        }
    }
    public void OnOneBack()
    {
        LoadBeforeStageData();
    }
}