using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    #region�@�X�e�[�W�ŕK�{�ȕ�
    [Header("���]�\��")]
    public  int               stageTurnCount      = 0;  //���]�ł���c��̉�
    private string            _stageName          = ""; //JsonOnlyJson�̃X�e�[�W�����i�[����
    private        GameObject _loadJson;      //_loadOnlyJson�擾���邽�߂Ɏg����[��
    #endregion

    #region MAP�̓񎟌��z����W�̊��蓖��
    public MapPosition[] mapPosX = new MapPosition[7];
    [System.Serializable]
    public class MapPosition
    {
        public GameObject[] mapPosY = new GameObject[8];
    }
    #endregion

    private void Awake()
    {
        _loadJson = GameObject.Find("LoadData");
        _stageName = SceneManager.GetActiveScene().name;
        if (_loadJson != null)
        {
            _loadJson.GetComponent<LoadOnlyJson>().loadFileName = _stageName;
        }
        else
            _stageName = "�G�f�B�^�[�ŕҏW��";
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "MapEditorScene")
            SetTileArray();
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
        {
            Debug.Log("���]�ł��܂���");
        }
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