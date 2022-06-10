using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //Ä¶

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.instance.soundManager.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_02);   //SE

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
