using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //�Đ�

        if (Input.GetKeyDown(KeyCode.Q))
            GeneralManager.Instance.SoundM.bgm.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GeneralManager.Instance.SoundM.se.PlaySE(SE.SeName.se_02);   //SE

        //��~
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.Instance.SoundM.bgm.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.Instance.SoundM.se.StopSE();       //SE

        //�ꎞ��~/�ĊJ
        if (Input.GetKeyDown(KeyCode.E))
            GeneralManager.Instance.SoundM.bgm.MuteBGM();    //BGM �ꎞ��~
        if (Input.GetKeyDown(KeyCode.R))
            GeneralManager.Instance.SoundM.bgm.ResumeBGM();  //BGM ����BGM�Đ�
    }
}
