using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzButton : MonoBehaviour {

    private Mgr_MzBtnGiveUp mgrMzBtnGiveUp;
    private Mgr_MzBtnCancel mgrMzBtnCancel;
    private Mgr_MzBtnGameOver mgrMzBtnGameOver;
    private Mgr_MzBtnMap mgrMzBtnMap;
    private Mgr_MzBtnMapToMz mgrMzBtnMapToMz;
    private Mgr_MzBtnRestart mgrMzBtnRestart;
    private Mgr_MzBtnNextMz mgrMzBtnNextMz;
    private Mgr_MzBtnToTitle mgrMzBtnToTitle;

    private event EveHandMgrState mzBtnMAZESTART;

    private event EveHandMgrState mzBtnREADY;

    private event EveHandMgrState mzBtnREADYGO;

    private event EveHandMgrState mzBtnPLAYING;

    private event EveHandMgrState mzBtnGIVEUP;

    private event EveHandMgrState mzBtnMAP;

    private event EveHandMgrState mzBtnTIMEUP;

    private event EveHandMgrState mzBtnFAILURE;

    private event EveHandMgrState mzBtnGOAL;

    private event EveHandMgrState mzBtnCLEAR;

    private event EveHandMgrState mzBtnGAMEOVER;

    private event EveHandMgrState mzBtnEMPTY;

    void Awake() {
        mgrMzBtnGiveUp = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnGiveUp>();
        mgrMzBtnCancel = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnCancel>();
        mgrMzBtnGameOver = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnGameOver>();
        mgrMzBtnMap = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnMap>();
        mgrMzBtnMapToMz = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnMapToMz>();
        mgrMzBtnRestart = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnRestart>();
        mgrMzBtnNextMz = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnNextMz>();
        mgrMzBtnToTitle = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnToTitle>();
    }

    void Start() {
        //MAZESTARTステート
        //READYステート
        //READYGOステート
        //PLAYINGステート
        mzBtnPLAYING += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzBtnPLAYING += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzBtnPLAYING += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);

        mzBtnPLAYING += new EveHandMgrState(mgrMzBtnGiveUp.AppearBtnEvent);
        //GIVEUPステート
        mzBtnGIVEUP += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzBtnGIVEUP += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);

        mzBtnGIVEUP += new EveHandMgrState(mgrMzBtnCancel.AppearBtnEvent);
        mzBtnGIVEUP += new EveHandMgrState(mgrMzBtnGameOver.AppearBtnEvent);
        //MAPステート
        mzBtnMAP += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzBtnMAP += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);

        mzBtnMAP += new EveHandMgrState(mgrMzBtnMapToMz.AppearBtnEvent);
        //TIMEUPステート
        mzBtnTIMEUP += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzBtnTIMEUP += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        //FAILUREステート
        mzBtnFAILURE += new EveHandMgrState(mgrMzBtnRestart.AppearBtnEvent);
        mzBtnFAILURE += new EveHandMgrState(mgrMzBtnGameOver.AppearBtnEvent);
        //GOALステート
        mzBtnGOAL += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        //CLEARステート
        mzBtnCLEAR += new EveHandMgrState(mgrMzBtnNextMz.AppearBtnEvent);
        mzBtnCLEAR += new EveHandMgrState(mgrMzBtnToTitle.AppearBtnEvent);
        //GAMEOVERステート
        mzBtnGAMEOVER += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzBtnGAMEOVER += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        //EMPTYステート
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzBtnEMPTY += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);
    }

    public void EventMAZESTART(object o, EventArgs e) {
        this.mzBtnMAZESTART(this, EventArgs.Empty);
    }

    public void EventREADY(object o, EventArgs e) {
        this.mzBtnREADY(this, EventArgs.Empty);
    }

    public void EventREADYGO(object o, EventArgs e) {
        this.mzBtnREADYGO(this, EventArgs.Empty);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzBtnPLAYING(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.mzBtnGIVEUP(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzBtnMAP(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.mzBtnTIMEUP(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.mzBtnFAILURE(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.mzBtnGOAL(this, EventArgs.Empty);
    }

    public void EventCLEAR(object o, EventArgs e) {
        this.mzBtnCLEAR(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.mzBtnGAMEOVER(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzBtnEMPTY(this, EventArgs.Empty);
    }
}