using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class RopeAnimation : MonoBehaviour
{
	//--------------------------------------
	private float startTime, distance;
	private Vector3 startPosition, targetPosition;
	//-------------------------------------------
	private int num = 1;
	[SerializeField]
	private float fadeSpeed = 1f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理
	SpriteRenderer fadeSp;                //透明度を変更するパネルのイメージ


	void Start()
	{
		fadeSp = GetComponent<SpriteRenderer>();
		red = fadeSp.color.r;
		green = fadeSp.color.g;
		blue = fadeSp.color.b;
		alfa = fadeSp.color.a;

		//スタート時間をキャッシュ
		startTime = Time.time;
		//スタート位置をキャッシュ
		startPosition = transform.localPosition;
		//到着地点をセット
		targetPosition = new Vector3(0, 150, 0);
		//目的地までの距離を求める
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
		alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
		SetAlpha();                      //b)変更した不透明度パネルに反映する
		if (alfa <= 0)
		{                    //c)完全に透明になったら処理を抜ける
			fadeSp.enabled = false;    //d)パネルの表示をオフにする
			num++;
		}
		
	}

	void StartFadeOut()
	{

		fadeSp.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha();               // c)変更した透明度をパネルに反映する
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