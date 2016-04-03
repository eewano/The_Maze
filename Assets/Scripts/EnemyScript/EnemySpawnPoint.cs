using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {

	[SerializeField] private GameObject enemy;

	public void EnemySpawn() {
		Instantiate (enemy, transform.position, transform.rotation);
	}
}