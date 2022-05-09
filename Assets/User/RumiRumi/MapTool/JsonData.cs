using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JsonData : MonoBehaviour
{
    private Vector2 mapMaxArray = new Vector2(8, 7);    //配列の最大値
    [SerializeField]
    private Button _dataSave = null;    //データをセーブ
    [SerializeField]
    private Button _dataLoad = null;    //データをロード
    [SerializeField]
    private List<Image> _panels = new List<Image>();    //ここにタイルを保存
    MapData _mapData;
    private string _filePath = "";      //データの保存先

    private void Start()
    {
        Debug.Assert(null != _dataSave, "_dataOutPut ボタンが設定されていません");
        Debug.Assert(null != _dataLoad, "_LoadData ボタンが設定されていません");
        //  ボタンを押したときのイベントを登録する
        _dataSave.onClick.AddListener(OnClickSave);
        _dataLoad.onClick.AddListener(OnClickLoad);
        _filePath = Path.Combine(Application.dataPath, "MapData/MAP.json");
        _mapData = new MapData(mapMaxArray);
    }

    /// <summary> DataSave ボタンが押されたら呼び出される</summary>
    private void OnClickSave()
    {
        var json = JsonUtility.ToJson(_mapData, false); //必要な情報を与える
        File.WriteAllText(_filePath, json); //指定したファイルに情報を保存
        Debug.Log("データを保存したよ");
    }

    /// <summary> DataLoad ボタンが押されたら呼び出される</summary>
    private void OnClickLoad()
    {
        if (!File.Exists(_filePath))
            return;
        var json = File.ReadAllText(_filePath); // 指定したファイルにある情報を取り出す
        _mapData = JsonUtility.FromJson<MapData>(json); //取り出した情報を与える
        DrawMap(mapMaxArray);
        Debug.Log("データをロードしたよ");
    }

    /// <summary> タイルの情報を取得</summary>
    private void DrawMap(Vector2 _mapPos)
    {
        Vector2 _mapPosCount = new Vector2(0, 0);
        var count = 0;  //エラー回避用
        var maxCount = 0;   //タイルの数を記憶する　エラー回避用
        maxCount = (int)(_mapPos.x * _mapPos.y);
        foreach (var map in _mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            
            //タイルの枚数以上の読み込みがあった場合は終了
            if (count >= maxCount)  
                break;

            SetTileData(_panels[map.index].GetComponent<TileData>(), _mapPosCount,_mapData.Map[map.index].turnCount);
            if (_mapPosCount.x +1 < _mapPos.x)
            {
                map.mapChip.mapArray.x = _mapPosCount.x;
                _mapPosCount.x++;    //配列の行を++
            }
            else
            {
                _mapPosCount.x = 0;
                _mapPosCount.y++;
            }
            count++;
        }
    }

    /// <summary>生成されたタイルに情報を記入</summary>
    private void SetTileData(TileData tileData, Vector2 pos, int turnCount)
    {
        //各値を代入
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

    /// <summary>スクリプトが破棄されたときに登録したイベントを削除する</summary>
    private void OnDestroy()
    {
        _dataSave.onClick.RemoveAllListeners();
        _dataLoad.onClick.RemoveAllListeners();
    }
}
