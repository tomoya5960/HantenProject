using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBack : MonoBehaviour
{
    [HideInInspector]
    public PlayerManager manager;
    public void onBack()
    {
        if(!manager.isPlayerMove)
        GeneralManager.instance.mapManager.LoadBeforeStageData();
    }
}
