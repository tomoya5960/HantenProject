using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [Header("このタイルのイメージID")]
    public  int              imageID;
    [Header("反転できるか")]
    public  bool             isTurnOver;        //タイルの反転可能かの有無
    [Header("ロープが落ちているか")]
    public  bool             isEnableRope;      //このタイルにロープが落ちているか
    [Header("岩があるか")]
    public bool              isEnableStone;
    [Header("通ることはできるか")]
    public  bool             isEnableProceed;   //通ることができるか
    [HideInInspector]
    public int               childCount;
    [HideInInspector]
    public       GameObject  child;         //子オブジェクトの格納

}
