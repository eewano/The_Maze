using UnityEngine;
using System.Collections;

public class ClearPoint : MonoBehaviour {

	GameObject gameController;

	// Use this for initialization
	void Start () {

		//クリア後にゲームを再スタートする際、プレイヤーがまた動き出せる様にする
		Time.timeScale = 1;
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter(Collider outer) {
		gameController.SendMessage("Goal");
	}
}