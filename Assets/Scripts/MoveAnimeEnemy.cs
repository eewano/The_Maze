using UnityEngine;
using System.Collections;

public class MoveAnimeEnemy : MonoBehaviour {

	Animator animator;
	NavMeshAgent agent;

	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () {
		// ここで同期。
		animator.SetFloat ("Speed", agent.velocity.sqrMagnitude);
	}
}
