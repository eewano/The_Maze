using UnityEngine;
using System.Collections;

public class WallProduct : MonoBehaviour {

	public GameObject NewWall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider col) {
		//Playerが通過したら壁を生成する
		if (col.gameObject.tag == "Player") {
			Instantiate (NewWall, transform.position, transform.rotation);
			//Destroy(GameObject);
		}
	}
}