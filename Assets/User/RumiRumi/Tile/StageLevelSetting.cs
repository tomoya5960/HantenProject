using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLevelSetting : MonoBehaviour
{
    public List<int> stageTurnCount = new List<int>();

    //仮テスト用　適当に消してくれーい
    public GameObject test;
    public GameObject test2;
    public GameObject test3;
    public GameObject test4;
    public GameObject test5;
    public GameObject test6;
    //---------------------------

    void Awake()
    {
        GeneralManager.instance.mapManager.TurnNum = 0;
        GeneralManager.instance.mapManager.stageTurnCount = stageTurnCount[GeneralManager.instance.mapManager.selectStageNum];
    }

    private void Update()
    {

        #region 仮テスト用　適当に消してくれーい

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GeneralManager.instance.mapManager.stageTurnCount > 0)
            {
                test.GetComponent<TileMaster>().TurnImage();
                GeneralManager.instance.mapManager.stageTurnCount--;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (GeneralManager.instance.mapManager.stageTurnCount > 0)
            {
                test2.GetComponent<TileMaster>().TurnImage();
                GeneralManager.instance.mapManager.stageTurnCount--;
            }

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GeneralManager.instance.mapManager.stageTurnCount > 0)
            {
                test3.GetComponent<TileMaster>().TurnImage();
                GeneralManager.instance.mapManager.stageTurnCount--;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (GeneralManager.instance.mapManager.stageTurnCount > 0)
            {
                test4.GetComponent<TileMaster>().TurnImage();
                GeneralManager.instance.mapManager.stageTurnCount--;
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (GeneralManager.instance.mapManager.stageTurnCount > 0)
            {
                test5.GetComponent<TileMaster>().TurnImage();
                GeneralManager.instance.mapManager.stageTurnCount--;
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (GeneralManager.instance.mapManager.stageTurnCount > 0)
            {
                test6.GetComponent<TileMaster>().TurnImage();
                GeneralManager.instance.mapManager.stageTurnCount--;
            }
        }
        #endregion
    }
}
