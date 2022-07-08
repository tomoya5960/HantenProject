using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JsonData : MonoBehaviour
{
    #region �^�C���f�[�^�֌W
    [SerializeField]
    private List<GameObject> tileDataList    = new List<GameObject>();  //�����Ƀ^�C����ۑ�
    private MapData          _mapData        = new MapData();           //�}�b�v�̎��Ԃ��m��
    private Vector2          mapTileMaxArray = new Vector2(8, 7);       //�}�b�v�z��̍ő��
    #endregion

    #region Json�Ǘ��֌W
    [HideInInspector]
    public  string        fileName      = "";   //�ۑ�����t�@�C���̖��O
    private string        _filePath     = "";   //�f�[�^�̕ۑ���
    [SerializeField]
    private        Button _dataSave     = null; //�f�[�^���Z�[�u
    [SerializeField]
    private        Button _dataLoad     = null; //�f�[�^�����[�h
    [HideInInspector]
    public bool           overWriteSave = true; //�㏑���ۑ����Ȃ������邩�I�����Ă�
    #endregion

    private void Awake()
    {
        Debug.Assert(null != _dataSave, "_dataOutPut �{�^�����ݒ肳��Ă��܂���");
        Debug.Assert(null != _dataLoad, "_LoadData �{�^�����ݒ肳��Ă��܂���");

        //  �{�^�����������Ƃ��̃C�x���g��o�^����
        _dataSave.onClick.AddListener(OnClickSave);
        _dataLoad.onClick.AddListener(OnClickLoad);
    }

    /// <summary> 
    /// DataSave �{�^���������ꂽ��Ăяo�����
    /// </summary>
    private void OnClickSave()
    {
        _filePath = Path.Combine(Application.dataPath, "Resources/MapData/" + fileName + ".json");
        
        #region ���O����v����ꍇ�͕ۑ����Ȃ�����
        string[] _files = Directory.GetFiles("Assets/Resources/MapData/", "*.json", SearchOption.AllDirectories);
        
        foreach(string FileName in _files)
        {
            if(FileName == "Assets/MapData/" + fileName + ".json")   //���O�̔�肪��������ۑ����Ȃ�
            {
                if (overWriteSave)   //�㏑���ۑ����邩�m�F
                {
                    Debug.Log("�������O�̃f�[�^�����݂��Ă��邪�A�㏑���ۑ���I�����Ă��邽�ߑ��s");
                    break;
                }
                else
                {
                    Debug.Log("�������O�̃f�[�^�����݂��Ă���A�㏑���ۑ����Ȃ���I���������ߏI��");
                    return;
                } 
            }
        }
        #endregion

        SaveTileData();
        var Json = JsonUtility.ToJson(_mapData, false); //�܂Ƃ߂�����Json�ɕۑ�
        File.WriteAllText(_filePath, Json);             //Json��ۑ�
        Debug.Log($"<color=blue>{_filePath} �ɕۑ�������</color>");
    }

    /// <summary> 
    /// DataLoad �{�^���������ꂽ��Ăяo�����
    /// </summary>
    private void OnClickLoad()
    {
        _filePath = Path.Combine(Application.dataPath, "Resources/MapData/" + fileName + ".json");   //���͂����f�[�^�����邩����
        
        if (!File.Exists(_filePath))    //�t�@�C���p�X�Ɏw�肵�����O��Json�t�@�C�����Ȃ��ꍇ
        {
            Debug.LogError($"<color=yellow>{_filePath} ��JSON���Ȃ���</color>");
            return;
        }
        
        var Json = File.ReadAllText(_filePath);         // Json�t�@�C������������o��
        _mapData = JsonUtility.FromJson<MapData>(Json); //���o��������^����
        LoadTileData();
        Debug.Log($"<color=blue>{_filePath} �����[�h������</color>");
    }

    /// <summary> 
    /// �e�^�C����Json�̃f�[�^���i�[����֐�
    /// </summary>
    private void LoadTileData()
    {
        foreach(var obj in tileDataList)
        {
            if(obj.transform.childCount > 0)
            {
                Destroy(obj.transform.GetChild(0).gameObject);
            }
        }

        foreach (var map in _mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            var tileData = tileDataList[map.index].GetComponent<EdiotTileData>();
            tileData.imageID = map.mapChip.mapImageID;
            tileData.isEnableProceed = map.mapChip.isEnableProceed;
            tileData.isEnableRope = map.mapChip.isEnableRope;
            tileData.isEnableStone = map.mapChip.isEnableStone;
            tileData.isEnablePlayer = map.mapChip.isEnablePlayer;
        }
    }

    /// <summary> 
    /// �e�^�C����Json�̃f�[�^�Ɋi�[����֐�
    /// </summary>
    private void SaveTileData()
    {
        foreach (var map in _mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            var tileData = tileDataList[map.index].GetComponent<EdiotTileData>();
            map.mapChip.mapImageID = tileData.imageID;
            map.mapChip.isEnableProceed = tileData.isEnableProceed;
            map.mapChip.isEnableRope = tileData.isEnableRope;
            map.mapChip.isEnableStone= tileData.isEnableStone;
            map.mapChip.isEnablePlayer = tileData.isEnablePlayer;
        }
    }

    /// <summary>
    /// �X�N���v�g���j�����ꂽ�Ƃ��ɓo�^�����C�x���g���폜����
    /// </summary>
    private void OnDestroy()
    {
        _dataSave.onClick.RemoveAllListeners();
        _dataLoad.onClick.RemoveAllListeners();
    }
}
