using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaiten : MonoBehaviou
{

	Transform target;
	float speed = 120f;

	void Start()
	{
		target = GameObject.Find("Cube").transform;
	}

	void Update()
	{
		float step = speed * Time.deltaTime;

		//指定した方向にゆっくり回転する場合
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180f, 0), step);
	}

}

		//targetで指定したオブジェクトの方へゆっくり回転する場合
		//transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);