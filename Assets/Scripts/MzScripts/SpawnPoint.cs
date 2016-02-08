using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	[SerializeField] private GameObject Item;

	void Start () {
		Instantiate (Item, transform.position, transform.rotation);
	}
}