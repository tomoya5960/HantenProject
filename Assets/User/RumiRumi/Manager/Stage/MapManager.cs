using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region�@�X�e�[�W�ŕK�{�ȕ�
    [Header("�X�e�[�W�i���o�[")]
    public int                       selectStageNum = 0;  //�X�e�[�W�ԍ����i�[
    [Header("���]�\��")]
    public int                       stageTurnCount = 0;  //���]�ł���c��̉�
    [HideInInspector]
    public �@�@Vector2          PlayerPos = Vector2.zero;
    [HideInInspector]
    public �@�@Vector2          GoalPos = Vector2.zero;
    private �@  GameObject _jsonDatas;      //_loadOnlyJson�擾���邽�߂Ɏg����[��
    [Header("�o�߂����^�[����")]
    public int                        TurnNum = 0; //�o�߂����^�[����
    public GameObject[,] test = new GameObject[7,8];
    #endregion

    #region MAP�ɕK�v�ȕ�

    #region �}�b�v�̓񎟌��z��
    public MapPosition[] mapPosX = new MapPosition[7];
    [System.Serializable]
    public class MapPosition
    {
        public GameObject[] mapPosY = new GameObject[8];
    }
    #endregion

    #region �A�C�e���̓񎟌��z��
    public ItemPosition[] itemPosX = new ItemPosition[7];
    [System.Serializable]
    public class ItemPosition
    {
        public GameObject[] itemPosY = new GameObject[8];
    }
    #endregion

    private List<Vector2> playerVecList = new List<Vector2>();
    private List<Vector2> playerPosList = new List<Vector2>();
    private List<bool> isplayerRopeList = new List<bool>();
    //[HideInInspector]
    public List<string> stageData = new List<string>();
    [HideInInspector]
    public PlayerManager player;
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
                        isMove = true;
                    break;
                case 1://��
                    if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                        isMove = true;
                    break;
                case 2://��
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableProceed)
                        isMove = true;
                    break;
                case 3://�E
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableProceed)
                        isMove = true;
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
                itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject.transform.parent.GetComponent<TileData>().isactiveself = false;
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
            SceneManager.LoadScene("Result");
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
    /// 1�O�ɖ߂鏈��
    /// </summary>
    public void SetBeforeStageData()
    {
        if (TurnNum < 0)
            return;
        else
        {
            TurnNum++;
            if (TurnNum < playerVecList.Count)
            {
                for (int num = playerVecList.Count; num >= TurnNum; num--)
                {
                    playerVecList.Remove(playerVecList[num-1]);
                    playerPosList.Remove(playerPosList[num-1]);
                    isplayerRopeList.Remove(isplayerRopeList[num - 1]);
                    stageData.Remove(stageData[num - 1]);
                }
            }
            _jsonDatas.GetComponent<StageSave>().SaveTile();
            playerVecList.Add(player.nowPos);
            playerPosList.Add(PlayerPos);
            isplayerRopeList.Add(player.isHaveRope);
            
        }
    }
    public void LoadBeforeStageData()
    {
        if (TurnNum <= 1)
            return;
        else
        {
            TurnNum--;
            _jsonDatas.GetComponent<StageSave>().OnLoad();
            player.nowPos = playerVecList[TurnNum-1];
            player.transform.localPosition = playerVecList[TurnNum - 1];
            PlayerPos = playerPosList[TurnNum-1];
            player.isHaveRope = isplayerRopeList[TurnNum - 1];
            player.playerPos = playerPosList[TurnNum-1];
        }
    }
}