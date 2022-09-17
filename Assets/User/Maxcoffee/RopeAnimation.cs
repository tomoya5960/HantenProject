using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�p�l���̃C���[�W�𑀍삷��̂ɕK�v

public class RopeAnimation : MonoBehaviour
{
	//--------------------------------------
	private float startTime, distance;
	private Vector3 startPosition, targetPosition;
	//-------------------------------------------
	private int num = 1;
	[SerializeField]
	private float fadeSpeed = 1f;        //�����x���ς��X�s�[�h���Ǘ�
	float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�
	SpriteRenderer fadeSp;                //�����x��ύX����p�l���̃C���[�W


	void Start()
	{
		fadeSp = GetComponent<SpriteRenderer>();
		red = fadeSp.color.r;
		green = fadeSp.color.g;
		blue = fadeSp.color.b;
		alfa = fadeSp.color.a;

		//�X�^�[�g���Ԃ��L���b�V��
		startTime = Time.time;
		//�X�^�[�g�ʒu���L���b�V��
		startPosition = transform.localPosition;
		//�����n�_���Z�b�g
		targetPosition = new Vector3(0, 150, 0);
		//�ړI�n�܂ł̋��������߂�
		distance = Vector3.Distance(startPosition, targetPosition);
	}

	void Update()
	{

		switch (num)
		{
			case 1:
				StartFadeOut();
				//---------------------------------------------------------------------
				float interpolatedValue = (Time.time - startTime) / distance;
				transform.position = Vector3.Lerp(startPosition, targetPosition, interpolatedValue);
				//---------------------------------------------------------------------------
				break;
			case 2:
				StartFadeIn();
				break;
			case 3:
				gameObject.SetActive(false);
				Destroy(gameObject);
				break;
		}
	}

    void StartFadeIn()
	{
		alfa -= fadeSpeed;                //a)�s�����x�����X�ɉ�����
		SetAlpha();                      //b)�ύX�����s�����x�p�l���ɔ��f����
		if (alfa <= 0)
		{                    //c)���S�ɓ����ɂȂ����珈���𔲂���
			fadeSp.enabled = false;    //d)�p�l���̕\�����I�t�ɂ���
			num++;
		}
		
	}

	void StartFadeOut()
	{

		fadeSp.enabled = true;  // a)�p�l���̕\�����I���ɂ���
		alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
		SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
		if (alfa >= 1)
		{
			transform.Translate(0f, 1f, 0f);
			num++;
		}
		
	}

	void SetAlpha()
	{
		transform.Translate(0f, 1f, 0f);
		fadeSp.color = new Color(red, green, blue, alfa);
	}
}