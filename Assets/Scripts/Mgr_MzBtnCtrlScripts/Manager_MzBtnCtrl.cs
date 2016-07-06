using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzBtnCtrl : MonoBehaviour {

    private Mgr_MzBtnCtrl mgrMzBtnCtrl;

    private event EveHandMgrState mzBtnCtrlDUMMY;

    private event EveHandMgrState mzBtnCtrlREADY;

    private event EveHandMgrState mzBtnCtrlREADYGO;

    private event EveHandMgrState mzBtnCtrlPLAYING;

    private event EveHandMgrState mzBtnCtrlGIVEUP;

    private event EveHandMgrState mzBtnCtrlMAP;

    private event EveHandMgrState mzBtnCtrlTIMEUP;

    private event EveHandMgrState mzBtnCtrlFAILURE;

    private event EveHandMgrState mzBtnCtrlGOAL;

    private event EveHandMgrState mzBtnCtrlCLEAR;

    private event EveHandMgrState mzBtnCtrlGAMEOVER;

    private event EveHandMgrState mzBtnCtrlEMPTY;

    void Awake() {
        mgrMzBtnCtrl = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrl>();
    }

    void Start() {

        //DUMMYステート
        //READYステート
        //READYGOステート
        //PLAYINGステート
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrl.AppearBtnCtrlEvent);
        //GIVEUPステート
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrl.HideBtnCtrlEvent);
        //MAPステート
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrl.HideBtnCtrlEvent);
        //TIMEUPステート
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrl.HideBtnCtrlEvent);
        //FAILUREステート
        mzBtnCtrlFAILURE += new EveHandMgrState(mgrMzBtnCtrl.HideBtnCtrlEvent);
        //GOALステート
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrl.HideBtnCtrlEvent);
        //CLEARステート
        //GAMEOVERステート
        //EMPTYステート
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrl.HideBtnCtrlEvent);
    }

    public void EventDUMMY(object o, EventArgs e) {
        this.mzBtnCtrlDUMMY(this, EventArgs.Empty);
    }

    public void EventREADY(object o, EventArgs e) {
        this.mzBtnCtrlREADY(this, EventArgs.Empty);
    }

    public void EventREADYGO(object o, EventArgs e) {
        this.mzBtnCtrlREADYGO(this, EventArgs.Empty);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzBtnCtrlPLAYING(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.mzBtnCtrlGIVEUP(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzBtnCtrlMAP(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.mzBtnCtrlTIMEUP(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.mzBtnCtrlFAILURE(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.mzBtnCtrlGOAL(this, EventArgs.Empty);
    }

    public void EventCLEAR(object o, EventArgs e) {
        this.mzBtnCtrlCLEAR(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.mzBtnCtrlGAMEOVER(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzBtnCtrlEMPTY(this, EventArgs.Empty);
    }
}