using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HantenUI : MonoBehaviour
{
    public  List<GameObject> _hantenUI = new List<GameObject>();
    private int              _hantenNum;

    public int hantenNum
    {
        get { return _hantenNum; }
        set
        {
            _hantenNum = value;
            //表示するUI数を指定して反転UIの表示を変更する
            switch (_hantenNum)
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

    /// <summary>
    /// 反転数の変動に応じてUIを変更
    /// </summary>
    private void ActiveUI(int hantenNum)
    {
        for (int num = 0; num <= 4; num++)
        {
            _hantenUI[num].transform.GetChild(0).gameObject.SetActive(true);
        }

        for (int num = 4; num >= hantenNum; num--)
        {
            _hantenUI[num].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    
}
