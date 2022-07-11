using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Scroll2;

    //上ボタンを押したらスクロール
    public void Up()
    {
        GeneralManager.instance.mapManager.selectStageNum--;
        Scroll2.GetComponent<Scroll>()._count--;
    }

    //下ボタンを押したらスクロール
    public void Down()
    {
        GeneralManager.instance.mapManager.selectStageNum++;
        Scroll2.GetComponent<Scroll>()._count++;
    }

}
