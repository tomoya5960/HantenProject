using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public enum BgmType    //BGMの種類
    {
        //以後追加
        Test,
        Silent = 999,   //無音
    }
    public enum SeType    //SEの種類
    {
        //以後追加
        Test,
    }

#region ボリューム調整

    [Range(0,1)]    //Inspectorにバーで表示するやーつ
    public float bgmVolume; //BGMの音量
    [Range(0,1)]    //Inspectorにバーで表示するやーつ
    public float seVolume;  //SEの音量

#endregion
#region  オーディオクリップ

    public AudioClip[] bgmClips; //BGM一覧
    public AudioClip[] seClips;  //SE一覧

#endregion
#region  オーディオソース

    private AudioSource[] bgmSources = new AudioSource[1];  //BGMを格納する配列
    private AudioSource[] seSources = new AudioSource[1];   //SEを格納する配列

#endregion
 
    private int currentBgmIndex = 999;  //現在選ばれているBGM番号

    void Awake()    //スタート前に呼ぶよ
    {
        for (int i = 0; i < bgmSources.Length; i++) //BGMがあるだけ格納する
        {
            bgmSources[i] = gameObject.AddComponent<AudioSource>();
        }
        for (int i = 0; i < seSources.Length; i++)  //SEがあるだけ格納する
        {
            seSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    private void FixedUpdate() 
    {
        foreach (AudioSource source in  bgmSources) //ボリュームの調整
        {
            source.volume = bgmVolume;
        } 
        foreach (AudioSource source in seSources)   //ボリュームの調整
        {
            source.volume = seVolume;
        }  
    }

#region BGM関連

    public void PlayBgm(BgmType bgmType,bool loopFlg = true)
    {
        if((int)bgmType == 999) //無音にするときのやつ
        {
            Debug.LogWarning("無音になったよ");
            StopBGM();
            return;
        }
        int index = (int)bgmType;   //選択されたBGM番号を格納
        currentBgmIndex = index;    //選択されたBGM番号を再生する為の変数に格納

        if (index < 0 || bgmClips.Length <= index)  //選択されたBGM番号があるか確認
        {
            Debug.LogWarning("検索できなかったよ");
            return; //無かった場合は検索を終了するよ
        }

                
        if (bgmSources[(int)bgmType].clip != null && bgmSources[(int)bgmType].clip  == bgmClips[index]) // 同じBGMの場合は何もしない
        {
            
            Debug.LogWarning("BGMが同じだったよ");
            return;
        } 

        foreach (AudioSource source in bgmSources)  //選択された番号を検索
        {
            if (false == source.isPlaying)  //再生されていなかったら
            {
                source.clip = bgmClips[index];  //選択されたBGM番号を保存
                source.Play();  //再生だ！
                return;
            }
        }
    }

    /// <summary>
    /// BGM完全停止
    /// </summary>
    public void StopBGM()
    {
        foreach (AudioSource bgmSources in bgmSources) //選択されたBGM番号を検索
        {
            bgmSources.Stop();  //再生を止める
            bgmSources.clip = null; //格納されていたBGM番号を初期化
        }
    }

    /// <summary>
    /// BGM一時停止
    /// </summary>
    public void MuteBGM()
    {
        bgmSources[currentBgmIndex].Stop(); //BGMを一時停止～
    }

    /// <summary>
    /// 一時停止した同じBGMを再生(再開)
    /// </summary>
    public void ResumeBGM()
    {
        bgmSources[currentBgmIndex].Play(); //止めたBGMを再生～
    }

#endregion

#region  SE関連

    public void PlaySE(SeType seType)
    {
        int index = (int)seType;    //選択されたSE番号を格納
        if (index < 0 || seClips.Length <= index)  //選択されたSE番号があるか確認
        {
            Debug.LogWarning("検索できなかったよ");
            return;
        }

        foreach (AudioSource source in seSources)   // 再生中ではないAudioSouceをつかってSEを鳴らす
        {
            if (false == source.isPlaying)  //再生されていなかったら
            {
                source.clip = seClips[index];  //選択されたBGM番号を保存
                source.Play();  //再生だ！
                return;
            }
        }
    }
    /// <summary>
    /// SE停止
    /// </summary>
    public void StopSE() 
    {
        foreach (AudioSource source in seSources)   // 全てのSE用のAudioSouceを停止する
        {
            source.Stop();  //とまれー
            source.clip = null; //格納されたいたSE番号を初期化
        }
    }

#endregion


    // https://i-school.memo.wiki/d/SoundManager%A4%C7%A5%B2%A1%BC%A5%E0%C6%E2%A4%CE%B2%BB%B8%BB%A4%F2%B4%C9%CD%FD%A4%B9%A4%EB
}

