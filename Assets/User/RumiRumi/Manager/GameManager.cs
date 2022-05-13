using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(Dictionary))]

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;  //ゲームマネージャは一つしかないよっていうやつ

    [HideInInspector]
    public SoundManager soundManager;  //SoundManagerを格納するやつだ！！
     [HideInInspector]
    public Dictionary dictionary;  //Dictionaryを格納するやつだ！！！
    private void Awake()    //スタートの前に呼び出すよ
    {
        if(instance == null)    //もしゲームマネージャーがなかった場合に呼ぶよ
        {
            instance = this;    //こいつが世界に一つのマネージャーになるよ
            DontDestroyOnLoad(this.gameObject); //俺のオブジェクトは消せねえ！ってするやつ
        }

        soundManager = GetComponent<SoundManager>(); //SoundManagerを管理するぜ！！
        dictionary = GetComponent<Dictionary>(); //Dictionaryを管理するぜ！！
    }
}
