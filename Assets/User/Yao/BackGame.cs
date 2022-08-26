using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGame : MonoBehaviour
{
    public MenuButton menuButton;

    public void OnBackGame()
    {
        menuButton.Name = false;
        gameObject.transform.parent.gameObject.SetActive(false);
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_04);
        GeneralManager.Instance.isPlay = true;
        GeneralManager.Instance.soundManager.ResumeBGM();
    }
}
