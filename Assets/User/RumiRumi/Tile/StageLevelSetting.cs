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
            test.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            test2.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            test3.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            test4.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            test5.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            test6.GetComponent<TileMaster>().TurnImage();
        }
        #endregion
    }
}
