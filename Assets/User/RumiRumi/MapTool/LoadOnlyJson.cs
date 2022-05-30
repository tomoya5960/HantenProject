using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnlyJson : MonoBehaviour
{
    #region タイルデータ関係
    [HideInInspector]
    public List<GameObject>  tileDataList    = new List<GameObject>();  //ここにタイルを保存
    private GameObject       parentTiles;                               //タイルオブジェクトの親を格納する
    private MapData          _mapData        = new MapData();           //マップの実態を確保
    private Vector2          mapTileMaxArray = new Vector2(8, 7);       //マップ配列の最大個数
    #endregion

    #region Json管理関係
    [HideInInspector]
    public  string loadFileName = "";   //読み込むファイルの名前
    private string _filePath    = "";   //データの保存されているパス
    #endregion

    private void Awake()
    {
        if (!GameObject.Find("Map"))
        {
            parentTiles = null;
            Debug.LogError($"<color=red>Map がないよ</color>");
        }
        else
        {
            parentTiles = GameObject.Find("Map");
            SetTiles(parentTiles);
        }
        loadFileName = SceneManager.GetActiveScene().name;
        OnDataLoad();
        LoadTileData();
    }

    /// <summary>
    /// リストにオブジェクトを格納する関数
    /// </summary>
    /// <param name="Parent">タイルの親オブジェクト</param>
    private void SetTiles(GameObject Parent)
    {
        foreach (Transform childTransform in Parent.transform)
        {
            tileDataList.Add(childTransform.gameObject);
        }
    }

    /// <summary> 
    /// DataLoad ボタンが押されたら呼び出される
    /// </summary>
    private void OnDataLoad()
    {
        _filePath = Path.Combine(Application.dataPath, "MapData/" + loadFileName + ".json");   //入力したデータがあるか検索

        if (!File.Exists(_filePath))    //ファイルパスに指定した名前のJsonファイルがない場合
        {
            Debug.LogError($"<color=yellow>{_filePath} にJSONがないよ</color>");
            return;
        }

        var Json = File.ReadAllText(_filePath);         // Jsonファイルから情報を取り出す
        _mapData = JsonUtility.FromJson<MapData>(Json); //取り出した情報を与える
        LoadTileData();
        Debug.Log($"<color=blue>{loadFileName} をロードしたよ</color>");
    }

    /// <summary> 
    /// 各タイルにJsonのデータを格納する関数
    /// </summary>
    private void LoadTileData()
    {
        foreach (var map in _mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            var tileData = tileDataList[map.index].GetComponent<TileData>();
            tileData.imageID = map.mapChip.mapImageID;
            tileData.isEnableProceed = map.mapChip.isEnableProceed;
            tileData.isEnableRope = map.mapChip.isEnableRope;
        }
    }
}
