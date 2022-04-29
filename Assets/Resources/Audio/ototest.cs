using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{
    void Update()
    {
        //Ä¶
        if(Input.GetKeyDown(KeyCode.Q))
            GameManager.instance.soundManager.PlayBGM(SoundManager.BgmType.BgmTest);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GameManager.instance.soundManager.PlaySE(SoundManager.SeType.SeTest);       //SE

        //’â~
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.instance.soundManager.StopBGM();    //BGM
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.instance.soundManager.StopSE();       //SE

        //ˆê’â~/ÄŠJ
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.instance.soundManager.MuteBGM();    //BGM ˆê’â~
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.instance.soundManager.ResumeBGM();  //BGM “¯‚¶BGMÄ¶




    }
}
