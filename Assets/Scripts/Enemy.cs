using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		//Playerと接触したらGAME OVER。
		if (col.gameObject.tag == "Player") {
			Application.LoadLevel ("StartMenu");
		}
	}
}
