using UnityEngine;
using System.Collections;

public class WallOn : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player")
			WallOnOff.WallOn = true;
		WallOnOff.WallOff = false;
	}
}