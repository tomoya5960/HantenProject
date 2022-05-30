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
        GeneralManager.Instance.stageManager = GameObject.Find("GenenalManager").GetComponent<StageManager>();
        GeneralManager.Instance.stageManager.stageTurnCount = stageTurnCount;
    }
    private void Update()
    {

        #region 仮テスト用　適当に消してくれーい
        if (Input.GetKeyDown(KeyCode.A))
        {
            test.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            test2.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            test3.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            test4.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            test5.GetComponent<TileMaster>().TurnImage();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            test6.GetComponent<TileMaster>().TurnImage();
        }
        #endregion
    }
}
