using UnityEngine;
using System.Collections;

public class WarpMz01 : MonoBehaviour {

	Vector3 Warp01_01 = new Vector3(8.5f, 0.5f, 9.8f);
	Vector3 Warp01_02 = new Vector3(8.5f, 0.5f, 9.4f);
	Vector3 Warp01_03 = new Vector3(8.5f, 0.5f, 9.0f);
	Vector3 Warp01_04 = new Vector3(8.5f, 0.5f, 8.6f);
	Vector3 Warp01_05 = new Vector3(8.5f, 0.5f, 8.2f);

	Vector3 Warp02_01 = new Vector3(6.2f, 0.5f, 10.5f);
	Vector3 Warp02_02 = new Vector3(6.6f, 0.5f, 10.5f);
	Vector3 Warp02_03 = new Vector3(7.0f, 0.5f, 10.5f);
	Vector3 Warp02_04 = new Vector3(7.4f, 0.5f, 10.5f);
	Vector3 Warp02_05 = new Vector3(7.8f, 0.5f, 10.5f);

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Warp01-01") {
			transform.position = Warp01_01;
		} 
		else if(col.gameObject.tag == "Warp01-02") {
			transform.position = Warp01_02;
		}
		else if(col.gameObject.tag == "Warp01-03") {
			transform.position = Warp01_03;
		}
		else if(col.gameObject.tag == "Warp01-04") {
			transform.position = Warp01_04;
		}
		else if(col.gameObject.tag == "Warp01-05") {
			transform.position = Warp01_05;
		}


		else if(col.gameObject.tag == "Warp02-01") {
			transform.position = Warp02_01;
		}
		else if(col.gameObject.tag == "Warp02-02") {
			transform.position = Warp02_02;
		}
		else if(col.gameObject.tag == "Warp02-03") {
			transform.position = Warp02_03;
		}
		else if(col.gameObject.tag == "Warp02-04") {
			transform.position = Warp02_04;
		}
		else if(col.gameObject.tag == "Warp02-05") {
			transform.position = Warp02_05;
		}
	}
}