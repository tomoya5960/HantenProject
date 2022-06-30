using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    //public GameObject gameObject;

    

    // Start is called before the first frame update
    void Start()
    {
        //ropeを取得
       // gameObject = GameObject.Find("Rope");

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // これでプレイヤーがロープに触ったら消えるはずなんだけど消えないなんで
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("触ったよ");
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