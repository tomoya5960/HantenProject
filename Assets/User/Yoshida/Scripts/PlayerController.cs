using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{

	private Rigidbody2D rb = null;
	public bool ItemGet = false;

	Vector3 MOVEX = new Vector3(0.96f, 0, 0); // x軸方向に１マス移動するときの距離
	Vector3 MOVEY = new Vector3(0, 0.96f, 0); // y軸方向に１マス移動するときの距離

	float step = 4f;     // 移動速度
	Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
	Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

	//Animator animator;   // アニメーション


	// Use this for initialization
	void Start()
	{
		target = transform.position;
		//animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		Rigidbody2DSetup();
		//MoveForward1Space();
		// ① 移動中かどうかの判定。移動中でなければ入力を受付
		if (transform.position == target)
		{
			SetTargetPosition();
		}
		Move();

		//TileMapController.instance.CheckCloseDoor(transform.position);
	}
	void Rigidbody2DSetup() //①Rigidbody2Dの初期化を行うメソッド
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;

	}

	// ② 入力に応じて移動後の位置を算出
	void SetTargetPosition()
	{

		prevPos = target;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			target = transform.position + MOVEX;
			SetAnimationParam(3);
			return;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			target = transform.position - MOVEX;
			SetAnimationParam(3);
			return;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			target = transform.position + MOVEY;
			SetAnimationParam(3);
			return;

		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			target = transform.position - MOVEY;
			SetAnimationParam(3);
			return;
		}
	}

	// WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
	void SetAnimationParam(int param)
	{
		//animator.SetInteger("WalkParam", param);
	}

	// ③ 目的地へ移動する
	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
	}

	/*
	void MoveForward1Space() //③矢印キーの入力後、位置を整数値に置きなおすメソッド
	{
		Vector3 pos = this.transform.position;
		float correction = 0.4f;

		if (Input.GetKeyUp(KeyCode.RightArrow) | Input.GetKeyUp(KeyCode.UpArrow))
		{
			pos.x = Mathf.Round(pos.x + correction);
			pos.y = Mathf.Round(pos.y + correction);
			pos.z = Mathf.Round(pos.z + correction);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow) | Input.GetKeyUp(KeyCode.DownArrow))
		{
			pos.x = Mathf.Round(pos.x - correction);
			pos.y = Mathf.Round(pos.y - correction);
			pos.z = Mathf.Round(pos.z - correction);
		}
		transform.position = pos;
	}
	*/


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Item")
		{
			ItemGet = true;
		}
	}
}