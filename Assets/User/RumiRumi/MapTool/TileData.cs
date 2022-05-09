using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _arrayPos;   //タイルの配列座標
    public int _turnCount;      
    public bool _isTurnOver;    //タイルの反転可能かの有無
    public bool _isRope;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    /// <summary>反転できる回数が規定値に達した場合反転出来なくする処理</summary>
    public void HantenCheck()
    {
        //なんかそのうち追加するかも～
    }
}
