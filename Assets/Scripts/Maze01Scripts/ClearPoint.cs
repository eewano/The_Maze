using UnityEngine;
using System.Collections;

public class ClearPoint : MonoBehaviour {

	GameObject gameController;

	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter(Collider outer) {
		gameController.SendMessage("Goal");
	}
}