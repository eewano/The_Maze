using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool KeyboardCont;
	private bool TouchPadCont;

	Light playerSpotlight;

	MzSoundEffect mzSoundEffect;

	[SerializeField] float ForwardSpeed = 0.0f;
	[SerializeField] float BackwardSpeed = 0.0f;
	[SerializeField] float RotSpeed = 0.0f;

	[SerializeField] float KBSpeed = 0.0f;
	[SerializeField] float KBRotSpeed = 0.0f;

	Rect LeftRect = new Rect(148, 0, 152, 428);	//左側を向く範囲。
	Rect RightRect = new Rect(430, 0, 152, 428);	//右側を向く範囲。
	Rect UpRect = new Rect(148, 142, 434, 143);	//上側を向く範囲。
	Rect DownRect = new Rect(148, 0, 434, 142);	//下側を向く範囲。

	void Start()
	{
		mzSoundEffect = GameObject.Find("MzSoundController").GetComponent<MzSoundEffect>();
		playerSpotlight = GameObject.Find ("PlayerSpotlight").GetComponent<Light> ();
		gameObject.SetActive (true);

		KeyboardCont = false;
		TouchPadCont = true;

		GameController.Fall = false;
		GameController.GameIsOver = false;
	}


	void Update () {

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
	}


	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Light") {
			mzSoundEffect.LightBallSound ();
			playerSpotlight.range = 7.5f;
			GameController.Light = true;
			Destroy (hit.gameObject);
		}
		else if (hit.gameObject.tag == "Croquette") {
			mzSoundEffect.CroquetteSound ();
			ForwardSpeed = 4.5f;
			BackwardSpeed = 2.0f;
			RotSpeed = 1.4f;
			KBSpeed = 4.5f;
			KBRotSpeed = 150.0f;
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