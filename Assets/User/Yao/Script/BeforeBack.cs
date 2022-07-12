using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBack : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            onBack();
    }
    public void onBack()
    {
        if (GeneralManager.instance.isEnablePlay)
        {
            if (!GeneralManager.instance.mapManager.player.isPlayerMove)
            {
                GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_08);
                GeneralManager.instance.mapManager.OnOneBack();
            }
        }
    }
}
