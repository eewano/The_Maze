using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Light playerPointlight;

	MzSoundEffect mzSoundEffect;

	[SerializeField] float ForwardSpeed = 0.0f;
	[SerializeField] float BackwardSpeed = 0.0f;
	[SerializeField] float RotSpeed = 0.0f;

	void Start()
	{
		mzSoundEffect = GameObject.Find("MzSoundController").GetComponent<MzSoundEffect>();
		playerPointlight = GameObject.Find ("PlayerPointlight").GetComponent<Light> ();
		gameObject.SetActive (true);
	}


	void Update () {
		if (GameController.GoalAndClear) {
			gameObject.SetActive (false);
		}
		/*
		//テスト用のキー操作。
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
		*/
		//float rotation = Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;

		//クリックされたよ
		if (Input.GetMouseButton(0)) {

			if (Input.mousePosition.x < Screen.width / 4) {
				Debug.Log("左側が反応");
				transform.Rotate (0, RotSpeed * -1, 0);
			}
			else if (Input.mousePosition.x > Screen.width * 3 / 4) {
				Debug.Log("右側が反応");
				transform.Rotate (0, RotSpeed, 0);
			}

			//if (Input.mousePosition.y > center_y) {
			if (Input.mousePosition.y > Screen.height * 3 / 4) {
				Debug.Log("上側が反応");
				this.transform.Translate(this.transform.forward * 0.05f);
				//transform.Translate (ForwardSpeed * Time.deltaTime * transform.forward);
			}
			//else if (Input.mousePosition.y < center_y) {
			else if (Input.mousePosition.y < Screen.height / 4) {
				Debug.Log("下側が反応");

				//for(ForwardSpeed = 0; this.ForwardSpeed <= ForwardSpeed; ++ForwardSpeed) {
					transform.Translate (-ForwardSpeed * Time.deltaTime * transform.forward);
				}
				//this.transform.Translate(this.transform.forward * -0.05f);
				//transform.Translate (-ForwardSpeed * Time.deltaTime * transform.forward);
		}
	}


	void OnTriggerEnter(Collider hit) {
		if (hit.gameObject.tag == "Light") {
			mzSoundEffect.LightBallSound ();
			playerPointlight.range = 30;
			GameController.Light = true;
			Destroy (hit.gameObject);
		}
		else if (hit.gameObject.tag == "Croquette") {
			mzSoundEffect.CroquetteSound ();
			ForwardSpeed = 7.5f;
			BackwardSpeed = 5.0f;
			RotSpeed = 75.0f;
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
//画面の横の長さを取得です
int width = Screen.width;

//画面の縦の長さを取得
int height = Screen.height;

//画面の中央値を取ります
int center_x = Screen.width / 2;
int center_y = Screen.height / 2;

void Start () {

}


void Update () {

	//クリックされたよ
	if (Input.GetMouseButtonDown(0)) {


		//これらは重複するよ
		//細かい設定は頑張ってね

		if (Input.mousePosition.x < center_x) {
			Debug.Log("画面の右側が押されたよ");
		}
		else if (Input.mousePosition.x > center_x) {
			Debug.Log("画面の左側が押されたよ");
		}

		if (Input.mousePosition.y < center_y) {
			Debug.Log("画面の下側が押されたよ");
		}
		else if (Input.mousePosition.y > center_y) {
			Debug.Log("画面の上側が押されたよ");
		}

	}

}
*/