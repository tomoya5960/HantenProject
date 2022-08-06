using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Scroll2;

    //��{�^������������X�N���[��
    public void Up()
    {
        Scroll2.GetComponent<Scroll>()._count--;
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_03);
    }

    //���{�^������������X�N���[��
    public void Down()
    {
        Scroll2.GetComponent<Scroll>()._count++;
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_03);
    }

}
