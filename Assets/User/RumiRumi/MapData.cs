using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MapData
{
    public enum MapTail    //タイルの種類
    {
        OuterWall,                              //外壁
        WhitePassage,                       //白通路
        WhiteWall,                             //白壁
        BlackPassage,                       //黒通路
        BlackWall,                              //黒壁
        IcePassage,                           //氷通路
        IceWall,                                 //氷壁
        Rope,                                    //ロープ
        Goal,                                     //ゴール
        GoalWithRope,                      //ロープ付きゴール
        StoneMonument,                  //石碑
        StoneStatueUp,                    //石像(上)
        StoneStatueDown,               //石像(下)
        StoneStatueLeft,                  //石像(左)
        StoneStatueRight,                //石像(上)
        BrokenStoneStatueUp,         //壊れた石像(上)
        BrokenStoneStatueDown,    //壊れた石像(下)
        BrokenStoneStatueLeft,       //壊れた石像(左)
        BrokenStoneStatueRight,     //壊れた石像(右)
    }

    [Serializable]
    public class MapChip
    {
        [Header("タイル")]
        public MapTail mapTile; //現在のタイル
        public int mapColumn, mapLine; //配列の座標 縦/横
        public bool isTurnOver; //タイルがひっくり返ったか確認
        
        public MapChip(int _mapChipLine, int _mapChipColumn)
        {
            mapLine = _mapChipLine;            //タイルの配列座標を格納
            mapColumn = _mapChipColumn; //タイルの配列座標を格納
            isTurnOver = false;                         //反転boolをオフに
        }
    }
    
    public List<MapChip> Map = new List<MapChip>();

    /// <summary>
    /// コンストラクタ（初期化）
    /// </summary>
    public MapData(int _mapPosX, int _mapPosY)
    {
        int _mapPosXCount = 0;    //現在のタイルがマップ配列のどの位置にいるか（縦）
        int _mapPosYCount = 0;   //現在のタイルがマップ配列のどの位置にいるか（横）
        
        foreach (var i in Enumerable.Range(0, _mapPosX * _mapPosY))
        {
            Map.Add(new MapData.MapChip(_mapPosYCount, _mapPosXCount));
            _mapPosYCount++;    //配列の行を++
            if (_mapPosYCount == _mapPosY)
            {
                _mapPosYCount = 0;  //次の列に行くため行を０に変更
                _mapPosXCount++;  //列を++
            }
        }
    }
}
