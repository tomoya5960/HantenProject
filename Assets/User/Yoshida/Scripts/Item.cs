using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    //public GameObject gameObject;

    

    // Start is called before the first frame update
    void Start()
    {
        //rope���擾
       // gameObject = GameObject.Find("Rope");

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ����Ńv���C���[�����[�v�ɐG�����������͂��Ȃ񂾂��Ǐ����Ȃ��Ȃ��
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("�G������");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {

    }
}
/*
Vector3 posi = this.transform.position;
Vector3 RopePosi = gameObject.transform.position;
if (posi == RopePosi)
{
    Destroy(gameObject);
}
*/