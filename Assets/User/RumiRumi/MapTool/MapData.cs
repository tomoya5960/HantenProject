using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class MapData
{
    [Serializable]
    public class MapChip
    {
        public int mapImageID;    //タイルのID
        public Vector2 mapArray;    //配列座標
        public int turnCount;       //反転した回数
        public bool isTurnOver;     //反転可能の有無
        public bool isRope;         //そのタイルにロープが落ちているか
        public MapChip(Vector2 _mapArray,int Id,bool Rope, bool Turn)   //初期化
        {
            mapArray = _mapArray;
            mapImageID = Id;
            isRope = Rope;
            isTurnOver = Turn;
        }
    }

    public List<MapChip> Map = new List<MapChip>();

    /// <summary>コンストラクタ</summary>
    public MapData(Vector2 _mapPos,int[] Id,bool[] Rope,bool[] Turn)
    {
        Vector2 _mapPosCount;
        int count = 0;
        //各タイルに自身が配列のどの位置なのか格納する
        for (_mapPosCount.x = 0; _mapPosCount.x <= _mapPos.x; _mapPosCount.x++)
        {
            for (_mapPosCount.y = 0; _mapPosCount.y <= _mapPos.y; _mapPosCount.y++)
            {
                if (count == 56)
                    break;
                Map.Add(new MapChip(_mapPosCount,Id[count],Rope[count],Turn[count]));
                count++;
            }
        }
    }
}
