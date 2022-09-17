using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public bool Name = false;
    public GameObject Other;

    public void MenuOnOff()
    {
        if (GeneralManager.Instance.isPlay)
        {
            if (Name == false)
            {
                Name = true;
                
                Other.GetComponent<MenuImage>().OpenMenuBota();
                GeneralManager.Instance.isPlay = false;

            }
            else if (Name == true)
            {
                Name = false;
                Other.GetComponent<TurnTile>().enabled = true;
                Other.GetComponent<MenuImage>().CloseMenuBota();

            }
        }
    }
}
