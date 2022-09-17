using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarView : MonoBehaviour
{
    [SerializeField, Tooltip("���̍ő�l")] private int MaxStarValue = 6;
    [SerializeField, Tooltip("��Փx�̒l")] private int StarValue = 0;

    private Text text;

    void Start()
    {
        //������
        text = this.GetComponent<Text>();
        //����text���X�V
        text.text = returnStar();
    }
    /// <summary>
    /// ����Ɂ���t���Ă�����I
    /// </summary>
    /// <returns></returns>
    string returnStar()
    {
        int NowStar = 0;
        string startext = "";
        for (int i = 0; i < MaxStarValue; i++)
        {
            if (NowStar < StarValue)
            {
                NowStar++;
                startext += "��";
            }
            else
            {
                //�Z�擪��text��}������
                startext = startext.Insert(0, "��");
            }
        }

        return startext;
    }

}
