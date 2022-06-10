using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnlyJson : MonoBehaviour
{
    #region �^�C���f�[�^�֌W
    [HideInInspector]
    public List<GameObject>  tileDataList    = new List<GameObject>();  //�����Ƀ^�C����ۑ�
    private GameObject       parentTiles;                               //�^�C���I�u�W�F�N�g�̐e���i�[����
    private MapData          _mapData        = new MapData();           //�}�b�v�̎��Ԃ��m��
    private Vector2          mapTileMaxArray = new Vector2(8, 7);       //�}�b�v�z��̍ő��
    #endregion

    #region Json�Ǘ��֌W
    [HideInInspector]
    public  string loadFileName = "";   //�ǂݍ��ރt�@�C���̖��O
    private string _filePath    = "";   //�f�[�^�̕ۑ�����Ă���p�X
    #endregion

    private void Awake()
    {
        if (!GameObject.Find("Map"))
        {
            parentTiles = null;
            Debug.LogError($"<color=red>Map ���Ȃ���</color>");
        }
        else
        {
            parentTiles = GameObject.Find("Map");
            SetTiles(parentTiles);
        }
        loadFileName = SceneManager.GetActiveScene().name;
        OnDataLoad();
        LoadTileData();
    }

    /// <summary>
    /// ���X�g�ɃI�u�W�F�N�g���i�[����֐�
    /// </summary>
    /// <param name="Parent">�^�C���̐e�I�u�W�F�N�g</param>
    private void SetTiles(GameObject Parent)
    {
        foreach (Transform childTransform in Parent.transform)
        {
            tileDataList.Add(childTransform.gameObject);
        }
    }

    /// <summary> 
    /// DataLoad �{�^���������ꂽ��Ăяo�����
    /// </summary>
    private void OnDataLoad()
    {
        _filePath = Path.Combine(Application.dataPath, "MapData/" + loadFileName + ".json");   //���͂����f�[�^�����邩����

        if (!File.Exists(_filePath))    //�t�@�C���p�X�Ɏw�肵�����O��Json�t�@�C�����Ȃ��ꍇ
        {
            Debug.LogError($"<color=yellow>{_filePath} ��JSON���Ȃ���</color>");
            return;
        }

        var Json = File.ReadAllText(_filePath);         // Json�t�@�C������������o��
        _mapData = JsonUtility.FromJson<MapData>(Json); //���o��������^����
        LoadTileData();
        Debug.Log($"<color=blue>{loadFileName} �����[�h������</color>");
    }

    /// <summary> 
    /// �e�^�C����Json�̃f�[�^���i�[����֐�
    /// </summary>
    private void LoadTileData()
    {
        foreach (var map in _mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            var tileData = tileDataList[map.index].GetComponent<TileData>();
            tileData.imageID = map.mapChip.mapImageID;
            tileData.isEnableProceed = map.mapChip.isEnableProceed;
            tileData.isEnableRope = map.mapChip.isEnableRope;
        }
    }
}
