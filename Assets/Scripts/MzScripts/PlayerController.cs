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

	[SerializeField] float ForwardSpeed = 0.0f;
	[SerializeField] float BackwardSpeed = 0.0f;
	[SerializeField] float RotSpeed = 0.0f;

	[SerializeField] float KBSpeed = 0.0f;
	[SerializeField] float KBRotSpeed = 0.0f;


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

		if (Input.GetKeyDown ("k")) {
			KeyboardCont = true;
			TouchPadCont = false;
		}
		else if(Input.GetKeyDown ("t")) {
			KeyboardCont = false;
			TouchPadCont = true;
		}

		//テスト用のキー操作。
		if (KeyboardCont) {
			float translation = Input.GetAxis ("Vertical") * KBSpeed;
			float rotation = Input.GetAxis ("Horizontal") * KBRotSpeed;
			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate (0, 0, translation);
			transform.Rotate (0, rotation, 0);
		}

		//タッチパッドによる操作。
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
			}
		}
	}
		

	public void MoveForward()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * ForwardSpeed * 1 );
	}

	public void MoveBack()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * BackwardSpeed * -1 );
	}

	public void RotateLeft()
	{
		transform.Rotate (0, RotSpeed * -1, 0);
	}

	public void RotateRight()
	{
		transform.Rotate (0, RotSpeed, 0);
	}
	public void MoveFL()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * ForwardSpeed * 1 );
		transform.Rotate (0, RotSpeed * -1, 0);
	}

	public void MoveFR()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * ForwardSpeed * 1 );
		transform.Rotate (0, RotSpeed, 0);
	}

	public void RotateBL()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * BackwardSpeed * -1 );
		transform.Rotate (0, RotSpeed * -1, 0);
	}

	public void RotateBR()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * BackwardSpeed * -1 );
		transform.Rotate (0, RotSpeed, 0);
	}


	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Light") {
			mzSoundEffect.LightBallSound ();
			playerSpotlight.range = 6.5f;
			GameController.Light = true;
			Destroy (hit.gameObject);
		}
		else if (hit.gameObject.tag == "Croquette") {
			mzSoundEffect.CroquetteSound ();
			ForwardSpeed = 4.0f;
			BackwardSpeed = 2.5f;
			RotSpeed = 2.0f;
			KBSpeed = 4.0f;
			KBRotSpeed = 200.0f;
			playerFootSound.SoundInterval = 0.35f;
			GameController.Croquette = true;
			Destroy (hit.gameObject);
		}
		else if (hit.gameObject.tag == "Map") {
			mzSoundEffect.MapCrystalSound ();
			GameController.MapCrystal = true;
			Destroy (hit.gameObject);
		}
	}
}

/*
//タッチパッドによる操作。
if(TouchPadCont) {
	if (Input.GetMouseButton (0)) {

		if (Input.mousePosition.x < Screen.width / 4) {
			Debug.Log ("左側が反応");
			transform.Rotate (0, RotSpeed * -1, 0);
		} else if (Input.mousePosition.x > Screen.width * 3 / 4) {
			Debug.Log ("右側が反応");
			transform.Rotate (0, RotSpeed, 0);
		}

		if (Input.mousePosition.y > Screen.height * 3 / 4) {
			Debug.Log ("上側が反応");
			transform.Translate(Vector3.forward * Time.deltaTime * ForwardSpeed * 1 );
		} else if (Input.mousePosition.y < Screen.height / 4) {
			Debug.Log ("下側が反応");
			transform.Translate(Vector3.forward * Time.deltaTime * BackwardSpeed * -1 );
		}
	}
}
*/

/*
if(TouchPadCont) {

	if (Input.GetMouseButton (0)) {

		//Touch ScrTouch = Input.GetTouch (0);
		//Vector2 newVec = new Vector2 (ScrTouch.position.x, Screen.height - ScrTouch.position.y);

		if (Input.mousePosition.x >= LeftRect.xMin && 
			Input.mousePosition.x < LeftRect.xMax && 
			Input.mousePosition.y >= LeftRect.yMin && 
			Input.mousePosition.y < LeftRect.yMax) {
			Debug.Log ("左側が反応");
			transform.Rotate (0, RotSpeed * -1, 0);
		} else if (Input.mousePosition.x >= RightRect.xMin && 
			Input.mousePosition.x < RightRect.xMax && 
			Input.mousePosition.y >= RightRect.yMin && 
			Input.mousePosition.y < RightRect.yMax) {
			Debug.Log ("右側が反応");
			transform.Rotate (0, RotSpeed, 0);
		}

		if (Input.mousePosition.x >= UpRect.xMin && 
			Input.mousePosition.x < UpRect.xMax && 
			Input.mousePosition.y >= UpRect.yMin && 
			Input.mousePosition.y < UpRect.yMax) {
			Debug.Log ("上側が反応");
			transform.Translate(Vector3.forward * Time.deltaTime * ForwardSpeed * 1 );
		} else if (Input.mousePosition.x >= DownRect.xMin && 
			Input.mousePosition.x < DownRect.xMax && 
			Input.mousePosition.y >= DownRect.yMin && 
			Input.mousePosition.y < DownRect.yMax) {
			Debug.Log ("下側が反応");
			transform.Translate(Vector3.forward * Time.deltaTime * BackwardSpeed * -1 );
		}
	}
}
*/

/*
if (KeyboardCont) {
	float forward = CrossPlatformInputManager.GetAxis ("Vertical") * KBSpeed;
	float back = CrossPlatformInputManager.GetAxis ("Vertical") * KBBack;
	float rotation = CrossPlatformInputManager.GetAxis ("Horizontal") * KBRotSpeed;
	forward *= Time.deltaTime;
	back *= Time.deltaTime;
	rotation *= Time.deltaTime;
	transform.Translate (0, 0, forward);
	transform.Translate (0, 0, -back);
	transform.Rotate (0, rotation, 0);
}
*/