using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public bool Name = false;

    public GameObject Menu1;

<<<<<<< HEAD
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

=======
    public void MenuOnOff()
    {
        if (Name == false)
        {
            if (GeneralManager.instance.isEnablePlay)
            {
                Name = true;
                GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                GeneralManager.instance.isEnablePlay = false;
                GeneralManager.instance.soundManager.MuteBGM();
            }
        }
        else if (Name == true)
        {
            Name = false;
            GeneralManager.instance.isEnablePlay = true;
            GeneralManager.instance.soundManager.ResumeBGM();
        }
        Menu1.SetActive(Name);

    }
>>>>>>> Main
}
