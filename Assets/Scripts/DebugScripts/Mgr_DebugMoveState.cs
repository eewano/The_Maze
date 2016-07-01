using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mgr_DebugMoveState : MonoBehaviour {

    [SerializeField]
    private Text debugOnOffText;
    private ManagerMzMaster managerMzMaster;

    private bool debugState;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
    }

    void Start() {
        debugState = false;
        debugOnOffText.text = "";
    }

    void Update() {
        DebugSwitch();
        DebugMoveState();
    }

    void DebugSwitch() {
        if (Input.GetKeyUp("d") && debugState == false) {
            debugState = true;
            debugOnOffText.text = "デバッグステート";
        }
        else if (Input.GetKeyUp("d") && debugState == true) {
            debugState = false;
            debugOnOffText.text = "";
        }
    }

    void DebugMoveState() {
        if (Input.GetKeyUp("1") && debugState == true) {
            managerMzMaster.DebugDUMMY();
        }
        else if (Input.GetKeyUp("2") && debugState == true) {
            managerMzMaster.DebugREADY();
        }
        else if (Input.GetKeyUp("3") && debugState == true) {
            managerMzMaster.DebugREADYGO();
        }
        else if (Input.GetKeyUp("4") && debugState == true) {
            managerMzMaster.DebugPLAYING();
        }
        else if (Input.GetKeyUp("5") && debugState == true) {
            managerMzMaster.DebugGIVEUP();
        }
        else if (Input.GetKeyUp("6") && debugState == true) {
            managerMzMaster.DebugMAP();
        }
        else if (Input.GetKeyUp("7") && debugState == true) {
            managerMzMaster.DebugTIMEUP();
        }
        else if (Input.GetKeyUp("8") && debugState == true) {
            managerMzMaster.DebugFAILURE();
        }
        else if (Input.GetKeyUp("9") && debugState == true) {
            managerMzMaster.DebugGOAL();
        }
        else if (Input.GetKeyUp("0") && debugState == true) {
            managerMzMaster.DebugCLEAR();
        }
        else if (Input.GetKeyUp("q") && debugState == true) {
            managerMzMaster.DebugGAMEOVER();
        }
        else if (Input.GetKeyUp("w") && debugState == true) {
            managerMzMaster.DebugEMPTY();
        }
    }
}