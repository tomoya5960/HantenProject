using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //Ä¶

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.Instance.soundManager.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_02);   //SE

        //â~
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.Instance.soundManager.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.Instance.soundManager.StopSE();       //SE

        //êâ~/ÄJ
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.Instance.soundManager.MuteBGM();    //BGM êâ~
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.Instance.soundManager.ResumeBGM();  //BGM ¯¶BGMÄ¶
    }
}
