using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	[SerializeField] private GameObject item;

	void Awake () {
		Instantiate (item, transform.position, transform.rotation);
	}
}