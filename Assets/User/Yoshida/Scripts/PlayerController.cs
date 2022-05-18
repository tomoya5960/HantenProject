using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{

	public bool ItemGet = false;
	[SerializeField] TileMapController TileMap;

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

		// ① 移動中かどうかの判定。移動中でなければ入力を受付
		if (transform.position == target)
		{
			SetTargetPosition();
		}
		Move();

		TileMapController.instance.CheckCloseDoor(transform.position);
	}

	// ② 入力に応じて移動後の位置を算出
	void SetTargetPosition()
	{

		prevPos = target;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (TileMap.RightWall == false)
            {
				target = transform.position + MOVEX;
				SetAnimationParam(1);
				return;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if(TileMap.LeftWall == false)
            {
				target = transform.position - MOVEX;
				SetAnimationParam(2);
				return;
			}
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (TileMap.UpWall == false)
			{
				target = transform.position + MOVEY;
				SetAnimationParam(3);
				return;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			if (TileMap.DownWall == false)
			{
				target = transform.position - MOVEY;
				SetAnimationParam(4);
				return;
			}
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

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Item")
		{
			ItemGet = true;
		}
	}
}