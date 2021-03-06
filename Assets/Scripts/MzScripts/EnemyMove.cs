﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class MoveArea 
{
	public float xMin, xMax, zMin, zMax;
}

public class EnemyMove : MonoBehaviour {

	enum EnemyState {PATROL, CHASE}
	private EnemyState state;

	[SerializeField] private GameObject target;
	[SerializeField] private MoveArea moveArea;
	[SerializeField] private float chasingSpeed;

	private NavMeshAgent navMeshAgent;

	Vector3 pos;
	Vector3 targetPos;

	private float agentToPatrolDistance;
	private float agentToTargetDistance;

	[SerializeField] private AudioClip EnemyMoveSE;
	private AudioSource audio_source;

	void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		EnemyPatrol();
		audio_source = gameObject.GetComponent<AudioSource>();
		audio_source.clip = EnemyMoveSE;
	}

	void Update()
	{
		UpdateControl ();
		UpdateState ();
	}

	void UpdateControl()
	{
		if (GameController.GoalAndClear) {
			gameObject.SetActive (false);
		}

		if (GameController.Fall || GameController.GameIsOver) {
			gameObject.SetActive (false);
		}

		//Agentと目的地の距離
		agentToPatrolDistance = Vector3.Distance
			(this.navMeshAgent.transform.position, pos);

		//Agentとプレイヤーの距離
		agentToTargetDistance = Vector3.Distance
			(this.navMeshAgent.transform.position,target.transform.position);
	}
		
	void UpdateState()
	{
		switch (state) {
		case EnemyState.PATROL:
			//プレイヤーとAgentの距離が7.0f以下になると追跡開始
			if (agentToTargetDistance <= 7.0f) {
				Debug.Log ("Chasing");
				EnemyChasing ();
			}
			//Agentと目的地の距離が4.0f未満になると次の目的地をランダム指定
			else if (agentToPatrolDistance < 4.0f) {
					Debug.Log ("Patrol");
					EnemyPatrol ();
				}
			break;

		case EnemyState.CHASE:
			EnemyChasing ();
			if (agentToTargetDistance > 7.0f) {
				Debug.Log ("ChangePatrol");
				EnemyPatrol ();
			}
			break;
		}
	}

	void EnemyPatrol()
	{
		state = EnemyState.PATROL;

		var x = Random.Range(moveArea.xMin, moveArea.xMax);
		var z = Random.Range(moveArea.zMin, moveArea.zMax);
		pos = new Vector3 (x, 0, z);
		navMeshAgent.SetDestination(pos);
	}

	void EnemyChasing()
	{
		state = EnemyState.CHASE;

		navMeshAgent.speed = chasingSpeed;
		targetPos = target.transform.position;
		navMeshAgent.SetDestination(targetPos);
	}
}

/*
void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		EnemyPatrol();
		audio_source = gameObject.GetComponent<AudioSource>();
		audio_source.clip = EnemyMoveSE;
		Patrol = true;
		Chase = false;
	}

	void Update()
	{
		if (GameController.GoalAndClear) {
			gameObject.SetActive (false);
		}

		if (GameController.Fall || GameController.GameIsOver) {
			return;
		}

		//Agentと目的地の距離
		agentToPatrolDistance = Vector3.Distance
			(this.navMeshAgent.transform.position, pos);

		//Agentとプレイヤーの距離
		agentToTargetDistance = Vector3.Distance
			(this.navMeshAgent.transform.position,target.transform.position);
		
		//Agentと目的地の距離が7.0f未満になると次の目的地をランダム指定
		if (agentToPatrolDistance < 7.0f && Patrol == true && Chase == false) {
			Debug.Log ("Patrol");
			EnemyPatrol ();
		}

		//プレイヤーとAgentの距離が7.0f以下になると追跡開始
		else if (agentToTargetDistance <= 7.0f) {
			Debug.Log ("Chasing");
			Patrol = false;
			Chase = true;
			EnemyChasing ();
		} else if (agentToTargetDistance > 7.0f) {
			Debug.Log ("ChangePatrol");
			Patrol = true;
			Chase = false;
			return;
		}
	}

	void EnemyPatrol()
	{
		var x = Random.Range(moveArea.xMin, moveArea.xMax);
		var z = Random.Range(moveArea.zMin, moveArea.zMax);
		pos = new Vector3 (x, 0, z);
		navMeshAgent.SetDestination(pos);
	}

	void EnemyChasing()
	{
		navMeshAgent.speed = chasingSpeed;
		pos = target.transform.position;
		navMeshAgent.SetDestination(pos);
	}
*/