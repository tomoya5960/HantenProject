using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public int èºë∫ = 0;
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



    /*
           switch (èºë∫)
           {
               case 0:
                   goj1.SetActive(true);
                   Time.timeScale = 0;
                   if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(0))
                   {
                       goj1.SetActive(false);
                       Time.timeScale = 1;
                       èºë∫++;
                   }
                   break;
               case 1:
                   Time.timeScale = 0;
                   if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                   {
                       Time.timeScale = 1;
                   }
                   break;
               case 2:
                   goj2.SetActive(true);
                   Time.timeScale = 0;
                   if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(0))
                   {
                       goj2.SetActive(false);
                       Time.timeScale = 1;
                       èºë∫++;
                   }
                   break;
               case 3:
                   // îΩì]ââèoÇÇ‡ÇÁÇ¡ÇƒÇ≠ÇÈ
                   break;
               case 4:
                   goj3.SetActive(true);
                   Time.timeScale = 0;
                   if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(0))
                   {
                       goj3.SetActive(false);
                       Time.timeScale = 1;
                       èºë∫++;
                   }
                   break;
               case 5:
                   // ÉçÅ[ÉvÇÃèàóùÇÇ‡ÇÁÇ¡ÇƒÇ≠ÇÈ
                   break;
               case 6:
                   goj4.SetActive(true);
                   Time.timeScale = 0;
                   if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(0))
                   {
                       goj4.SetActive(false);
                       Time.timeScale = 1;
                       èºë∫++;
                   }
                   break;
           }
           */
}
