using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HantensuuUI : MonoBehaviour
{
    public  List<GameObject> _hantenUI = new List<GameObject>();
    private int              _hantensuu;
    public int hantensuu
    {
        get { return _hantensuu; }
        set
        {
            _hantensuu = value;
            switch (_hantensuu)
            {
                case 0:
                    ActiveUI(5);
                    break;
                case 1:
                    ActiveUI(4);
                    break;
                case 2:
                    ActiveUI(3);
                    break;
                case 3:
                    ActiveUI(2);
                    break;
                case 4:
                    ActiveUI(1);
                    break;
                case 5:
                    ActiveUI(0);
                    break;
            }
        }
    }

    private void ActiveUI(int hantensuu)
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
