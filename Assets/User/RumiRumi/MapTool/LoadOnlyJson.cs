using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadOnlyJson : MonoBehaviour
{
    private Vector2 mapMaxArray = new Vector2(8, 7);    //�z��̍ő�l
    [SerializeField]
    private string loadFileName = "";   //�ǂݍ��ރt�@�C����
    private string _filePath = "";      //�f�[�^�̕ۑ�����Ă���p�X���i�[
    public List<GameObject> _panels = new List<GameObject>();    //�����Ƀ^�C����ۑ�
    MapData _mapData;
    private void Start()
    {
        if (loadFileName == "")
            Debug.Log("�ǂݍ��ރf�[�^�̖��O���Ȃ���");

        _filePath = Path.Combine(Application.dataPath, "MapData/" + loadFileName + ".json");   //���͂����f�[�^�����邩����
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
            SetTileData(_panels[map.index].GetComponent<TileData>(), _mapPosCount, _mapData.Map[map.index].turnCount);
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
            _panels[count].GetComponent<TileData>().ImageID = map.mapChip.mapImageID;
            count++;
        }
    }
    /// <summary>�������ꂽ�^�C���ɏ����L��</summary>
    private void SetTileData(TileData tileData, Vector2 pos, int turnCount)
    {
        //�e�l����
        tileData._arrayPos = pos;
        tileData._turnCount = turnCount;
        if (turnCount == 0 && !tileData._isTurnOver)
        {
            tileData._isTurnOver = true;
        }
        else if (turnCount != 0 && tileData._isTurnOver)
        {
            tileData._isTurnOver = false;
        }
    }
}
