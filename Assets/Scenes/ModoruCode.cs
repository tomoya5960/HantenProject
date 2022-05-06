using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModoruCode : MonoBehaviour
{

    public bool Name = false;
    public void Retry()
    {
        Debug.Log("c");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (Name == false)
            {
                Debug.Log("d");
                Name = true;
            }
        }
    }

}