using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadOnlyJson : MonoBehaviour
{
    #region タイルデータ関係
    [HideInInspector]
    public List<GameObject>  tileDataList    = new List<GameObject>();  //ここにタイルを保存
    private GameObject       parentTiles;                               //タイルオブジェクトの親を格納する
    private MapData          _mapData        = new MapData();           //マップの実態を確保
    
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
    }

    private void Start()
    {
        OnDataLoad();
        GeneralManager.instance.mapManager.SetTileArray();
        GeneralManager.instance.mapManager.TurnNum = 0;
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
    /// 開始時にステージのJsonDataを呼び出す
    /// </summary>
    private void OnDataLoad()
    {
        _mapData = JsonUtility.FromJson<MapData>(GeneralManager.instance.mapType.jsonList
                                                [GeneralManager.instance.mapManager.selectStageNum]);
        LoadTileData();
        Debug.Log($"<color=blue>データをロードしたよ</color>");
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
            tileData.isEnableStone = map.mapChip.isEnableStone;
            tileData.isEnablePlayer = map.mapChip.isEnablePlayer;
        }
    }
}
