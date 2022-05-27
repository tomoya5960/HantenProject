using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("反転可能数")]
    public int turnOverCount = 0;   //反転できる残りの回数
    [SerializeField, Header("ステージ名")]
    private  string stageName = ""; //JsonOnlyJsonのステージ名を格納する
    private GameObject loadOnlyJsonObject;  //ステージ名が格納されているため取得するために使うやーつ

    #region MAPの二次元配列
    public  MapPosition[] mapPosX = new MapPosition[7];
    [System.Serializable]
    public class MapPosition
    {
        public GameObject[] mapPosY = new GameObject[8];
    }
    #endregion

    private void Awake()
    {
        loadOnlyJsonObject = GameObject.Find("LoadData");
    }
    private void Start()
    {
        if (loadOnlyJsonObject != null)
            stageName = loadOnlyJsonObject.GetComponent<LoadOnlyJson>().loadFileName;
        else
            stageName = "エディターで編集中";
    }

    /// <summary>
    /// 反転処理
    /// </summary>
    public void TurnOver()
    {
        if (turnOverCount != 0) //反転回数が残っていたら残りの使用回数を減らす
        {
            turnOverCount--;
            Debug.Log("反転しました。");
        }
        else
        {
            Debug.Log("反転できません");
            return; //反転できる回数が残っていない場合はそのまま返す
        }
    }
}
