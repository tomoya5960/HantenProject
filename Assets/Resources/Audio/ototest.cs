using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ototest : MonoBehaviour
{

    void Update()
    {
        //�Đ�

        if (Input.GetKeyDown(KeyCode.Q))
            GameManager.instance.soundManager.bgm.PlayBGM(0);    //BGM
        if (Input.GetKeyDown(KeyCode.W))
            GameManager.instance.soundManager.se.PlaySE(SE.SeName.Se002);   //SE

        //��~
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.instance.soundManager.bgm.StopBGM();
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.instance.soundManager.se.StopSE();       //SE

        //�ꎞ��~/�ĊJ
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.instance.soundManager.bgm.MuteBGM();    //BGM �ꎞ��~
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.instance.soundManager.bgm.ResumeBGM();  //BGM ����BGM�Đ�
    }
}
