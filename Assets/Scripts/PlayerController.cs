using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	// 歩行スピード
	public float speed = 3.0F;
	// 方向転換のスピード
	public float rotationSpeed = 50.0F;

	void FixedUpdate() {
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
	}
}