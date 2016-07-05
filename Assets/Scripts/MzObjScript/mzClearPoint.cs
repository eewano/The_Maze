using System;
using UnityEngine;

public class mzClearPoint : MonoBehaviour {

    private ManagerMzMaster managerMzMaster;
    private GoalCameraMove goalCameraMove;

    private event EveHandMoveState toGOALState;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        goalCameraMove = GameObject.Find("MzCamGoal").GetComponent<GoalCameraMove>();
    }

    void Start() {
        toGOALState += new EveHandMoveState(managerMzMaster.ToGOALState);
        toGOALState += new EveHandMoveState(goalCameraMove.ToGOALState);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            this.toGOALState(this, EventArgs.Empty);
        }
    }
}