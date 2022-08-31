using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BeforeBack : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            onBack();
        }
    }

    public void onBack()
    {
        if (GeneralManager.Instance.isPlay && !StageManager.Instance.isPlayerMove)
        {
            GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_08);
            StageManager.Instance.mapManager.LoadTurnData();
        }

    }
}
