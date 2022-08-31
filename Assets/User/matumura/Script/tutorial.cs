using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    private bool masasi = false;
    public GameObject matumura;
    [SerializeField]private GameObject obj;
    void Start()
    {
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
            }

            obj.SetActive(masasi);
        }

    }
}
