using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class MoveArea {
    public float xMin, xMax, zMin, zMax;
}

public class EnemyRoboMove : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private MoveArea moveArea;
    [SerializeField]
    private float chasingSpeed;
    [SerializeField]
    private AudioSource sERoboMove;
    private ManagerPlayerMaster managerPlayerMaster;
    private float agentToPatrolDistance;
    private float agentToTargetDistance;
    private NavMeshAgent navMeshAgent;

    Vector3 pos;
    Vector3 targetPos;

    private bool moveON = false;

    enum EnemyState {
        PATROL,
        CHASE
    }

    private EnemyState state;

    private event EveHandToPlayer catchPlayer;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
    }

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        EnemyPatrol();
        catchPlayer = new EveHandToPlayer(managerPlayerMaster.CaughtByEmyRobo);
    }

    void Update() {
        if (moveON == true)
        {
            UpdateControl();
            UpdateState();
        }
    }

    void UpdateControl() {
        //Agentと目的地の距離
        agentToPatrolDistance = Vector3.Distance
        (this.navMeshAgent.transform.position, pos);

        //Agentとプレイヤーの距離
        agentToTargetDistance = Vector3.Distance
        (this.navMeshAgent.transform.position, target.transform.position);
    }

    void UpdateState() {
        switch (state) {
            case EnemyState.PATROL:
                //プレイヤーとAgentの距離が7.0f以下になると追跡開始
                if (agentToTargetDistance <= 7.0f)
                {
                    EnemyChasing();
                }
                    //Agentと目的地の距離が4.0f未満になると次の目的地をランダム指定
                else if (agentToPatrolDistance < 4.0f)
                {
                    EnemyPatrol();
                }
                break;

            case EnemyState.CHASE:
                EnemyChasing();
                if (agentToTargetDistance > 7.0f)
                {
                    EnemyPatrol();
                }
                break;
        }
    }

    void EnemyPatrol() {
        state = EnemyState.PATROL;
        var x = UnityEngine.Random.Range(moveArea.xMin, moveArea.xMax);
        var z = UnityEngine.Random.Range(moveArea.zMin, moveArea.zMax);
        pos = new Vector3(x, 0.0f, z);
        navMeshAgent.SetDestination(pos);
    }

    void EnemyChasing() {
        state = EnemyState.CHASE;
        navMeshAgent.speed = chasingSpeed;
        targetPos = target.transform.position;
        navMeshAgent.SetDestination(targetPos);
    }

    public void MovingStart(object o, EventArgs e) {
        moveON = true;
        sERoboMove.Play();
    }

    public void MovingStop(object o, EventArgs e) {
        moveON = false;
        sERoboMove.Stop();
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.catchPlayer(this, EventArgs.Empty);
            sERoboMove.Stop();
            StartCoroutine(EmySEMoveStop());
        }
    }

    IEnumerator EmySEMoveStop() {
        yield return new WaitForSeconds(6.0f);
        sERoboMove.Play();
    }
}