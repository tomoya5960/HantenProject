using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //Ä¶

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.instance.soundManager.bgm.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.instance.soundManager.se.PlaySE(SE.SeName.se_02);   //SE

        //’â~
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.bgm.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.se.StopSE();       //SE

        //ˆê’â~/ÄŠJ
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.bgm.MuteBGM();    //BGM ˆê’â~
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.bgm.ResumeBGM();  //BGM “¯‚¶BGMÄ¶
    }
}
