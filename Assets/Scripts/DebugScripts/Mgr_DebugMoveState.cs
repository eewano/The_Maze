using System;
using UnityEngine;

public class Mgr_DebugMoveState : MonoBehaviour {

    private ManagerMzMaster managerMzMaster;

    private bool debugStateON = false;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
    }

    void Update() {
        if (Input.GetKeyUp("1") && debugStateON == true) {
            managerMzMaster.DebugDUMMY();
        }
        else if (Input.GetKeyUp("2") && debugStateON == true) {
            managerMzMaster.DebugREADY();
        }
        else if (Input.GetKeyUp("3") && debugStateON == true) {
            managerMzMaster.DebugREADYGO();
        }
        else if (Input.GetKeyUp("4") && debugStateON == true) {
            managerMzMaster.DebugPLAYING();
        }
        else if (Input.GetKeyUp("5") && debugStateON == true) {
            managerMzMaster.DebugGIVEUP();
        }
        else if (Input.GetKeyUp("6") && debugStateON == true) {
            managerMzMaster.DebugMAP();
        }
        else if (Input.GetKeyUp("7") && debugStateON == true) {
            managerMzMaster.DebugTIMEUP();
        }
        else if (Input.GetKeyUp("8") && debugStateON == true) {
            managerMzMaster.DebugFAILURE();
        }
        else if (Input.GetKeyUp("9") && debugStateON == true) {
            managerMzMaster.DebugGOAL();
        }
        else if (Input.GetKeyUp("0") && debugStateON == true) {
            managerMzMaster.DebugCLEAR();
        }
        else if (Input.GetKeyUp("q") && debugStateON == true) {
            managerMzMaster.DebugGAMEOVER();
        }
        else if (Input.GetKeyUp("w") && debugStateON == true) {
            managerMzMaster.DebugEMPTY();
        }
    }

    public void DebugModeON(object o, EventArgs e) {
        debugStateON = true;
    }

    public void DebugModeOFF(object o, EventArgs e) {
        debugStateON = false;
    }
}