using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	Vector3 MOVEX = new Vector3(130, 0, 0); // x軸方向に１マス移動するときの距離
	Vector3 MOVEY = new Vector3(0, 130, 0); // y軸方向に１マス移動するときの距離

	float step = 300;     // 移動速度
	Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
	Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

	Animator animator;   // アニメーション

	void Start()
	{
		target = transform.position;
		animator = GetComponent<Animator>();
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
	}

	// ② 入力に応じて移動後の位置を算出
	void SetTargetPosition()
	{

		prevPos = target;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			target = transform.position + MOVEX;
			SetAnimationParam(1);
			return;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			target = transform.position - MOVEX;
			SetAnimationParam(2);
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
			SetAnimationParam(0);
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
}


// MapManagerから壁かどうか見る判定を持ってくる
// ゴール判定を作る
// アニメーション組み込み




/*
// Start is called before the first frame update
void Start()
{

}

// Update is called once per frame
void Update()
{
    Move();
}

void Move()
{
    if (Input.GetKeyDown(KeyCode.W))
    {
        this.transform.position += new Vector3(0, 130, 0);
    }
    if (Input.GetKeyDown(KeyCode.S))
    {
        this.transform.position += new Vector3(0, -130, 0);
    }
    if (Input.GetKeyDown(KeyCode.A))
    {
        this.transform.position += new Vector3(-130, 0, 0);
    }
    if (Input.GetKeyDown(KeyCode.D))
    {
        this.transform.position += new Vector3(130, 0, 0);
    }
}
*/
