using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	Vector3 WarpPoint01 = new Vector3(9, 0.08f, 10);
	Vector3 WarpPoint02 = new Vector3(8, 0.08f, 11);
	Vector3 WarpPoint03 = new Vector3(-18, 0.08f, 5);

	void OnTriggerEnter(Collider col) {
		//Playerと接触したら（9, 0.08f, 11）の座標までワープする
		if (col.gameObject.tag == "WarpPoint01") {
			transform.position = WarpPoint01;
		} 
		else if(col.gameObject.tag == "WarpPoint02") {
				transform.position = WarpPoint02;
		}
		else if(col.gameObject.tag == "WarpPoint03") {
			transform.position = WarpPoint03;
		}
	}
}