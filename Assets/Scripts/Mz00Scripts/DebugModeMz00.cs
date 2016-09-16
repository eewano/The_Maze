using System;
using UnityEngine;

public class DebugModeMz00 : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    private Mgr_DebugItemGetMz00 mgrDebugItemGetMz00;
    private Mgr_DebugTimer mgrDebugTimer;
    private Mgr_DebugMoveState mgrDebugMoveState;

    private bool debugON = false;

    private event EventHandler debugModeON;

    private event EventHandler debugModeOFF;

    void Awake() {
        mgrDebugItemGetMz00 = GameObject.Find("DebugModeMz00").GetComponent<Mgr_DebugItemGetMz00>();
        mgrDebugTimer = GameObject.Find("DebugModeMz00").GetComponent<Mgr_DebugTimer>();
        mgrDebugMoveState = GameObject.Find("DebugModeMz00").GetComponent<Mgr_DebugMoveState>();
    }

    void Start() {
        debugModeON += new EventHandler(mgrDebugItemGetMz00.DebugModeON);
        debugModeON += new EventHandler(mgrDebugTimer.DebugModeON);
        debugModeON += new EventHandler(mgrDebugMoveState.DebugModeON);

        debugModeOFF += new EventHandler(mgrDebugItemGetMz00.DebugModeOFF);
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