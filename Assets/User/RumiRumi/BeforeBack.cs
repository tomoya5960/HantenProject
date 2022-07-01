using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBack : MonoBehaviour
{
    public void onBack()
    {
        GeneralManager.instance.mapManager.LoadBeforeStageData();
    }
}
