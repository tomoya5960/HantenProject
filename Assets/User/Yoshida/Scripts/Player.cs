using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject player;

    int flg; // �t���O

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // �L�����ړ�
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(flg == 0)
            {
                Debug.Log("�i�񂾂�");
                this.transform.Translate(0, 1, 0);
                //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 100);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(flg == 0)
            {
                Debug.Log("�i�񂾂�");
                this.transform.Translate(0, -1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(flg == 0)
            {
                Debug.Log("�i�񂾂�");
                this.transform.Translate(-1, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (flg == 0)
            {
                Debug.Log("�i�񂾂�");
                this.transform.Translate(1, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ǂɓ����������~
        if (collision.gameObject.tag == "Wall")
        {
            flg = 1;
        }
        
    }

}
