using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(MapType))]
[RequireComponent(typeof(GameManager))]


public class GeneralManager : MonoBehaviour
{
    public static GeneralManager Instance = null;  //ゲームマネージャは一つしかないよっていうやつ

    [HideInInspector]
    public SoundManager SoundM;  //SoundManagerを格納するやつだ！！
     [HideInInspector]
    public MapType MapT;  //MapTypeを格納するやつだ！！！
    [HideInInspector]
    public GameManager GameM;
    private void Awake()    //スタートの前に呼び出すよ
    {
        if(Instance == null)    //もしゲームマネージャーがなかった場合に呼ぶよ
        {
            Instance = this;    //こいつが世界に一つのマネージャーになるよ
            DontDestroyOnLoad(this.gameObject); //このオブジェクトは消せねえ！ってするやつ
        }

        SoundM = GetComponent<SoundManager>(); //SoundManagerを管理するぜ！！
        MapT = GetComponent<MapType>(); //MapTypeを管理するぜ！！
        GameM = GetComponent<GameManager>();
    }
}
