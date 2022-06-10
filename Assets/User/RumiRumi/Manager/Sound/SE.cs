using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public enum SeName    //BGMの種類
    {
        //以後追加
        se_01,
        se_02,
        se_03,      
        se_04,
        se_05,
        se_06,
        se_07,
        se_08,
        se_09,
        se_10,
        se_11,
        se_12,
        se_13,
        se_14,
    }

    private       AudioSource    seSource;
    public        List<SeStatus> SeClips;
    private int[]                seNumber;   //SeNameの項目数の取得
    [System.Serializable]
    public struct SeStatus  //リスト情報
    {
        [Header("名前")]
        public       SeName    name;
        [Header("音量"), Range(0, 1)]
        public float           volume;
        [Header("SEデータ")]
        public       AudioClip seData; //BGM一覧
    }

    private void Awake()
    {
        seSource = gameObject.AddComponent<AudioSource>();
    }
    private void Start()
    {
        string[] var = System.Enum.GetNames(typeof(SeName));    //string[]→int[]に変換
        seNumber = new int [var.Length];    //intに変換

    }

    /// <summary>
    /// 再生関数
    /// </summary>
    /// <param name="seName">選択したSE</param>
    public void PlaySE(SeName seName)
    {
        int index = (int)seName;    //選択されたSE番号を格納
        if (index < 0 || seNumber.Length <= index)  //選択されたSE番号があるか確認：数字でPlaySEを呼び出された際のエラー回避
        {
            Debug.LogWarning("検索できなかったよ");
            return;
        }
        seSource.clip = SeClips[index].seData;    //再生するSEを選択
        seSource.volume = SeClips[index].volume;  //音量を調整するよー
        seSource.Play();    //再生するよー
        return;
    }

    /// <summary>
    /// SE停止関数
    /// </summary>
    public void StopSE()
    {

        seSource.Stop();    //すべてのSEを停止

        return;
    }
}
