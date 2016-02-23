using UnityEngine;
using System.Collections;

public class ClearPoint : MonoBehaviour {

	private GameObject gameManager;

	void Start () {
		gameManager = GameObject.Find ("GameManager");
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player")
			gameManager.SendMessage("Goal");
	}
}