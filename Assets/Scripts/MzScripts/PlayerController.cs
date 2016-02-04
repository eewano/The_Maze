using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool KeyboardCont;
	private bool TouchPadCont;
	private bool Forward = false;
	private bool Back = false;
	private bool Left = false;
	private bool Right = false;
	private bool FL = false;
	private bool FR = false;
	private bool BL = false;
	private bool BR = false;

	Light playerSpotlight;
	FootSound playerFootSound;

	MzSoundEffect mzSoundEffect;

	[SerializeField] private float maxForwardSpeed;
	[SerializeField] private float maxBackwardSpeed;
	[SerializeField] private float maxRotSpeed;
	[SerializeField] private float RotSpeed;
	private float curSpeed;
	private float curRotSpeed;
	private float playerSpeed;
	private float playerRotSpeed;

	[SerializeField] private float KBSpeed;
	[SerializeField] private float KBRotSpeed;



	public void PushForwardDown()
	{
		Forward = true;
	}
	public void PushForwardUp()
	{
		Forward = false;
	}
	public void PushBackDown()
	{
		Back = true;
	}
	public void PushBackUp()
	{
		Back = false;
	}
	public void PushLeftDown()
	{
		Left = true;
	}
	public void PushLeftUp()
	{
		Left = false;
	}
	public void PushRightDown()
	{
		Right = true;
	}
	public void PushRightUp()
	{
		Right = false;
	}

	public void PushFLDown()
	{
		FL = true;
	}
	public void PushFLUp()
	{
		FL = false;
	}
	public void PushFRDown()
	{
		FR = true;
	}
	public void PushFRUp()
	{
		FR = false;
	}
	public void PushBLDown()
	{
		BL = true;
	}
	public void PushBLUp()
	{
		BL = false;
	}
	public void PushBRDown()
	{
		BR = true;
	}
	public void PushBRUp()
	{
		BR = false;
	}

	void Start()
	{
		mzSoundEffect = GameObject.Find("MzSoundController").GetComponent<MzSoundEffect>();
		playerFootSound = GameObject.Find ("Player").GetComponent<FootSound> ();
		playerSpotlight = GameObject.Find ("PlayerSpotlight").GetComponent<Light> ();
		gameObject.SetActive (true);

		KeyboardCont = false;
		TouchPadCont = true;

		GameController.Fall = false;
		GameController.GameIsOver = false;
	}


	void Update ()
	{
		if (GameController.GoalAndClear) {
			gameObject.SetActive (false);
		}

		if (GameController.Fall || GameController.GameIsOver) {
			return;
		}

		if (GameController.MapModeON == true && GameController.MapModeOFF == false) {
			playerSpotlight.intensity = 8;
		} else if (GameController.MapModeON == false && GameController.MapModeOFF == true) {
			playerSpotlight.intensity = 4;
		}

		if (Input.GetKeyDown ("k")) {
			KeyboardCont = true;
			TouchPadCont = false;
		} else if (Input.GetKeyDown ("t")) {
			KeyboardCont = false;
			TouchPadCont = true;
		} else if (Input.GetKeyDown ("l")) {
			GameController.Light = true;
		} else if (Input.GetKeyDown ("c")) {
			GameController.Croquette = true;
		} else if (Input.GetKeyDown ("m")) {
			GameController.MapCrystal = true;
		}

		if (GameController.Light) {
			playerSpotlight.range = 6.5f;
		}

		if (GameController.Croquette) {
			maxForwardSpeed = 4.0f;
			maxBackwardSpeed = 2.5f;
			maxRotSpeed = 1.2f;
			RotSpeed = 150;
			KBSpeed = 4.0f;
			KBRotSpeed = 150.0f;
			playerFootSound.SoundInterval = 0.37f;
		}
			

		//キーボードによる操作
		if (KeyboardCont) {
			float translation = Input.GetAxis ("Vertical") * KBSpeed;
			float rotation = Input.GetAxis ("Horizontal") * KBRotSpeed;
			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate (0, 0, translation);
			transform.Rotate (0, rotation, 0);
		}

		curSpeed = Mathf.Lerp(curSpeed, playerSpeed, 10.0f * Time.deltaTime);
		transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);

		curRotSpeed = Mathf.Lerp (curRotSpeed, playerRotSpeed, 10.0f * Time.deltaTime);
		transform.Rotate(0, -RotSpeed * Time.deltaTime * curRotSpeed, 0.0f);

		//タッチパッドによる操作
		if(TouchPadCont) {
			if (Forward) {
				MoveForward ();
			} else if (Back) {
				MoveBack ();
			} else if (Left) {
				RotateLeft ();
			} else if (Right) {
				RotateRight ();
			} else if (FL) {
				MoveFL ();
			} else if (FR) {
				MoveFR ();
			} else if (BL) {
				RotateBL ();
			} else if (BR) {
				RotateBR ();
			} else {
				playerSpeed = 0;
				playerRotSpeed = 0;
			}
		}
	}
		

	public void MoveForward()
	{
		playerSpeed = maxForwardSpeed;
	}

	public void MoveBack()
	{
		playerSpeed = -maxBackwardSpeed;
	}

	public void RotateLeft()
	{
		playerRotSpeed = maxRotSpeed;
	}

	public void RotateRight()
	{
		playerRotSpeed = -maxRotSpeed;
	}
	public void MoveFL()
	{
		playerSpeed = maxForwardSpeed;
		playerRotSpeed = maxRotSpeed;
	}

	public void MoveFR()
	{
		playerSpeed = maxForwardSpeed;
		playerRotSpeed = -maxRotSpeed;
	}

	public void RotateBL()
	{
		playerSpeed = -maxBackwardSpeed;
		playerRotSpeed = maxRotSpeed;
	}

	public void RotateBR()
	{
		playerSpeed = -maxBackwardSpeed;
		playerRotSpeed = -maxRotSpeed;
	}


	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Light") {
			GameController.Light = true;
			mzSoundEffect.LightBallSound ();
			//playerSpotlight.range = 6.5f;
			Destroy (hit.gameObject);
		}
		else if (hit.gameObject.tag == "Croquette") {
			GameController.Croquette = true;
			mzSoundEffect.CroquetteSound ();
			//maxForwardSpeed = 4.0f;
			//maxBackwardSpeed = 2.5f;
			//maxRotSpeed = 1.2f;
			//RotSpeed = 150;
			//KBSpeed = 4.0f;
			//KBRotSpeed = 150.0f;
			//playerFootSound.SoundInterval = 0.37f;
			Destroy (hit.gameObject);
		}
		else if (hit.gameObject.tag == "Map") {
			GameController.MapCrystal = true;
			mzSoundEffect.MapCrystalSound ();
			Destroy (hit.gameObject);
		}
	}
}