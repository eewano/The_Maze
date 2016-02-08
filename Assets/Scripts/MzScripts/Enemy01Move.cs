using UnityEngine;
using System.Collections;

public class Enemy01Move : MonoBehaviour {

	[SerializeField] private GameObject Target;
	[SerializeField] private float xMin;
	[SerializeField] private float xMax;
	[SerializeField] private float zMin;
	[SerializeField] private float zMax;
	NavMeshAgent navMeshAgentCompornent;

	[SerializeField] private AudioClip EnemyMoveSE;
	private AudioSource audio_source;

	void Start()
	{
		navMeshAgentCompornent = this.GetComponent<NavMeshAgent>();
		audio_source = gameObject.GetComponent<AudioSource>();
		audio_source.clip = EnemyMoveSE;
	}

	void Update()
	{
		if (Enemy01Start.Enemy01Move == true) {
			audio_source.Play();
			navMeshAgentCompornent.SetDestination (Target.transform.position);
			GetComponent<Rigidbody> ().position = new Vector3 (
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x, xMin, xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z, zMin, zMax)
			);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			audio_source.Stop();
			Enemy01Start.Enemy01Move = false;
			transform.position = new Vector3(13, 1, 7);
		}
	}
}