using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MenuNotActive : MonoBehaviour
{
    [SerializeField] GameObject text;

    void Update()
    {
        //キーを押す
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ゲームオブジェクト非表示→表示
            text.SetActive(true);
        }
    }
}