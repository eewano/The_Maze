using System;
using UnityEngine;

public class DebugMode : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    private Mgr_DebugItemGet mgrDebugItemGet;
    private Mgr_DebugTimer mgrDebugTimer;
    private Mgr_DebugMoveState mgrDebugMoveState;

    private bool debugON = false;

    private event EventHandler debugModeON;

    private event EventHandler debugModeOFF;

    void Awake() {
        mgrDebugItemGet = GameObject.Find("DebugMode").GetComponent<Mgr_DebugItemGet>();
        mgrDebugTimer = GameObject.Find("DebugMode").GetComponent<Mgr_DebugTimer>();
        mgrDebugMoveState = GameObject.Find("DebugMode").GetComponent<Mgr_DebugMoveState>();
    }

    void Start() {
        debugModeON += new EventHandler(mgrDebugItemGet.DebugModeON);
        debugModeON += new EventHandler(mgrDebugTimer.DebugModeON);
        debugModeON += new EventHandler(mgrDebugMoveState.DebugModeON);

        debugModeOFF += new EventHandler(mgrDebugItemGet.DebugModeOFF);
        debugModeOFF += new EventHandler(mgrDebugTimer.DebugModeOFF);
        debugModeOFF += new EventHandler(mgrDebugMoveState.DebugModeOFF);
    }

    void Update() {
        if (Input.GetKeyUp("i") && debugON == false) {
            debugON = true;
            this.debugModeON(this, EventArgs.Empty);
        }
        else if (Input.GetKeyUp("i") && debugON == true) {
            debugON = false;
            this.debugModeOFF(this, EventArgs.Empty);
        }
    }
}