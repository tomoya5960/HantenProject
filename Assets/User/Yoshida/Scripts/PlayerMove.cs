using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

	// script��MapManager���擾
	[SerializeField] MapManager MapManager;

	Vector3 MOVEX = new Vector3(130, 0, 0); // x�������ɂP�}�X�ړ�����Ƃ��̋���
	Vector3 MOVEY = new Vector3(0, 130, 0); // y�������ɂP�}�X�ړ�����Ƃ��̋���

	float step = 300;     // �ړ����x
	Vector3 target;      // ���͎�t���A�ړ���̈ʒu���Z�o���ĕۑ� 
	Vector3 prevPos;     // ���炩�̗��R�ňړ��ł��Ȃ������ꍇ�A���̈ʒu�ɖ߂����߈ړ��O�̈ʒu��ۑ�


	void Start()
	{
		target = transform.position;

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
			// ���Ԃ񂱂���MapManager��Move()�����������Ă���񂾂��ǂȂ�����肭���������Ă���Ȃ�
			//MapManager.Move();
			target = transform.position + MOVEX;
			return;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			target = transform.position - MOVEX;
			return;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			target = transform.position + MOVEY;
			return;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			target = transform.position - MOVEY;
			return;
		}
	}

	// �B �ړI�n�ֈړ�����
	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
	}


	//�ꉞ�S�[���ɐG������ʂ̃V�[���ɔ�Ԃ悤�ɐݒ肵�����ǂǂ̂悤�ɔ���Ƃ�΂������킩��Ȃ��Ă����̕��@�����m��Ȃ��I���^
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Goal")
		{
			Debug.Log("�G������");
			SceneManager.LoadScene("StageScene");
		}
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
