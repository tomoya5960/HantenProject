using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JsonData : MonoBehaviour
{
    private Vector2 mapMaxArray = new Vector2(8, 7);    //�z��̍ő�l
    [SerializeField]
    private Button _dataSave = null;    //�f�[�^���Z�[�u
    [SerializeField]
    private Button _dataLoad = null;    //�f�[�^�����[�h
    [SerializeField]
    private List<Image> _panels = new List<Image>();    //�����Ƀ^�C����ۑ�
    MapData _mapData;
    private string _filePath = "";      //�f�[�^�̕ۑ���

    private void Start()
    {
        Debug.Assert(null != _dataSave, "_dataOutPut �{�^�����ݒ肳��Ă��܂���");
        Debug.Assert(null != _dataLoad, "_LoadData �{�^�����ݒ肳��Ă��܂���");
        //  �{�^�����������Ƃ��̃C�x���g��o�^����
        _dataSave.onClick.AddListener(OnClickSave);
        _dataLoad.onClick.AddListener(OnClickLoad);
        _filePath = Path.Combine(Application.dataPath, "MapData/MAP.json");
        _mapData = new MapData(mapMaxArray);
    }

    /// <summary> DataSave �{�^���������ꂽ��Ăяo�����</summary>
    private void OnClickSave()
    {
        var json = JsonUtility.ToJson(_mapData, false); //�K�v�ȏ���^����
        File.WriteAllText(_filePath, json); //�w�肵���t�@�C���ɏ���ۑ�
        Debug.Log("�f�[�^��ۑ�������");
    }

    /// <summary> DataLoad �{�^���������ꂽ��Ăяo�����</summary>
    private void OnClickLoad()
    {
        if (!File.Exists(_filePath))
            return;
        var json = File.ReadAllText(_filePath); // �w�肵���t�@�C���ɂ���������o��
        _mapData = JsonUtility.FromJson<MapData>(json); //���o��������^����
        DrawMap(mapMaxArray);
        Debug.Log("�f�[�^�����[�h������");
    }

    /// <summary> �^�C���̏����擾</summary>
    private void DrawMap(Vector2 _mapPos)
    {
        Vector2 _mapPosCount = new Vector2(0, 0);
        var count = 0;  //�G���[���p
        var maxCount = 0;   //�^�C���̐����L������@�G���[���p
        maxCount = (int)(_mapPos.x * _mapPos.y);
        foreach (var map in _mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            
            //�^�C���̖����ȏ�̓ǂݍ��݂��������ꍇ�͏I��
            if (count >= maxCount)  
                break;

            SetTileData(_panels[map.index].GetComponent<TileData>(), _mapPosCount,_mapData.Map[map.index].turnCount);
            if (_mapPosCount.x +1 < _mapPos.x)
            {
                map.mapChip.mapArray.x = _mapPosCount.x;
                _mapPosCount.x++;    //�z��̍s��++
            }
            else
            {
                _mapPosCount.x = 0;
                _mapPosCount.y++;
            }
            count++;
        }
    }

    /// <summary>�������ꂽ�^�C���ɏ����L��</summary>
    private void SetTileData(TileData tileData, Vector2 pos, int turnCount)
    {
        //�e�l����
        tileData._arrayPos = pos;
        tileData._turnCount = turnCount;
        if(turnCount == 0 && !tileData._isTurnOver)
        {
            tileData._isTurnOver = true;
        }
        else if(turnCount != 0 &&tileData._isTurnOver)
        {
            tileData._isTurnOver = false;
        }
    }

    /// <summary>�X�N���v�g���j�����ꂽ�Ƃ��ɓo�^�����C�x���g���폜����</summary>
    private void OnDestroy()
    {
        _dataSave.onClick.RemoveAllListeners();
        _dataLoad.onClick.RemoveAllListeners();
    }
}
