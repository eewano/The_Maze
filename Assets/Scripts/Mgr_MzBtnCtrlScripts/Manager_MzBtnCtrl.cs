using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzBtnCtrl : MonoBehaviour {

    private Mgr_MzBtnCtrlF mgrMzBtnCtrlF;
    private Mgr_MzBtnCtrlB mgrMzBtnCtrlB;
    private Mgr_MzBtnCtrlL mgrMzBtnCtrlL;
    private Mgr_MzBtnCtrlR mgrMzBtnCtrlR;
    private Mgr_MzBtnCtrlFL mgrMzBtnCtrlFL;
    private Mgr_MzBtnCtrlFR mgrMzBtnCtrlFR;
    private Mgr_MzBtnCtrlBL mgrMzBtnCtrlBL;
    private Mgr_MzBtnCtrlBR mgrMzBtnCtrlBR;

    private event EveHandMgrState mzBtnCtrlMAZESTART;

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
        mgrMzBtnCtrlF = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlF>();
        mgrMzBtnCtrlB = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlB>();
        mgrMzBtnCtrlL = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlL>();
        mgrMzBtnCtrlR = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlR>();
        mgrMzBtnCtrlFL = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlFL>();
        mgrMzBtnCtrlFR = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlFR>();
        mgrMzBtnCtrlBL = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlBL>();
        mgrMzBtnCtrlBR = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Mgr_MzBtnCtrlBR>();
    }

    void Start() {

        //MAZESTARTステート
        //READYステート
        //READYGOステート
        //PLAYINGステート
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlF.AppearBtnCtrlEvent);
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlB.AppearBtnCtrlEvent);
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlL.AppearBtnCtrlEvent);
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlR.AppearBtnCtrlEvent);
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlFL.AppearBtnCtrlEvent);
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlFR.AppearBtnCtrlEvent);
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlBL.AppearBtnCtrlEvent);
        mzBtnCtrlPLAYING += new EveHandMgrState(mgrMzBtnCtrlBR.AppearBtnCtrlEvent);
        //GIVEUPステート
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlF.HideBtnCtrlEvent);
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlB.HideBtnCtrlEvent);
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlL.HideBtnCtrlEvent);
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlR.HideBtnCtrlEvent);
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlFL.HideBtnCtrlEvent);
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlFR.HideBtnCtrlEvent);
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlBL.HideBtnCtrlEvent);
        mzBtnCtrlGIVEUP += new EveHandMgrState(mgrMzBtnCtrlBR.HideBtnCtrlEvent);
        //MAPステート
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlF.HideBtnCtrlEvent);
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlB.HideBtnCtrlEvent);
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlL.HideBtnCtrlEvent);
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlR.HideBtnCtrlEvent);
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlFL.HideBtnCtrlEvent);
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlFR.HideBtnCtrlEvent);
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlBL.HideBtnCtrlEvent);
        mzBtnCtrlMAP += new EveHandMgrState(mgrMzBtnCtrlBR.HideBtnCtrlEvent);
        //TIMEUPステート
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlF.HideBtnCtrlEvent);
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlB.HideBtnCtrlEvent);
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlL.HideBtnCtrlEvent);
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlR.HideBtnCtrlEvent);
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlFL.HideBtnCtrlEvent);
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlFR.HideBtnCtrlEvent);
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlBL.HideBtnCtrlEvent);
        mzBtnCtrlTIMEUP += new EveHandMgrState(mgrMzBtnCtrlBR.HideBtnCtrlEvent);
        //FAILUREステート
        //GOALステート
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlF.HideBtnCtrlEvent);
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlB.HideBtnCtrlEvent);
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlL.HideBtnCtrlEvent);
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlR.HideBtnCtrlEvent);
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlFL.HideBtnCtrlEvent);
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlFR.HideBtnCtrlEvent);
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlBL.HideBtnCtrlEvent);
        mzBtnCtrlGOAL += new EveHandMgrState(mgrMzBtnCtrlBR.HideBtnCtrlEvent);
        //CLEARステート
        //GAMEOVERステート
        //EMPTYステート
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlF.HideBtnCtrlEvent);
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlB.HideBtnCtrlEvent);
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlL.HideBtnCtrlEvent);
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlR.HideBtnCtrlEvent);
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlFL.HideBtnCtrlEvent);
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlFR.HideBtnCtrlEvent);
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlBL.HideBtnCtrlEvent);
        mzBtnCtrlEMPTY += new EveHandMgrState(mgrMzBtnCtrlBR.HideBtnCtrlEvent);
    }

    public void EventMAZESTART(object o, EventArgs e) {
        this.mzBtnCtrlMAZESTART(this, EventArgs.Empty);
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