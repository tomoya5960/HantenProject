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
    public List<GameObject> _panels = new List<GameObject>();    //ここにタイルを保存
    private int[] _num;
    private bool[] _rope;
    private bool[] _turn;
    MapData _mapData;
    [HideInInspector]
    public string _fileName = "";   //保存するファイルの名前
    private string _filePath = "";      //データの保存先
    [HideInInspector]
    public bool overWriteSave = true;  //上書き保存しないかするか選択してね
    private void Start()
    {
        Debug.Assert(null != _dataSave, "_dataOutPut ボタンが設定されていません");
        Debug.Assert(null != _dataLoad, "_LoadData ボタンが設定されていません");
        var listNum = 56;
        _num = new int[listNum];
        _rope = new bool[listNum];
        _turn = new bool[listNum];
        //  ボタンを押したときのイベントを登録する
        _dataSave.onClick.AddListener(OnClickSave);
        _dataLoad.onClick.AddListener(OnClickLoad);
    }

    /// <summary> DataSave ボタンが押されたら呼び出される</summary>
    private void OnClickSave()
    {
        _filePath = Path.Combine(Application.dataPath, "MapData/" + _fileName + ".json");
        string[] files = Directory.GetFiles("Assets/MapData/", "*.json", SearchOption.AllDirectories);
        //名前が一致する場合は保存しない処理
        foreach(string name in files)
        {
            if(name == "Assets/MapData/" + _fileName + ".json")   //名前の被りがあったら保存しない
            {
                if (overWriteSave)   //上書き保存するか確認
                {
                    Debug.Log("同じ名前のデータが存在しているが、上書き保存を選択しているため続行");
                    break;
                }
                else
                {
                    Debug.Log("同じ名前のデータが存在しており、上書き保存しないを選択したため終了");
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
         var json = JsonUtility.ToJson(_mapData, false); //必要な情報を与える
        File.WriteAllText(_filePath, json); //指定したファイルに情報を保存
        Debug.Log(_fileName + "はしっかり保存したよ");
    }

    /// <summary> DataLoad ボタンが押されたら呼び出される</summary>
    private void OnClickLoad()
    {
        _filePath = Path.Combine(Application.dataPath, "MapData/" + _fileName + ".json");   //入力したデータがあるか検索
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

    /// <summary> タイルの情報を取得</summary>
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
            SetTileData(_panels[map.index].GetComponent<TileData>(), _mapPosCount, _mapData.Map[map.index].isRope);
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
            _panels[count].GetComponent<TileData>()._imageID = map.mapChip.mapImageID;
            _panels[count].GetComponent<TileData>()._isRope = map.mapChip.isRope;
            _panels[count].GetComponent<TileData>()._isTurnOver = map.mapChip.isTurnOver;
            count++;
        }
    }

    /// <summary>生成されたタイルに情報を記入</summary>
    private void SetTileData(TileData tileData, Vector2 pos, bool isRope)
    {
        //各値を代入
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

    /// <summary>スクリプトが破棄されたときに登録したイベントを削除する</summary>
    private void OnDestroy()
    {
        _dataSave.onClick.RemoveAllListeners();
        _dataLoad.onClick.RemoveAllListeners();
    }
}
