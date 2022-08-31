using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public bool Name = false;
    public GameObject Other;
    public GameObject Menu1;

    public void MenuOnOff()
    {
        if (GeneralManager.Instance.isPlay)
        {
            if (Name == false)
            {
                Name = true;
                    Other.GetComponent<TurnTile>().enabled = false;
                    GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                    GeneralManager.Instance.isPlay = false;
                    GeneralManager.Instance.soundManager.MuteBGM();
            }
            else if (Name == true)
            {
                Name = false;
                Other.GetComponent<TurnTile>().enabled = true;
                GeneralManager.Instance.isPlay = true;
                GeneralManager.Instance.soundManager.ResumeBGM();
            }

            Menu1.SetActive(Name);
        }
    }
}
