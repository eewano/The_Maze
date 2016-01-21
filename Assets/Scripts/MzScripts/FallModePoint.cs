using UnityEngine;
using System.Collections;

public class FallModePoint : MonoBehaviour {
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			GameController.Fall = true;
		}
	}
}