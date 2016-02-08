using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {

	[SerializeField] private GameObject Enemy;

	public void EnemySpawn() {
		Instantiate (Enemy, transform.position, transform.rotation);
	}
}