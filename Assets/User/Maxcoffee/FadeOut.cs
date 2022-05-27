using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�p�l���̃C���[�W�𑀍삷��̂ɕK�v
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{

	public float fadeSpeed = 0.003f;        //�����x���ς��X�s�[�h���Ǘ�
	float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�
	[HideInInspector]
	public bool onof = false;
	[HideInInspector]
	public bool isFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O

	Image fadeImage;                //�����x��ύX����p�l���̃C���[�W

	void Start()
	{
		fadeImage = GetComponent<Image>();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
	}

	void Update()
	{
		onof = true;
		if (onof == true)
		{
			isFadeOut = true;
		}
		

		if (isFadeOut)
		{
			StartFadeOut();
		}
	}
	void StartFadeOut()
	{
		fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
		alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
		SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
		if (alfa >= 1)
		{             // d)���S�ɕs�����ɂȂ����珈���𔲂���
			isFadeOut = false;
			onof = false;
		}
	}

	void SetAlpha()
	{
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}