using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGame : MonoBehaviour
{
    public MenuButton menuButton;

    public void OnBackGame()
    {
        Debug.Log("a");
        menuButton.Name = false;
        gameObject.transform.parent.gameObject.SetActive(false);
        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
        GeneralManager.instance.isEnablePlay = true;
        GeneralManager.instance.soundManager.ResumeBGM();
    }
}
