using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //�Đ�

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.instance.soundManager.bgm.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.instance.soundManager.se.PlaySE(SE.SeName.se_02);   //SE

        //��~
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.bgm.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.se.StopSE();       //SE

        //�ꎞ��~/�ĊJ
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.instance.soundManager.bgm.MuteBGM();    //BGM �ꎞ��~
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.instance.soundManager.bgm.ResumeBGM();  //BGM ����BGM�Đ�
    }
}
