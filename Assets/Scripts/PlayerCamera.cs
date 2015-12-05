﻿using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	Vector3 diff;

	[SerializeField] GameObject target;
	[SerializeField] float followSpeed;

	void Start()
	{
		diff = target.transform.position - transform.position;
	}

	void LateUpdate()
	{
		transform.position = Vector3.Lerp (
			transform.position,
			target.transform.position - diff,
			Time.deltaTime * followSpeed
		);
	}
}
