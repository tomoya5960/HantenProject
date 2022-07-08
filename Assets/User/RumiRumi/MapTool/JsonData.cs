using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JsonData : MonoBehaviour
{
    #region タイルデータ関係
    [SerializeField]
    private List<GameObject> tileDataList    = new List<GameObject>();  //ここにタイルを保存
    private MapData          _mapData        = new MapData();           //マップの実態を確保
    private Vector2          mapTileMaxArray = new Vector2(8, 7);       //マップ配列の最大個数
    #endregion

    #region Json管理関係
    [HideInInspector]
    public  string        fileName      = "";   //保存するファイルの名前
    private string        _filePath     = "";   //データの保存先
    [SerializeField]
    private        Button _dataSave     = null; //データをセーブ
    [SerializeField]
    private        Button _dataLoad     = null; //データをロード
    [HideInInspector]
    public bool           overWriteSave = true; //上書き保存しないかするか選択してね
    #endregion

    private void Awake()
    {
        Debug.Assert(null != _dataSave, "_dataOutPut ボタンが設定されていません");
        Debug.Assert(null != _dataLoad, "_LoadData ボタンが設定されていません");

        //  ボタンを押したときのイベントを登録する
        _dataSave.onClick.AddListener(OnClickSave);
        _dataLoad.onClick.AddListener(OnClickLoad);
    }

    /// <summary> 
    /// DataSave ボタンが押されたら呼び出される
    /// </summary>
    private void OnClickSave()
    {
        _filePath = Path.Combine(Application.dataPath, "Resources/MapData/" + fileName + ".json");
        
        #region 名前が一致する場合は保存しない処理
        string[] _files = Directory.GetFiles("Assets/Resources/MapData/", "*.json", SearchOption.AllDirectories);
        
        foreach(string FileName in _files)
        {
            if(FileName == "Assets/MapData/" + fileName + ".json")   //名前の被りがあったら保存しない
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
        #endregion

        SaveTileData();
        var Json = JsonUtility.ToJson(_mapData, false); //まとめた情報をJsonに保存
        File.WriteAllText(_filePath, Json);             //Jsonを保存
        Debug.Log($"<color=blue>{_filePath} に保存したよ</color>");
    }

    /// <summary> 
    /// DataLoad ボタンが押されたら呼び出される
    /// </summary>
    private void OnClickLoad()
    {
        _filePath = Path.Combine(Application.dataPath, "Resources/MapData/" + fileName + ".json");   //入力したデータがあるか検索
        
        if (!File.Exists(_filePath))    //ファイルパスに指定した名前のJsonファイルがない場合
        {
            Debug.LogError($"<color=yellow>{_filePath} にJSONがないよ</color>");
            return;
        }
        
        var Json = File.ReadAllText(_filePath);         // Jsonファイルから情報を取り出す
        _mapData = JsonUtility.FromJson<MapData>(Json); //取り出した情報を与える
        LoadTileData();
        Debug.Log($"<color=blue>{_filePath} をロードしたよ</color>");
    }

    /// <summary> 
    /// 各タイルにJsonのデータを格納する関数
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
    /// 各タイルをJsonのデータに格納する関数
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
    /// スクリプトが破棄されたときに登録したイベントを削除する
    /// </summary>
    private void OnDestroy()
    {
        _dataSave.onClick.RemoveAllListeners();
        _dataLoad.onClick.RemoveAllListeners();
    }
}
