using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HantensuuUI : MonoBehaviour
{
    public List<GameObject> _hantenUI = new List<GameObject>();
    private int _hantensuu;
    [HideInInspector]
    public int hantensuu
    {
        get { return _hantensuu; }
        set
        {
            _hantensuu = value;
            switch (_hantensuu)
            {
                case 0:
                    activeUI(5);
                    break;
                case 1:
                    activeUI(4);
                    break;
                case 2:
                    activeUI(3);
                    break;
                case 3:
                    activeUI(2);
                    break;
                case 4:
                    activeUI(1);
                    break;
                case 5:
                    activeUI(0);
                    break;
            }
        }
    }
    private void Start()
    {
        GeneralManager.instance.mapManager.HantenUI = gameObject;
        hantensuu = GeneralManager.instance.mapManager.stageTurnCount;
    }

    private void activeUI(int hantensuu)
    {
        for (int num = 0; num <= 4; num++)
        {
            _hantenUI[num].transform.GetChild(0).gameObject.SetActive(true);
        }

        for (int num = 4; num >= hantensuu; num--)
        {
            _hantenUI[num].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
