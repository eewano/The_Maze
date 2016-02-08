using UnityEngine;
using System.Collections;

public class Enemy02Move : MonoBehaviour {

	[SerializeField] private GameObject Target;
	[SerializeField] private float xMin;
	[SerializeField] private float xMax;
	[SerializeField] private float zMin;
	[SerializeField] private float zMax;
	NavMeshAgent navMeshAgentCompornent;

	void Start()
	{
		navMeshAgentCompornent = this.GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if (Enemy02Start.Enemy02Move == true) {
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
			Enemy02Start.Enemy02Move = false;
			transform.position = new Vector3(-11, 1, 5);
		}
	}
}