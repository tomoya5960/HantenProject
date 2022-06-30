using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region�@�X�e�[�W�ŕK�{�ȕ�
    [Header("�X�e�[�W�i���o�[")]
    public int selectStageNum = 0;  //�X�e�[�W�ԍ����i�[
    [Header("���]�\��")]
    public int stageTurnCount = 0;  //���]�ł���c��̉�
    [HideInInspector]
    public Vector2 PlayerPos = Vector2.zero;
    [HideInInspector]
    public Vector2 GoalPos = Vector2.zero;
    private LoadOnlyJson _loadJson;      //_loadOnlyJson�擾���邽�߂Ɏg����[��
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
            _loadJson = GameObject.Find("LoadData").GetComponent<LoadOnlyJson>();

        var TileNum = 0;
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                mapPosX[i].mapPosY[j] = _loadJson.tileDataList[TileNum];
                mapPosX[i].mapPosY[j].GetComponent<TileData>().tilePos = new Vector2(i, j);
                TileNum++;
            }
        }
    }
}
