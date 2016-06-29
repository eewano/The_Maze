using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzCam : MonoBehaviour {

    private Mgr_MzCamPlayer mgrMzCamPlayer;
    private Mgr_MzCamMap mgrMzCamMap;
    private Mgr_MzCamGoal mgrMzCamGoal;

    private event EveHandMgrState mzCamMAZESTART;

    private event EveHandMgrState mzCamREADY;

    private event EveHandMgrState mzCamREADYGO;

    private event EveHandMgrState mzCamPLAYING;

    private event EveHandMgrState mzCamGIVEUP;

    private event EveHandMgrState mzCamMAP;

    private event EveHandMgrState mzCamTIMEUP;

    private event EveHandMgrState mzCamFAILURE;

    private event EveHandMgrState mzCamGOAL;

    private event EveHandMgrState mzCamCLEAR;

    private event EveHandMgrState mzCamGAMEOVER;

    private event EveHandMgrState mzCamEMPTY;

    void Awake() {
        mgrMzCamPlayer = GameObject.Find("Mgr_MzCamera").GetComponent<Mgr_MzCamPlayer>();
        mgrMzCamMap = GameObject.Find("Mgr_MzCamera").GetComponent<Mgr_MzCamMap>();
        mgrMzCamGoal = GameObject.Find("Mgr_MzCamera").GetComponent<Mgr_MzCamGoal>();
    }

    void Start() {
        //MAZESTARTステート
        mzCamMAZESTART += new EveHandMgrState(mgrMzCamPlayer.AppearCamEvent);
        //READYステート
        mzCamREADY += new EveHandMgrState(mgrMzCamPlayer.AppearCamEvent);
        //READYGOステート
        //PLAYINGステート
        mzCamPLAYING += new EveHandMgrState(mgrMzCamMap.HideCamEvent);
        mzCamPLAYING += new EveHandMgrState(mgrMzCamPlayer.AppearCamEvent);
        //GIVEUPステート
        //MAPステート
        mzCamMAP += new EveHandMgrState(mgrMzCamPlayer.HideCamEvent);
        mzCamMAP += new EveHandMgrState(mgrMzCamMap.AppearCamEvent);
        //TIMEUPステート
        //FAILUREステート
        //GOALステート
        mzCamGOAL += new EveHandMgrState(mgrMzCamPlayer.HideCamEvent);
        mzCamGOAL += new EveHandMgrState(mgrMzCamGoal.AppearCamEvent);
        //CLEARステート
        //GAMEOVERステート
        //EMPTYステート
        mzCamEMPTY += new EveHandMgrState(mgrMzCamMap.HideCamEvent);
        mzCamEMPTY += new EveHandMgrState(mgrMzCamGoal.HideCamEvent);
        mzCamEMPTY += new EveHandMgrState(mgrMzCamPlayer.AppearCamEvent);
    }

    public void EventMAZESTART(object o, EventArgs e) {
        this.mzCamMAZESTART(this, EventArgs.Empty);
    }

    public void EventREADY(object o, EventArgs e) {
        this.mzCamREADY(this, EventArgs.Empty);
    }

    public void EventREADYGO(object o, EventArgs e) {
        this.mzCamREADYGO(this, EventArgs.Empty);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzCamPLAYING(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.mzCamGIVEUP(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzCamMAP(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.mzCamTIMEUP(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.mzCamFAILURE(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.mzCamGOAL(this, EventArgs.Empty);
    }

    public void EventCLEAR(object o, EventArgs e) {
        this.mzCamCLEAR(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.mzCamGAMEOVER(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzCamEMPTY(this, EventArgs.Empty);
    }
}