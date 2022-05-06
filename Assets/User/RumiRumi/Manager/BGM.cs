using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public enum BgmName    //BGMの種類
    {
        //以後追加
        bgm_01,
        bgm_02,
        bgm_03,
        bgm_04,
        Silent = 999,
    }

    private AudioSource bgmSource;
    public List<BgmStatus> BgmClips;
    private int[] bgmNumber;   //BgmNameの項目数の取得

    [System.Serializable]
    public struct BgmStatus  //リスト情報
    {
        [Header("名前")]
        public BgmName name;
        [Header("音量"), Range(0, 1)]
        public float volume;
        [Header("BGMデータ")]
        public AudioClip bgmData; //BGM一覧
    }

    private int currentBgmIndex = 999;  //現在選ばれているBGM番号
    private void Awake()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
    }
    private void Start()
    {
        string[] var = System.Enum.GetNames(typeof(BgmName));    //string[]→int[]に変換
        bgmNumber = new int[var.Length];    //intに変換

    }

    /// <summary>
    /// 再生関数
    /// </summary>
    /// <param name="bgmName">選択したBGM</param>
    public void PlayBGM(BgmName bgmName, bool loopFlg = true)
    {
        int index = (int)bgmName;    //選択されたBGM番号を格納
        currentBgmIndex = index;    //選択されたBGM番号を再生する為の変数に格納
        if (index == 999) //無音にするときのやつ
        {
            Debug.LogWarning("無音になったよ");
            StopBGM();  //他のBGMをすべてストップさせるよ
            return;
        }
        #region エラー回避用
        if (index < 0 || bgmNumber.Length <= index)  //選択されたBGM番号があるか確認：数字でPlayBGMを呼び出された際のエラー回避
        {
            Debug.LogWarning("検索できなかったよ");
            return;
        }
        else if (bgmSource.clip != null && bgmSource.clip == BgmClips[index].bgmData) // 同じBGMの場合は何もしない
        {

            Debug.LogWarning("BGMが同じだったよ");
            return;
        }
        #endregion
        else if (!bgmSource.isPlaying)  //再生されていなかったら
        {
            bgmSource.clip = BgmClips[index].bgmData;    //再生するBGMを選択
            bgmSource.volume = BgmClips[index].volume;  //音量を調整するよー
            bgmSource.Play();    //再生するよー
            return;
        }
    }

    /// <summary>
    /// BGM停止関数
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();    //すべてのBGMを停止
        return;
    }

    /// <summary>
    /// BGM一時停止
    /// </summary>
    public void MuteBGM()
    {
        bgmSource.Stop(); //BGMを一時停止～
    }

    /// <summary>
    /// 止めたBGMを再開する関数
    /// </summary>
    public void ResumeBGM()
    {
        bgmSource.Play(); //止めたBGMを再生～
    }
}
