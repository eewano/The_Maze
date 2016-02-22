using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private bool
		KeyboardControl,
		TouchPadControl,
		Forward,
		Back,
		Left,
		Right,
		FL,
		FR,
		BL,
		BR;

	public float maxForwardSpeed;
	public float maxBackwardSpeed;
	public float maxRotSpeed;
	public float rotSpeed;

	public float keyboardSpeed;
	public float keyboardRotSpeed;

	private float curSpeed;
	private float curRotSpeed;
	private float playerSpeed;
	private float playerRotSpeed;


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
		if (GameManager.Fall == true || GameManager.GameIsOver == true) {
			enabled = false;
			return;
		}
		UpdateShortCutKey();
		UpdateControl();
	}

	void UpdateShortCutKey()
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
	}

	void UpdateControl()
	{
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
}