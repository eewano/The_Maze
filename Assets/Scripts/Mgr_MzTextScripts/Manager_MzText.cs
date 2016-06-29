using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzText : MonoBehaviour {

    private Mgr_MzTextClear mgrMzTextClear;
    private Mgr_MzTextFailure mgrMzTextFailure;
    private Mgr_MzTextGiveUp mgrMzTextGiveUp;
    private Mgr_MzTextGoal mgrMzTextGoal;
    private Mgr_MzTextIntro mgrMzTextIntro;
    private Mgr_MzTextReady mgrMzTextReady;
    private Mgr_MzTextTimeUp mgrMzTextTimeUp;

    private event EveHandMgrState mzTextMAZESTART;

    private event EveHandMgrState mzTextREADY;

    private event EveHandMgrState mzTextREADYGO;

    private event EveHandMgrState mzTextPLAYING;

    private event EveHandMgrState mzTextGIVEUP;

    private event EveHandMgrState mzTextMAP;

    private event EveHandMgrState mzTextTIMEUP;

    private event EveHandMgrState mzTextFAILURE;

    private event EveHandMgrState mzTextGOAL;

    private event EveHandMgrState mzTextCLEAR;

    private event EveHandMgrState mzTextGAMEOVER;

    private event EveHandMgrState mzTextEMPTY;

    void Awake() {
        mgrMzTextClear = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextClear>();
        mgrMzTextFailure = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextFailure>();
        mgrMzTextGiveUp = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextGiveUp>();
        mgrMzTextGoal = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextGoal>();
        mgrMzTextIntro = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextIntro>();
        mgrMzTextReady = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextReady>();
        mgrMzTextTimeUp = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextTimeUp>();
    }

    void Start() {
        //MAZESTARTステート
        //READYステート
        mzTextREADY += new EveHandMgrState(mgrMzTextIntro.AppearTextEvent);
        //READYGOステート
        mzTextREADYGO += new EveHandMgrState(mgrMzTextIntro.HideTextEvent);
        mzTextREADYGO += new EveHandMgrState(mgrMzTextReady.AppearTextEvent);
        //PLAYINGステート
        mzTextPLAYING += new EveHandMgrState(mgrMzTextReady.HideTextEvent);
        mzTextPLAYING += new EveHandMgrState(mgrMzTextGiveUp.HideTextEvent);
        //GIVEUPステート
        mzTextGIVEUP += new EveHandMgrState(mgrMzTextGiveUp.AppearTextEvent);
        //MAPステート
        //TIMEUPステート
        mzTextTIMEUP += new EveHandMgrState(mgrMzTextTimeUp.AppearTextEvent);
        //FAILUREステート
        mzTextFAILURE += new EveHandMgrState(mgrMzTextTimeUp.HideTextEvent);
        mzTextFAILURE += new EveHandMgrState(mgrMzTextFailure.AppearTextEvent);
        //GOALステート
        mzTextGOAL += new EveHandMgrState(mgrMzTextGoal.AppearTextEvent);
        //CLEARステート
        mzTextCLEAR += new EveHandMgrState(mgrMzTextGoal.HideTextEvent);
        mzTextCLEAR += new EveHandMgrState(mgrMzTextClear.AppearTextEvent);
        //GAMEOVERステート
        mzTextGAMEOVER += new EveHandMgrState(mgrMzTextGiveUp.HideTextEvent);
        mzTextGAMEOVER += new EveHandMgrState(mgrMzTextFailure.HideTextEvent);
        //EMPTYステート
        mzTextEMPTY += new EveHandMgrState(mgrMzTextClear.HideTextEvent);
        mzTextEMPTY += new EveHandMgrState(mgrMzTextFailure.HideTextEvent);
        mzTextEMPTY += new EveHandMgrState(mgrMzTextGiveUp.HideTextEvent);
        mzTextEMPTY += new EveHandMgrState(mgrMzTextGoal.HideTextEvent);
        mzTextEMPTY += new EveHandMgrState(mgrMzTextIntro.HideTextEvent);
        mzTextEMPTY += new EveHandMgrState(mgrMzTextReady.HideTextEvent);
        mzTextEMPTY += new EveHandMgrState(mgrMzTextTimeUp.HideTextEvent);
    }

    public void EventMAZESTART(object o, EventArgs e) {
        this.mzTextMAZESTART(this, EventArgs.Empty);
    }

    public void EventREADY(object o, EventArgs e) {
        this.mzTextREADY(this, EventArgs.Empty);
    }

    public void EventREADYGO(object o, EventArgs e) {
        this.mzTextREADYGO(this, EventArgs.Empty);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzTextPLAYING(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.mzTextGIVEUP(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzTextMAP(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.mzTextTIMEUP(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.mzTextFAILURE(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.mzTextGOAL(this, EventArgs.Empty);
    }

    public void EventCLEAR(object o, EventArgs e) {
        this.mzTextCLEAR(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.mzTextGAMEOVER(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzTextEMPTY(this, EventArgs.Empty);
    }
}