using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	Vector3 WarpPoint = new Vector3(9, 0.08f, 11);

	void OnTriggerEnter(Collider col) {
		//Playerと接触したら（9, 0.08f, 11）の座標までワープする
		if (col.gameObject.tag == "WarpPoint") {
			transform.position = WarpPoint;
		}
	}
}