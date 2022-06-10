using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region�@�X�e�[�W�ŕK�{�ȕ�
    [Header("�X�e�[�W�i���o�[")]
    public int selectStageNum = 0;  //�X�e�[�W�ԍ����i�[
    [Header("���]�\��")]
    public int stageTurnCount = 0;  //���]�ł���c��̉�
    [SerializeField]
    private Vector2 PlayerPos = Vector2.zero;
    private GameObject _loadJson;      //_loadOnlyJson�擾���邽�߂Ɏg����[��
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

    #region �}�b�v�ɂ���M�~�b�N�I�u�W�F�N�g�̓񎟌��z��
    public GimmickObjectPosition[] gimmickObjectPosX = new GimmickObjectPosition[7];
    [System.Serializable]
    public class GimmickObjectPosition
    {
        public GameObject[] gimmickObjectPosY = new GameObject[8];
    }
    #endregion

    #endregion

    private void Awake()
    {
        if (GameObject.Find("LoadData"))
            _loadJson = GameObject.Find("LoadData");
    }

    private void Start()
    {
        if (_loadJson != null)
        {
            SetTileArray();
        }
    }

    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    public bool Move(int vecTest)
    {
        var isMove = false;
        switch(vecTest)
        {
            case 0: //��
                if (mapPosX[(int)PlayerPos.x - 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    isMove =  true;
                break;
            case 1: //��
                if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
            case 2: //��
                if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
            case 3: //�E
                if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
        }
        return isMove;
    }

    /// <summary>
    /// �v���C���[�̉����X�����ǂ����`�F�b�N����֐�
    /// </summary>
    public bool IsIceFloor()
    {
        var isMove = false;
        if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().imageID == (int)MapType.ImageIdType.aisle_03)
            isMove = true;
        return isMove;
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
    private void SetTileArray()
    {
        var TileNum = 0;
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                mapPosX[i].mapPosY[j] = _loadJson.GetComponent<LoadOnlyJson>().tileDataList[TileNum];
                TileNum++;
            }
        }
    }
}
