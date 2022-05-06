using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JsonTest : MonoBehaviour
{

    [SerializeField]
    private  int mapColumn = 7;
    [SerializeField]
    private  int mapLine = 8;
    [SerializeField]
    private Button _dataOutPut = null;
    [SerializeField]
    private Button _LoadData = null;
    [SerializeField]
    private List<Image> _panels = new List<Image>();
    MapData _mapData;
        
    private string _filePath = "";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(null != _dataOutPut, "_dataOutPut ボタンが設定されていません");
        Debug.Assert(null != _LoadData, "_LoadData ボタンが設定されていません");
        //  ボタンを押したときのイベントを登録する
        _dataOutPut.onClick.AddListener(OnClickJsonOutput);
        _LoadData.onClick.AddListener(OnClickLoadJson);
        _filePath = Path.Combine(Application.dataPath, "testdata/map.json");
        _mapData = new MapData(mapColumn, mapLine);
    }

    /// <summary>
    /// Json Output ボタンが押されたら呼び出される
    /// </summary>
    private void OnClickJsonOutput()
    {
        var json = JsonUtility.ToJson(_mapData, false);
        File.WriteAllText(_filePath, json);
    }

    /// <summary>
    /// Load Json ボタンが押されたら呼び出される
    /// </summary>
    private void OnClickLoadJson()
    {
        if(!File.Exists(_filePath))
            return;
        var json = File.ReadAllText(_filePath);
        _mapData = JsonUtility.FromJson<MapData>(json);
        DrawMap(mapColumn, mapLine);
    }

    /// <summary>
    /// スクリプトが破棄されたときに登録したイベントを削除する
    /// </summary>
    private void OnDestroy() 
    {
        _dataOutPut.onClick.RemoveAllListeners();
        _LoadData.onClick.RemoveAllListeners();
    }

    private void DrawMap(int _mapPosX, int _mapPosY)
    {
        int _mapPosXCount = 0;    //現在のタイルがマップ配列のどの位置にいるか（縦）
        int _mapPosYCount = 0;   //現在のタイルがマップ配列のどの位置にいるか（横）

        foreach (var map in _mapData.Map.Select((mapChip, index) => new {mapChip, index}))
        {
            map.mapChip.mapColumn = _mapPosXCount;  //配列Xを代入
            //SetTileData(map, _mapPosXCount, _mapPosYCount, true);
            _mapPosXCount++;    //配列の行を++
            if (_mapPosYCount == _mapPosY)
            {
                _mapPosYCount = 0;  //次の列に行くため行を０に変更
                map.mapChip.mapLine = _mapPosYCount;    //配列Yを代入
                _mapPosXCount++;  //列を++
            }
        }
    }

    /// <summary>
    /// 生成されたタイルに情報を記入
    /// </summary>
    private void SetTileData(GameObject nowTile,int _mapPosXCount,int _mapPosYCount, bool hanten)
    {
        var Tile = nowTile.GetComponent<TileData>();
        Tile._mapLine = _mapPosYCount;
        Tile._mapColumn = _mapPosXCount;
        Tile._isTurnOver = hanten;
    }
}
