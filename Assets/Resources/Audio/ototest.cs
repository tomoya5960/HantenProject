using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //�Đ�

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.instance.soundManager.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_02);   //SE

        //��~
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.StopSE();       //SE

        //�ꎞ��~/�ĊJ
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.MuteBGM();    //BGM �ꎞ��~
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.ResumeBGM();  //BGM ����BGM�Đ�
    }
}
