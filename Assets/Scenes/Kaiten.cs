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

		//�w�肵�������ɂ�������]����ꍇ
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180f, 0), step);
	}

}

		//target�Ŏw�肵���I�u�W�F�N�g�̕��ւ�������]����ꍇ
		//transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);