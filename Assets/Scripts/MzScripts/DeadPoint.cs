using UnityEngine;
using System.Collections;

public class DeadPoint : MonoBehaviour {

	GameObject gameController;

	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			GameController.Dead = true;
			gameController.SendMessage ("Failure");
		}
	}
}