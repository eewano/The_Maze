﻿using UnityEngine;
using System.Collections;

public class ClearPoint : MonoBehaviour {

	GameObject gameController;

	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player")
		gameController.SendMessage("Goal");
	}
}