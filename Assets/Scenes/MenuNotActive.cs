using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MenuNotActive : MonoBehaviour
{
    [SerializeField] GameObject text;

    void Update()
    {
        //�L�[������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //�Q�[���I�u�W�F�N�g��\�����\��
            text.SetActive(true);
        }
    }
}