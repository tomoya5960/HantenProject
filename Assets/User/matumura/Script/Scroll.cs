using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public GameObject Master1;
    public GameObject Master2;
    public GameObject Master3;
    public GameObject Master4;

    [SerializeField]
    private float speed;

    [SerializeField]
    public int _count;

    private float step;

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
        _count -= (int)wh;

        //ストッパー
        if (_count <= 0)
            _count = 1;
        if (_count >= 4)
            _count = 3;


        if (_count == 1)
        {
            //Debug.Log("move1");
            moveM.y = -425;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Master1.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            Master2.transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.instance.mapManager.selectStageNum = _count-1;
        }
        if (_count == 2)
        {
            //Debug.Log("move2");
            moveM.y = -25;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Master1.transform.localScale = new Vector3(1, 1, 1);
            Master2.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            Master3.transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.instance.mapManager.selectStageNum = _count -1;
        }
        if (_count == 3)
        {
            //Debug.Log("move3");
            moveM.y = 375;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Master2.transform.localScale = new Vector3(1, 1, 1);
            Master3.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            Master4.transform.localScale = new Vector3(1, 1, 1);
            GeneralManager.instance.mapManager.selectStageNum = _count - 1;
        }
        if (_count == 4)
        {
            //Debug.Log("move4");
            moveM.y = 775;
            transform.position = Vector3.MoveTowards(transform.position, moveM, step);
            Master3.transform.localScale = new Vector3(1, 1, 1);
            Master4.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            GeneralManager.instance.mapManager.selectStageNum = _count - 1;
        }
    }



}
