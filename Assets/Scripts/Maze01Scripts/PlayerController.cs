using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	CharacterController controller;
	Animator animator;

	Vector3 moveDirection = Vector3.zero;

	[SerializeField] float gravity = 0;
	[SerializeField] float ForwardSpeed;
	[SerializeField] float BackwardSpeed;
	[SerializeField] float RotSpeed;
	[SerializeField] float JumpPower = 0;

	Light playerPointLight;

	Maze01SoundEffect maze01soundEffect;

	void Start()
	{
		GameController.GameIsOver = false;
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		maze01soundEffect = GameObject.Find("Maze01SoundController").GetComponent<Maze01SoundEffect>();
		playerPointLight = GameObject.Find ("PlayerPointLight").GetComponent<Light> ();
	}
		
	void Update()
	{
		if (GameController.GameIsOver) {
			animator.Stop ();
			return;
		}

		if (GameController.GoalAndClear) {
			animator.Stop ();
			return;
		}

		if (controller.isGrounded) {
			if (Input.GetAxis ("Vertical") > 0.0f) {
				moveDirection.z = Input.GetAxis ("Vertical") * ForwardSpeed;
			} else if (Input.GetAxis ("Vertical") < 0.0f) {
				moveDirection.z = Input.GetAxis ("Vertical") * BackwardSpeed;
			} else {
				moveDirection.z = 0;
			}

			transform.Rotate (0, Input.GetAxis ("Horizontal") * RotSpeed, 0);

			if (Input.GetButtonDown ("Jump") && moveDirection.z > 0) {
				maze01soundEffect.JumpSound();
				moveDirection.y = JumpPower;
				animator.SetTrigger ("Jump");
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		Vector3 globalDirection = transform.TransformDirection (moveDirection);
		controller.Move (globalDirection * Time.deltaTime);

		if (controller.isGrounded)
			moveDirection.y = 0;

		animator.SetFloat ("Run", moveDirection.z);
		animator.SetBool ("Back", moveDirection.z < 0.0f);
		animator.SetFloat ("Dash", moveDirection.z);
	}
		
	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Light") {
			maze01soundEffect.LightBallSound ();
			playerPointLight.range = 30;
			Destroy (hit.gameObject);
		} else if (hit.gameObject.tag == "Croquette") {
			maze01soundEffect.CroquetteSound ();
			ForwardSpeed = 3.75f;
			BackwardSpeed = 1.25f;
			RotSpeed = 2.5f;
			Destroy (hit.gameObject);
		} else if (hit.gameObject.tag == "Map") {
			maze01soundEffect.MapCrystalSound ();
			GameController.MapCrystalGet = true;
			Destroy (hit.gameObject);
		}
	}
}