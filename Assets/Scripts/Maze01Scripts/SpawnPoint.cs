using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject Player;

	void Start () {
		Instantiate (Player, transform.position, transform.rotation);
	}
}
