using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    //これはステージ選択のブロックリスト
    [SerializeField]
    private List<GameObject> Masterlist = new List<GameObject>();

    //スクロール速度
    [SerializeField]
    private float speed;

    //選択されてるステージ番号
    [SerializeField]
    public int _count;

    private float step;
    [SerializeField]
    private float scale = 0;
    private Vector3 moveM;
    // Start is called before
    //the first frame update
    void Start()
    {
        moveM = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;


        //マウスホイール動作
        var wh = Input.GetAxis("Mouse ScrollWheel") * 10;
        if (_count != _count - wh)
        {
            GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_03);
            _count -= (int)wh;
        }

        //ストッパー
        if (_count <= 0)
            _count = 1;
        if (_count > Masterlist.Count)
            _count = Masterlist.Count;


        if (_count == 1)
        {
            moveM.y = -425;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[0].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[1].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 2)
        {
            moveM.y = -25;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[0].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[1].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[2].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 3)
        {
            moveM.y = 375;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[1].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[2].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[3].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 4)
        {
            moveM.y = 775;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[2].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[3].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[4].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 5)
        {
            moveM.y = 1175;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[3].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[4].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[5].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 6)
        {
            moveM.y = 1575;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[4].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[5].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[6].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 7)
        {
            moveM.y = 1975;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[5].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[6].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[7].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 8)
        {
            moveM.y = 2375;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[6].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[7].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[8].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 9)
        {
            moveM.y = 2775;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[7].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[8].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[9].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 10)
        {
            moveM.y = 3175;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[8].transform.localScale = new Vector3(1, 1, 1);
            Masterlist[9].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[10].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }
        if (_count == 11)
        {
            moveM.y = 3575;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Masterlist[10].transform.localScale = new Vector3(scale, scale, 1);
            Masterlist[9].transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.Instance.selectStageNum = _count - 1;
        }

        #region ４７～８０行目を短く書くとこうなる　参考程度に
        /*
        switch (_count)
        {
            case 1:
                test(-425);
                break;
            case 2:
                test(-25);
                break;
            case 3:
                test(375);
                break;
            case 4:
                test(775);
                break;
        }
            private void test(int y)
    {
        moveM.y = y;
        transform.position = Vector3.MoveTowards(transform.position, moveM, step);
        Master4.transform.localScale = new Vector3(1, 1, 1);
        Master5.transform.localScale = new Vector3(1.3f, 1.3f, 1);
        GeneralManager.Instance.selectStageNum = _count - 1;
    }
        */
        #endregion
    }

}
