using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	[SerializeField] GameObject Player;

	void Start () {
		Instantiate (Player, transform.position, transform.rotation);
	}
}
