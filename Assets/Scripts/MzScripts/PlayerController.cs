using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private bool KeyboardControl;
	private bool TouchPadControl;
	private bool Forward;
	private bool Back;
	private bool Left;
	private bool Right;
	private bool FL;
	private bool FR;
	private bool BL;
	private bool BR;

	private Light playerSpotlight;
	private FootSound playerFootSound;
	private MzSoundEffect mzSoundEffect;
	private MzTimer mzTimer;

	[SerializeField] private float maxForwardSpeed;
	[SerializeField] private float maxBackwardSpeed;
	[SerializeField] private float maxRotSpeed;
	[SerializeField] private float rotSpeed;
	private float curSpeed;
	private float curRotSpeed;
	private float playerSpeed;
	private float playerRotSpeed;

	[SerializeField] private float keyboardSpeed;
	[SerializeField] private float keyboardRotSpeed;


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


	void Awake()
	{
		mzSoundEffect = GameObject.Find("MzSoundEffect").GetComponent<MzSoundEffect>();
		mzTimer = GameObject.Find ("MzTimerLabel").GetComponent<MzTimer> ();
		playerFootSound = GameObject.Find ("Player").GetComponent<FootSound> ();
		playerSpotlight = GameObject.Find ("PlayerSpotlight").GetComponent<Light> ();
	}

	void Start()
	{
		gameObject.SetActive (true);

		KeyboardControl = false;
		TouchPadControl = true;
		Forward = false;
		Back = false;
		Left = false;
		Right = false;
		FL = false;
		FR = false;
		BL = false;
		BR = false;
	}

	void Update()
	{
		UpdateSystem ();
		UpdateControl ();
	}
		
	void UpdateSystem ()
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

		//-----デバッグ用のショートカットキー-----
		if (Input.GetKeyDown ("l")) {
			GameController.Light = true;
		} else if (Input.GetKeyDown ("c")) {
			GameController.Croquette = true;
		} else if (Input.GetKeyDown ("m")) {
			GameController.MapCrystal = true;
		}
		//----------

		if (GameController.Croquette) {
			maxForwardSpeed = 4.0f;
			maxBackwardSpeed = 2.5f;
			maxRotSpeed = 1.2f;
			keyboardSpeed = 4.0f;
			playerFootSound.soundInterval = 0.37f;
		}
	}

	void UpdateControl ()
	{
		//-----キーボードとタッチパッドの切り替え-----
		if (Input.GetKeyDown ("k")) {
			KeyboardControl = true;
			TouchPadControl = false;
		} else if (Input.GetKeyDown ("t")) {
			KeyboardControl = false;
			TouchPadControl = true;
		}
		//----------

		//-----キーボードによる操作-----
		if (KeyboardControl) {
			float translation = Input.GetAxis ("Vertical") * keyboardSpeed;
			float rotation = Input.GetAxis ("Horizontal") * keyboardRotSpeed;
			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate (0, 0, translation);
			transform.Rotate (0, rotation, 0);
		}
		//----------

		//-----タッチパッドによる操作-----
		if(TouchPadControl) {
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

		curSpeed = Mathf.Lerp(curSpeed, playerSpeed, 10.0f * Time.deltaTime);
		transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);

		curRotSpeed = Mathf.Lerp (curRotSpeed, playerRotSpeed, 10.0f * Time.deltaTime);
		transform.Rotate(0, -rotSpeed * Time.deltaTime * curRotSpeed, 0.0f);
		//----------
	}
		
	//-----各操作ボタンを押した時の処理-----
	void MoveForward()
	{
		playerSpeed = maxForwardSpeed;
	}
	void MoveBack()
	{
		playerSpeed = -maxBackwardSpeed;
	}
	void RotateLeft()
	{
		playerRotSpeed = maxRotSpeed;
	}
	void RotateRight()
	{
		playerRotSpeed = -maxRotSpeed;
	}
	void MoveFL()
	{
		playerSpeed = maxForwardSpeed;
		playerRotSpeed = maxRotSpeed;
	}
	void MoveFR()
	{
		playerSpeed = maxForwardSpeed;
		playerRotSpeed = -maxRotSpeed;
	}
	void RotateBL()
	{
		playerSpeed = -maxBackwardSpeed;
		playerRotSpeed = maxRotSpeed;
	}
	void RotateBR()
	{
		playerSpeed = -maxBackwardSpeed;
		playerRotSpeed = -maxRotSpeed;
	}
	//----------


	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Light") {
			GameController.Light = true;
			mzSoundEffect.LightBallSound ();
			Destroy (hit.gameObject);
		} else if (hit.gameObject.tag == "Croquette") {
			GameController.Croquette = true;
			mzSoundEffect.CroquetteSound ();
			Destroy (hit.gameObject);
		} else if (hit.gameObject.tag == "Map") {
			GameController.MapCrystal = true;
			mzSoundEffect.MapCrystalSound ();
			Destroy (hit.gameObject);
		} else if (hit.gameObject.tag == "Enemy") {
			mzSoundEffect.EnemyTouchSound ();
			transform.position = new Vector3(-1.0f, 0.5f, -15.0f);
			mzTimer.EnemyTouchTimer ();
		}
	}
}