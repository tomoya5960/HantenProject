using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool Name = false;

    public GameObject Menu1;

    public void Retry()
    {
        Debug.Log("c");
    }
    public void Restart()
    {
        Debug.Log("a");
    }

    public void MenuOn()
    {
        Menu1.SetActive(true);

        Debug.Log("b");
    }

    public void MenuOff()
    {
        Menu1.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Name == false)
            {
                Debug.Log("d");
                Name = true;
            }
        }


    }

}
