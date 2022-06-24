using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	Vector3 MOVEX = new Vector3(130, 0, 0); // x�������ɂP�}�X�ړ�����Ƃ��̋���
	Vector3 MOVEY = new Vector3(0, 130, 0); // y�������ɂP�}�X�ړ�����Ƃ��̋���

	float step = 300;     // �ړ����x
	Vector3 target;      // ���͎�t���A�ړ���̈ʒu���Z�o���ĕۑ� 
	Vector3 prevPos;     // ���炩�̗��R�ňړ��ł��Ȃ������ꍇ�A���̈ʒu�ɖ߂����߈ړ��O�̈ʒu��ۑ�

	Animator animator;   // �A�j���[�V����

	void Start()
	{
		target = transform.position;
		animator = GetComponent<Animator>();
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
	}

	// �A ���͂ɉ����Ĉړ���̈ʒu���Z�o
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
}


// MapManager����ǂ��ǂ������锻��������Ă���
// �S�[����������
// �A�j���[�V�����g�ݍ���




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
