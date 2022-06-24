using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MapData
{
    /// <summary> マップのチップ最大数 </summary>
    private readonly int _mapMaxCount = 56;

    [Serializable]
    public class MapChip
    {
        public int      mapImageID;         //タイルのID
        public int      turnCount;          //反転した回数
        public bool     isEnableRope;       //このタイルにロープが落ちているか
        public bool      isEnableStone;     //このタイルに岩が落ちているか
        public bool     isEnableProceed;    //通れるか

        public MapChip()   //初期化
        {
            mapImageID      = 0;
            turnCount       = 0;
            isEnableRope    = false;
            isEnableStone = false;
            isEnableProceed = true;
        }
    }

    public List<MapChip> Map = new List<MapChip>();

    /// <summary>コンストラクタ</summary>
    public MapData()
    {
        foreach (var num in Enumerable.Range(0, _mapMaxCount))
        {
            Map.Add(new MapData.MapChip());
        }
    }
}
