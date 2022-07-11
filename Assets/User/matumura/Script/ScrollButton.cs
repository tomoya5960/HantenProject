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
        GeneralManager.instance.mapManager.selectStageNum--;
        Scroll2.GetComponent<Scroll>()._count--;
    }

    //���{�^������������X�N���[��
    public void Down()
    {
        GeneralManager.instance.mapManager.selectStageNum++;
        Scroll2.GetComponent<Scroll>()._count++;
    }

}
