using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNameUI : MonoBehaviour
{
    [SerializeField] private Text   _text;
    
                     private string _stageName; //ステージ名が入る


     private void OnEnable()
     {
         ChengeName();
     }

     private void ChengeName()
    {
    //チュートリアル？
    if (GeneralManager.Instance.selectStageNum == 0) _stageName = "チュートリアル";
    else
    {
        string stageNum = null;
        switch (GeneralManager.Instance.selectStageNum)
        {
            case 1:
                stageNum = "一";
                break;
            case 2:
                stageNum = "二";
                break;
            case 3:
                stageNum = "三";
                break;
            case 4:
                stageNum = "四";
                break;
            case 5:
                stageNum = "五";
                break;
            default:
                Debug.LogError("ステージ名UIでSelectStageNumが正しく取得できなかったよ♡");
                break;
        }
        _stageName = "第" + stageNum + "階層";
    }
    //名前の置き換え
    _text.text = _stageName;
    }
}
