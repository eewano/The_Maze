using UnityEngine;
using System.Collections;

public class Enemy01Move : MonoBehaviour {

	[SerializeField] private GameObject target;
	NavMeshAgent navMeshAgent;

	static Vector3 pos;

	float agentToPatroldistance;
	float agentToTargetdistance;

	[SerializeField] private AudioClip EnemyMoveSE;
	private AudioSource audio_source;

	void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		EnemyPatrol01();
		audio_source = gameObject.GetComponent<AudioSource>();
		audio_source.clip = EnemyMoveSE;
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
		agentToPatroldistance = Vector3.Distance(this.navMeshAgent.transform.position, pos);

		//Agentとプレイヤーの距離
		agentToTargetdistance = Vector3.Distance(this.navMeshAgent.transform.position,target.transform.position);

		//プレイヤーとAgentの距離が8.0f以下になると追跡開始
		if(agentToTargetdistance <= 6.0f){
			EnemyTracking01();

			//プレイヤーと目的地の距離が4.0f以下になると次の目的地をランダム指定
		} else if(agentToPatroldistance < 4.0f){
			EnemyPatrol01();
		}
	}

	public void EnemyPatrol01()
	{
		navMeshAgent.speed = 1.0f;
		var x = Random.Range(8.0f, 20.0f);
		var z = Random.Range(-2.0f, 20.0f);
		pos = new Vector3 (x, 0, z);
		navMeshAgent.SetDestination(pos);
	}

	void EnemyTracking01()
	{
		navMeshAgent.speed = 1.2f;
		pos = target.transform.position;
		navMeshAgent.SetDestination(pos);
	}
}