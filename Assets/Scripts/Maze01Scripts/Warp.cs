using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	Vector3 WarpPoint = new Vector3(-15, 0.08f, -5);

	void OnTriggerEnter(Collider col) {
		//Playerと接触したら（-15,-0.38,0）の座標までワープする
		if (col.gameObject.tag == "WarpPoint") {
			transform.position = WarpPoint;
		}
	}
}