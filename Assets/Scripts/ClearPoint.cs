using UnityEngine;
using System.Collections;

public class ClearPoint : MonoBehaviour {

	GameObject gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter(Collider outer) {
		gameController.SendMessage("StageClear");
	}
}
