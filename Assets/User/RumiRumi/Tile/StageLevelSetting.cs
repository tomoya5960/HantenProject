using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLevelSetting : MonoBehaviour
{
    public int stageTurnCount;

    //仮テスト用　適当に消してくれーい
    public GameObject test;
    public GameObject test2;
    public GameObject test3;
    public GameObject test4;
    public GameObject test5;
    public GameObject test6;
    //---------------------------

    private void Start()
    {
        GeneralManager.instance.mapManager = GameObject.Find("GenenalManager").GetComponent<MapManager>();
        GeneralManager.instance.mapManager.stageTurnCount = stageTurnCount;
    }
    private void Update()
    {

        #region 仮テスト用　適当に消してくれーい
        if (Input.GetKeyDown(KeyCode.Z))
        {
            test.GetComponent<TileMaster>().TurnImage();
            GeneralManager.instance.mapManager.SetBeforeStageData();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            test2.GetComponent<TileMaster>().TurnImage();
            GeneralManager.instance.mapManager.SetBeforeStageData();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            test3.GetComponent<TileMaster>().TurnImage();
            GeneralManager.instance.mapManager.SetBeforeStageData();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            test4.GetComponent<TileMaster>().TurnImage();
            GeneralManager.instance.mapManager.SetBeforeStageData();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            test5.GetComponent<TileMaster>().TurnImage();
            GeneralManager.instance.mapManager.SetBeforeStageData();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            test6.GetComponent<TileMaster>().TurnImage();
            GeneralManager.instance.mapManager.SetBeforeStageData();
        }
        #endregion
    }
}
