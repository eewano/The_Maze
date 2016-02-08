using UnityEngine;
using System.Collections;

public class Enemy01Start : MonoBehaviour {

	public static bool Enemy01Move;

	void Start()
	{
		Enemy01Move = false;
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player")
			Enemy01Move = true;
	}
}