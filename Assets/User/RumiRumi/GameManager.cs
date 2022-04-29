using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;  //ゲームマネージャは一つしかないよっていうやつ

    private SoundManager soundManager;  //SoundManagerを格納するやつだ！！！
    private void Awake()    //スタートの前に呼び出すよ
    {
        if(instance == null)    //もしゲームマネージャーがなかった場合に呼ぶよ
        {
            instance = this;    //こいつが世界に一つのマネージャーになるよ
            DontDestroyOnLoad(this.gameObject); //俺のオブジェクトは消せねえ！ってするやつ
        }

        soundManager = GetComponent<SoundManager>(); //SoundManagerを管理するぜ！！
    }
}
