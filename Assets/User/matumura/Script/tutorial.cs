using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    private bool masasi = false;
    public GameObject matumura;
    [SerializeField]private GameObject obj;
    [SerializeField] private GameObject makimono;
    private bool start= false;
    void Start()
    {
        if (GeneralManager.Instance.selectStageNum != 0) GetComponent<tutorial>().enabled  = false;
        if (GeneralManager.Instance.selectStageNum == 0)
        {
            obj = Instantiate(matumura, new Vector3(0.0f,0.0f, 0.0f), Quaternion.identity);
            masasi = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))// || Input.GetMouseButton(0))
        {
            if (masasi)
            {
                masasi=false;
                GeneralManager.Instance.isPlay = true;
            }
            else
            {
                masasi =(true);
                GeneralManager.Instance.isPlay = false;
                makimono.SetActive(true);
                if (!start)
                {
                    start = true;
                    makimono.GetComponent<StageNameLogo>().callCoroutine();
                }
            }

            GeneralManager.Instance.isPlay = masasi;
            obj.SetActive(!masasi);
        }

    }
}
