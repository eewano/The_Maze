using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	CharacterController controller;
	Animator animator;

	Vector3 moveDirection = Vector3.zero;

	public float gravity;
	public float ForwardSpeed;
	public float BackwardSpeed;
	public float RotSpeed;
	public float JumpPower;

	void Start()
	{
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}
		
	void Update()
	{
		if (controller.isGrounded) {
			if (Input.GetAxis ("Vertical") > 0.0f) {
				moveDirection.z = Input.GetAxis ("Vertical") * ForwardSpeed;
			} else if (Input.GetAxis ("Vertical") < 0.0f) {
				moveDirection.z = Input.GetAxis ("Vertical") * BackwardSpeed;
			} else {
				moveDirection.z = 0;
			}

			transform.Rotate (0, Input.GetAxis ("Horizontal") * RotSpeed, 0);

			if (Input.GetButtonDown ("Jump")) {
				moveDirection.y = JumpPower;
				animator.SetTrigger ("Jump");
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		Vector3 globalDirection = transform.TransformDirection (moveDirection);
		controller.Move (globalDirection * Time.deltaTime);

		if (controller.isGrounded)
			moveDirection.y = 0;

		animator.SetBool ("Run", moveDirection.z > 0.0f);
		animator.SetBool ("Back", moveDirection.z < 0.0f);
	}
}