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
        Scroll2.GetComponent<Scroll>()._count--;
        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_03);
    }

    //下ボタンを押したらスクロール
    public void Down()
    {
        Scroll2.GetComponent<Scroll>()._count++;
        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_03);
    }

}
