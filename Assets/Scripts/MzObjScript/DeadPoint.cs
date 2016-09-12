using System;
using UnityEngine;

public class DeadPoint : MonoBehaviour {

    private ManagerMzMaster managerMzMaster;

    private event EveHandMoveState playerDead;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
    }

    void Start() {
        playerDead += new EveHandMoveState(managerMzMaster.ToFAILUREState);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            this.playerDead(this, EventArgs.Empty);
        }
    }
}