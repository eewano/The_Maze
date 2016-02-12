using UnityEngine;
using System.Collections;

public class WarpMz02 : MonoBehaviour {

	Vector3 warp01_01 = new Vector3(8.2f, 0.5f, 3.5f);
	Vector3 warp01_02 = new Vector3(8.6f, 0.5f, 3.5f);
	Vector3 warp01_03 = new Vector3(9.0f, 0.5f, 3.5f);
	Vector3 warp01_04 = new Vector3(9.4f, 0.5f, 3.5f);
	Vector3 warp01_05 = new Vector3(9.8f, 0.5f, 3.5f);

	Vector3 warp02_01 = new Vector3(4.2f, 0.5f, 0.5f);
	Vector3 warp02_02 = new Vector3(4.6f, 0.5f, 0.5f);
	Vector3 warp02_03 = new Vector3(5.0f, 0.5f, 0.5f);
	Vector3 warp02_04 = new Vector3(5.4f, 0.5f, 0.5f);
	Vector3 warp02_05 = new Vector3(5.8f, 0.5f, 0.5f);

	Vector3 warp03_01 = new Vector3(17.5f, 0.5f, -14.2f);
	Vector3 warp03_02 = new Vector3(17.5f, 0.5f, -14.6f);
	Vector3 warp03_03 = new Vector3(17.5f, 0.5f, -15.0f);
	Vector3 warp03_04 = new Vector3(17.5f, 0.5f, -15.4f);
	Vector3 warp03_05 = new Vector3(17.5f, 0.5f, -15.8f);

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


		else if(col.gameObject.tag == "Warp03-01") {
			transform.position = warp03_01;
		}
		else if(col.gameObject.tag == "Warp03-02") {
			transform.position = warp03_02;
		}
		else if(col.gameObject.tag == "Warp03-03") {
			transform.position = warp03_03;
		}
		else if(col.gameObject.tag == "Warp03-04") {
			transform.position = warp03_04;
		}
		else if(col.gameObject.tag == "Warp03-05") {
			transform.position = warp03_05;
		}
	}
}