using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	[SerializeField] GameObject targetNavMeshObjects;
	NavMeshAgent navMeshAgentComponent;

	// Use this for initialization
	void Start () {
		navMeshAgentComponent = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		navMeshAgentComponent.SetDestination (targetNavMeshObjects.transform.position);
	}
}
