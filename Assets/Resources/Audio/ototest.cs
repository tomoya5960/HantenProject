using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{
    void Update()
    {
        //�Đ�
        if(Input.GetKeyDown(KeyCode.Q))
            GameManager.instance.soundManager.PlayBGM(SoundManager.BgmType.BgmTest);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GameManager.instance.soundManager.PlaySE(SoundManager.SeType.SeTest);       //SE

        //��~
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.instance.soundManager.StopBGM();    //BGM
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.instance.soundManager.StopSE();       //SE

        //�ꎞ��~/�ĊJ
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.instance.soundManager.MuteBGM();    //BGM �ꎞ��~
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.instance.soundManager.ResumeBGM();  //BGM ����BGM�Đ�




    }
}
