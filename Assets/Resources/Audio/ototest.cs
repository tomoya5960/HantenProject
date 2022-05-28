using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //Ä¶

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.Instance.SoundM.bgm.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.Instance.SoundM.se.PlaySE(SE.SeName.se_02);   //SE

        //’â~
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.Instance.SoundM.bgm.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.Instance.SoundM.se.StopSE();       //SE

        //ˆê’â~/ÄŠJ
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.Instance.SoundM.bgm.MuteBGM();    //BGM ˆê’â~
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.Instance.SoundM.bgm.ResumeBGM();  //BGM “¯‚¶BGMÄ¶
    }
}
