using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadOnlyJson : MonoBehaviour
{
    #region �^�C���f�[�^�֌W
    [HideInInspector]
    public List<GameObject>  tileDataList    = new List<GameObject>();  //�����Ƀ^�C����ۑ�
    private GameObject       parentTiles;                               //�^�C���I�u�W�F�N�g�̐e���i�[����
    private MapData          _mapData        = new MapData();           //�}�b�v�̎��Ԃ��m��
    
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
    }

    private void Start()
    {
        OnDataLoad();
        GeneralManager.instance.mapManager.SetTileArray();
        GeneralManager.instance.mapManager.TurnNum = 0;
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
    /// �J�n���ɃX�e�[�W��JsonData���Ăяo��
    /// </summary>
    private void OnDataLoad()
    {
        _mapData = JsonUtility.FromJson<MapData>(GeneralManager.instance.mapType.jsonList
                                                [GeneralManager.instance.mapManager.selectStageNum]);
        LoadTileData();
        Debug.Log($"<color=blue>�f�[�^�����[�h������</color>");
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
            tileData.isEnableStone = map.mapChip.isEnableStone;
            tileData.isEnablePlayer = map.mapChip.isEnablePlayer;
        }
    }
}
