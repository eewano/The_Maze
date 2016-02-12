using UnityEngine;
using System.Collections;

public class WarpMz01 : MonoBehaviour {

	Vector3 warp01_01 = new Vector3(8.5f, 0.5f, 9.8f);
	Vector3 warp01_02 = new Vector3(8.5f, 0.5f, 9.4f);
	Vector3 warp01_03 = new Vector3(8.5f, 0.5f, 9.0f);
	Vector3 warp01_04 = new Vector3(8.5f, 0.5f, 8.6f);
	Vector3 warp01_05 = new Vector3(8.5f, 0.5f, 8.2f);

	Vector3 warp02_01 = new Vector3(6.2f, 0.5f, 10.5f);
	Vector3 warp02_02 = new Vector3(6.6f, 0.5f, 10.5f);
	Vector3 warp02_03 = new Vector3(7.0f, 0.5f, 10.5f);
	Vector3 warp02_04 = new Vector3(7.4f, 0.5f, 10.5f);
	Vector3 warp02_05 = new Vector3(7.8f, 0.5f, 10.5f);

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Warp01-01") {
			transform.position = warp01_01;
		} 
		else if(col.gameObject.tag == "Warp01-02") {
			transform.position = warp01_02;
		}
		else if(col.gameObject.tag == "Warp01-03") {
			transform.position = warp01_03;
		}
		else if(col.gameObject.tag == "Warp01-04") {
			transform.position = warp01_04;
		}
		else if(col.gameObject.tag == "Warp01-05") {
			transform.position = warp01_05;
		}


		else if(col.gameObject.tag == "Warp02-01") {
			transform.position = warp02_01;
		}
		else if(col.gameObject.tag == "Warp02-02") {
			transform.position = warp02_02;
		}
		else if(col.gameObject.tag == "Warp02-03") {
			transform.position = warp02_03;
		}
		else if(col.gameObject.tag == "Warp02-04") {
			transform.position = warp02_04;
		}
		else if(col.gameObject.tag == "Warp02-05") {
			transform.position = warp02_05;
		}
	}
}