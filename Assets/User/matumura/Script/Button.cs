using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject Scroll2;

    //��{�^������������X�N���[��
    public void Up()
    {
        Scroll2.GetComponent<Scroll>()._count--;
    }

    //���{�^������������X�N���[��
    public void Down()
    {
        Scroll2.GetComponent<Scroll>()._count++;
    }

}
