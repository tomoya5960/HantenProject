using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{
    [Range(0,2)]
    public int audio_test;
    void Update()
    {
        //Ä¶

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.instance.soundManager.PlayBGM((SoundManager.BgmName)audio_test) ;    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.instance.soundManager.PlaySE((SoundManager.SeName)audio_test);   //SE

        //’â~
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.StopSE();       //SE

        //ˆê’â~/ÄŠJ
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.MuteBGM();    //BGM ˆê’â~
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.ResumeBGM();  //BGM “¯‚¶BGMÄ¶
    }
}
