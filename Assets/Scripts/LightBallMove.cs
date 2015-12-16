using UnityEngine;
using System.Collections;

public class LightBallMove : MonoBehaviour {

	Vector3 startPosition;

	public float amplitude;
	public float speed;

	void Start()
	{
		startPosition = transform.localPosition;
	}

	void Update ()
	{
		//変位を計算する。
		float y = amplitude * Mathf.Sin(Time.time * speed);

		//xを変位させたポジションに再設定する。
		transform.localPosition = startPosition + new Vector3(0, y, 0);
	}
}