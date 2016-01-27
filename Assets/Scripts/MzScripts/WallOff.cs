using UnityEngine;
using System.Collections;

public class WallOff : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player")
			WallOnOff.WallOn = false;
			WallOnOff.WallOff = true;
	}
}