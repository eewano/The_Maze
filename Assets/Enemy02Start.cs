using UnityEngine;
using System.Collections;

public class Enemy02Start : MonoBehaviour {

	public static bool Enemy02Move;

	void Start()
	{
		Enemy02Move = false;
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player")
			Enemy02Move = true;
	}
}