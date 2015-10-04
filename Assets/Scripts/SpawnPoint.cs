using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
		Instantiate (Player, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
