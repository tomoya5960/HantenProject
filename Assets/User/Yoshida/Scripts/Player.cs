using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 lastPosition = default;
    private Rigidbody2D rb = null;

    private bool col;
    private bool lastCol;
    private bool lastlastCol;

    private bool moved = false;

    /*
    private Rigidbody2D rb = null;
    public float speed = 5;

    void FixedUpdate()
    {
        Rigidbody2DSetup();//①のメソッドを呼び出し
        ArrowKeyMove(); //②のメソッドを呼び出し
    }

    void Update()
    {
        MoveForward1Space();//③のメソッドを呼び出し
    }


    //----------------メソッド----------------

    void Rigidbody2DSetup() //①Rigidbody2Dの初期化を行うメソッド
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void ArrowKeyMove() //②矢印キーの入力を行うメソッド
    {
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.RightArrow)) { moveX = speed; }
        if (Input.GetKey(KeyCode.LeftArrow)) { moveX = -speed; }
        if (Input.GetKey(KeyCode.UpArrow)) { moveY = speed; }
        if (Input.GetKey(KeyCode.DownArrow)) { moveY = -speed; }
        rb.velocity = new Vector2(moveX, moveY);
    }

    void MoveForward1Space()　//③矢印キーの入力後、位置を整数値に置きなおすメソッド
    {
        Vector3 pos = this.transform.position;
        float correction = 0.4f;

        if (Input.GetKeyUp(KeyCode.RightArrow) | Input.GetKeyUp(KeyCode.UpArrow))
        {
            pos.x = Mathf.Round(pos.x + correction);
            pos.y = Mathf.Round(pos.y + correction);
            pos.z = Mathf.Round(pos.z + correction);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) | Input.GetKeyUp(KeyCode.DownArrow))
        {
            pos.x = Mathf.Round(pos.x - correction);
            pos.y = Mathf.Round(pos.y - correction);
            pos.z = Mathf.Round(pos.z - correction);
        }
        transform.position = pos;
    }
    */
    void Start()
    {
        lastPosition = this.transform.localPosition;
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveForward1Space();//③のメソッドを呼び出し

        //3フレームぐらい、Colしてなければ、LastPositionを更新する

        if (moved == false && col == false && lastCol == false && lastlastCol == false)
        {
            lastPosition = this.transform.localPosition;
        }

        lastlastCol = lastCol;
        lastCol = col;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        this.transform.localPosition = lastPosition;
        moved = false;
        col = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
            
        col = false;
    } 

    void MoveForward1Space()　//③矢印キーの入力後、位置を整数値に置きなおすメソッド
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //右
            this.transform.localPosition = new Vector2(this.transform.localPosition.x + 1, this.transform.localPosition.y);
            moved = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //上
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y + 1);
            moved = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //左
            this.transform.localPosition = new Vector2(this.transform.localPosition.x - 1, this.transform.localPosition.y);
            moved = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //下
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y - 1);
            moved = true;
        }
    }
    //----------------メソッドここまで----------------
}
