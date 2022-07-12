using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public bool Name = false;

    public GameObject Menu1;

    public void MenuOnOff()
    {
        if (GeneralManager.instance.isEnablePlay)
        {
            if (Name == false)
            {
                Name = true;
                GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                GeneralManager.instance.isEnablePlay = false;
            }
            else
            {
                Name = false;
                GeneralManager.instance.isEnablePlay = true;
            }
            Menu1.SetActive(Name);
        }
    }
}
