using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{

	public float fadeSpeed = 0.003f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理
	[HideInInspector]
	public bool onof = false;
	[HideInInspector]
	public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

	Image fadeImage;                //透明度を変更するパネルのイメージ

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
			isFadeIn = true;
		}
		if (isFadeIn)
		{
			StartFadeIn();
		}
	}

	void StartFadeIn()
	{
		alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
		SetAlpha();                      //b)変更した不透明度パネルに反映する
		if (alfa <= 0)
		{                    //c)完全に透明になったら処理を抜ける
			isFadeIn = false;
			fadeImage.enabled = false;//d)パネルの表示をオフにする
			onof = false;
		}
	}
	void SetAlpha()
	{
		fadeImage.color = new Color(red, green, blue, alfa);
	}
}