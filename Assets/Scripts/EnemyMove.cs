using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	[SerializeField] GameObject targetNavMeshObjects;
	NavMeshAgent navMeshAgentComponent;
	GameObject Target;

	// Use this for initialization
	void Start () {
		navMeshAgentComponent = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Target = GameObject.Find ("Player(Clone)");

		//設定したターゲットの位置を常に追跡対象とする
		navMeshAgentComponent.SetDestination (Target.transform.position);
	}
}
