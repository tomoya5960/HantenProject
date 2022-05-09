using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData
{
    public enum MapTile    //タイルの種類
    {
        clearTile,
        OuterWall,              //外壁
        WhitePassage,           //白通路
        WhiteWall,              //白壁
        BlackPassage,           //黒通路
        BlackWall,              //黒壁
        IcePassage,             //氷通路
        IceWall,                //氷壁
        Rope,                   //ロープ
        Goal,                   //ゴール
        GoalWithRope,           //ロープ付きゴール
        StoneMonument,          //石碑
        StoneStatueUp,          //石像(上)
        StoneStatueDown,        //石像(下)
        StoneStatueLeft,        //石像(左)
        StoneStatueRight,       //石像(上)
        BrokenStoneStatueUp,    //壊れた石像(上)
        BrokenStoneStatueDown,  //壊れた石像(下)
        BrokenStoneStatueLeft,  //壊れた石像(左)
        BrokenStoneStatueRight, //壊れた石像(右)
    }

    [Serializable]
    public class MapChip
    {
        [Header("タイルタイプ")]
        public MapTile mapTile;     //タイルの種類
        public Vector2 mapArray;    //配列座標
        public int turnCount;       //反転した回数
        public bool isTurnOver;     //反転可能の有無
        public bool isRope;         //そのタイルにロープが落ちているか

        public MapChip(Vector2 _mapArray)   //初期化
        {
            mapArray = _mapArray;
            turnCount = 0;
            isTurnOver = false;
        }
    }

    public List<MapChip> Map = new List<MapChip>();

    /// <summary>コンストラクタ</summary>
    /// <param name="_mapPos">配列座標</param>
    public MapData(Vector2 _mapPos)
    {
        Vector2 _mapPosCount;
        //各タイルに自身が配列のどの位置なのか格納する
        for (_mapPosCount.x = 0; _mapPosCount.x <= _mapPos.x; _mapPosCount.x++)
        {
            for (_mapPosCount.y = 0; _mapPosCount.y <= _mapPos.y; _mapPosCount.y++)
            {
                Map.Add(new MapData.MapChip(_mapPosCount));
            }
        }
    }
}
