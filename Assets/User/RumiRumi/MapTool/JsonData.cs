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
    public List<GameObject> _panels = new List<GameObject>();    //�����Ƀ^�C����ۑ�
    private int[] _num;
    private bool[] _rope;
    private bool[] _turn;
    MapData _mapData;
    [HideInInspector]
    public string _fileName = "";   //�ۑ�����t�@�C���̖��O
    private string _filePath = "";      //�f�[�^�̕ۑ���
    [HideInInspector]
    public bool overWriteSave = true;  //�㏑���ۑ����Ȃ������邩�I�����Ă�
    private void Start()
    {
        Debug.Assert(null != _dataSave, "_dataOutPut �{�^�����ݒ肳��Ă��܂���");
        Debug.Assert(null != _dataLoad, "_LoadData �{�^�����ݒ肳��Ă��܂���");
        var listNum = 56;
        _num = new int[listNum];
        _rope = new bool[listNum];
        _turn = new bool[listNum];
        //  �{�^�����������Ƃ��̃C�x���g��o�^����
        _dataSave.onClick.AddListener(OnClickSave);
        _dataLoad.onClick.AddListener(OnClickLoad);
    }

    /// <summary> DataSave �{�^���������ꂽ��Ăяo�����</summary>
    private void OnClickSave()
    {
        _filePath = Path.Combine(Application.dataPath, "MapData/" + _fileName + ".json");
        string[] files = Directory.GetFiles("Assets/MapData/", "*.json", SearchOption.AllDirectories);
        //���O����v����ꍇ�͕ۑ����Ȃ�����
        foreach(string name in files)
        {
            if(name == "Assets/MapData/" + _fileName + ".json")   //���O�̔�肪��������ۑ����Ȃ�
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

        foreach (int num in Enumerable.Range(0, _panels.Count))
        {
            _num[num] = _panels[num].gameObject.GetComponent<TileData>()._imageID;
            _rope[num] = _panels[num].gameObject.GetComponent<TileData>()._isRope;
            _turn[num] = _panels[num].gameObject.GetComponent<TileData>()._isTurnOver;
        }
       
        _mapData = new MapData(mapMaxArray, _num,_rope,_turn);
         var json = JsonUtility.ToJson(_mapData, false); //�K�v�ȏ���^����
        File.WriteAllText(_filePath, json); //�w�肵���t�@�C���ɏ���ۑ�
        Debug.Log(_fileName + "�͂�������ۑ�������");
    }

    /// <summary> DataLoad �{�^���������ꂽ��Ăяo�����</summary>
    private void OnClickLoad()
    {
        _filePath = Path.Combine(Application.dataPath, "MapData/" + _fileName + ".json");   //���͂����f�[�^�����邩����
        if (!File.Exists(_filePath))
        {
            Debug.Log($"<color=yellow>{_filePath} ��JSON���Ȃ���</color>");
            return;
        }
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
            if (map == null) continue;
            //�^�C���̖����ȏ�̓ǂݍ��݂��������ꍇ�͏I��
            if (count >= maxCount)  
                break;
            SetTileData(_panels[map.index].GetComponent<TileData>(), _mapPosCount, _mapData.Map[map.index].isRope);
            if (_mapPosCount.x <= _mapPos.x)
            {
                map.mapChip.mapArray.x = _mapPosCount.x;
                _mapPosCount.x++;    //�z��̍s��++
            }
            else
            {
                _mapPosCount.x = 0;
                _mapPosCount.y++;
            }
            _panels[count].GetComponent<TileData>()._imageID = map.mapChip.mapImageID;
            _panels[count].GetComponent<TileData>()._isRope = map.mapChip.isRope;
            _panels[count].GetComponent<TileData>()._isTurnOver = map.mapChip.isTurnOver;
            count++;
        }
    }

    /// <summary>�������ꂽ�^�C���ɏ����L��</summary>
    private void SetTileData(TileData tileData, Vector2 pos, bool isRope)
    {
        //�e�l����
        tileData._arrayPos = pos;
        if (tileData._isRope != isRope)
        {
            tileData._isRope = isRope; 
        }
        //if( !tileData._isTurnOver)
        //{
        //    tileData._isTurnOver = true;
        //}
        //else if(tileData._isTurnOver)
        //{
        //    tileData._isTurnOver = false;
        //}
    }

    /// <summary>�X�N���v�g���j�����ꂽ�Ƃ��ɓo�^�����C�x���g���폜����</summary>
    private void OnDestroy()
    {
        _dataSave.onClick.RemoveAllListeners();
        _dataLoad.onClick.RemoveAllListeners();
    }
}
