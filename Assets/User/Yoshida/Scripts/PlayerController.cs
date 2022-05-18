using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{

	public bool ItemGet = false;
	[SerializeField] TileMapController TileMap;

	Vector3 MOVEX = new Vector3(0.96f, 0, 0); // x�������ɂP�}�X�ړ�����Ƃ��̋���
	Vector3 MOVEY = new Vector3(0, 0.96f, 0); // y�������ɂP�}�X�ړ�����Ƃ��̋���

	float step = 4f;     // �ړ����x
	Vector3 target;      // ���͎�t���A�ړ���̈ʒu���Z�o���ĕۑ� 
	Vector3 prevPos;     // ���炩�̗��R�ňړ��ł��Ȃ������ꍇ�A���̈ʒu�ɖ߂����߈ړ��O�̈ʒu��ۑ�

	//Animator animator;   // �A�j���[�V����


	// Use this for initialization
	void Start()
	{
		target = transform.position;
		//animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

		// �@ �ړ������ǂ����̔���B�ړ����łȂ���Γ��͂���t
		if (transform.position == target)
		{
			SetTargetPosition();
		}
		Move();

		TileMapController.instance.CheckCloseDoor(transform.position);
	}

	// �A ���͂ɉ����Ĉړ���̈ʒu���Z�o
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

	// WalkParam  0;���ړ��@1;�E�ړ��@2:���ړ��@3:��ړ�
	void SetAnimationParam(int param)
	{
		//animator.SetInteger("WalkParam", param);
	}

	// �B �ړI�n�ֈړ�����
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