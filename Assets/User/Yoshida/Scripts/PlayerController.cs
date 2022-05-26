using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerController : MonoBehaviour
{

	private Rigidbody2D rb = null;
	public bool ItemGet = false;

	int  speed = 50;

	Vector3 MOVEX = new Vector3(100f, 0, 0); // x�������ɂP�}�X�ړ�����Ƃ��̋���
	Vector3 MOVEY = new Vector3(0, 100f, 0); // y�������ɂP�}�X�ړ�����Ƃ��̋���

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
		Rigidbody2DSetup();
		// �@ �ړ������ǂ����̔���B�ړ����łȂ���Γ��͂���t
		if (transform.position == target)
		{
			SetTargetPosition();
		}
		Move();

		//TileMapController.instance.CheckCloseDoor(transform.position);
	}
	void Rigidbody2DSetup() //�@Rigidbody2D�̏��������s�����\�b�h
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;

	}

	// �A ���͂ɉ����Ĉړ���̈ʒu���Z�o
	void SetTargetPosition()
	{

		

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

		prevPos = target;
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