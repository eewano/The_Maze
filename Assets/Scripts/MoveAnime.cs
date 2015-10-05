using UnityEngine;
using System.Collections;

public class MoveAnime : MonoBehaviour {

	Animator animator;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		// ここで同期。
		animator.SetFloat ("Speed", agent.velocity.sqrMagnitude);
	}
}
