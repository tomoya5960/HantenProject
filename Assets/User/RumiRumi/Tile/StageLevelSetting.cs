using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLevelSetting : MonoBehaviour
{
    public List<int> stageTurnCount = new List<int>();
    void Start()
    {
        GeneralManager.instance.mapManager.TurnNum = 0;
        GeneralManager.instance.mapManager.stageTurnCount = stageTurnCount[GeneralManager.instance.mapManager.selectStageNum];
    }
}
