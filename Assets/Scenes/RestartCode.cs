using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCode : MonoBehaviour
{

    public bool Name = false;
    public void Retry()
    {
        Debug.Log("a");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (Name == false)
            {
                Debug.Log("b");
                Name = true;
            }
        }
    }

}