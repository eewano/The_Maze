using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	[SerializeField] GameObject Player = null;

	void Start () {
		Instantiate (Player, transform.position, transform.rotation);
	}
}