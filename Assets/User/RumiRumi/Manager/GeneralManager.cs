using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(MapType))]
[RequireComponent(typeof(StageManager))]

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance = null;   //ゲームマネージャは一つしかないよっていうやつ

    [HideInInspector]
    public        SoundManager   soundManager;       //SoundManagerを格納するやつだ！！
    [HideInInspector]
    public        MapType        mapType;            //MapTypeを格納するやつだ！！！
    [HideInInspector]
    public        StageManager   stageManager;
    private void Awake()    //スタートの前に呼び出すよ
    {
        if(instance == null)    //もしゲームマネージャーがなかった場合に呼ぶよ
        {
            instance = this;    //こいつが世界に一つのマネージャーになるよ
            DontDestroyOnLoad(this.gameObject); //このオブジェクトは消せねえ！ってするやつ
        }

        soundManager = GetComponent<SoundManager>(); //SoundManagerを管理するぜ！！
        mapType = GetComponent<MapType>(); //MapTypeを管理するぜ！！
        stageManager = GetComponent<StageManager>();

    }
}
