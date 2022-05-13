using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadOnlyJson : MonoBehaviour
{
    private Vector2 mapMaxArray = new Vector2(8, 7);    //配列の最大値
    [SerializeField]
    private string loadFileName = "";   //読み込むファイル名
    private string _filePath = "";      //データの保存されているパスを格納
    public List<GameObject> _panels = new List<GameObject>();    //ここにタイルを保存
    MapData _mapData;
    private void Start()
    {
        if (loadFileName == "")
            Debug.Log("読み込むデータの名前がないよ");

        _filePath = Path.Combine(Application.dataPath, "MapData/" + loadFileName + ".json");   //入力したデータがあるか検索
        if (!File.Exists(_filePath))
        {
            Debug.Log($"<color=yellow>{_filePath} にJSONがないよ</color>");
            return;
        }
        var json = File.ReadAllText(_filePath); // 指定したファイルにある情報を取り出す
        _mapData = JsonUtility.FromJson<MapData>(json); //取り出した情報を与える
        DrawMap(mapMaxArray);
        Debug.Log("データをロードしたよ");
    }
    private void DrawMap(Vector2 _mapPos)
    {
        Vector2 _mapPosCount = new Vector2(0, 0);
        var count = 0;  //エラー回避用
        var maxCount = 0;   //タイルの数を記憶する　エラー回避用
        maxCount = (int)(_mapPos.x * _mapPos.y);
        foreach (var map in _mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            if (map == null) continue;
            //タイルの枚数以上の読み込みがあった場合は終了
            if (count >= maxCount)
                break;
            SetTileData(_panels[map.index].GetComponent<TileData>(), _mapPosCount, _mapData.Map[map.index].turnCount);
            if (_mapPosCount.x <= _mapPos.x)
            {
                map.mapChip.mapArray.x = _mapPosCount.x;
                _mapPosCount.x++;    //配列の行を++
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
    /// <summary>生成されたタイルに情報を記入</summary>
    private void SetTileData(TileData tileData, Vector2 pos, int turnCount)
    {
        //各値を代入
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
