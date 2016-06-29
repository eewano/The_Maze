using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzLabel : MonoBehaviour {

    private Mgr_MzLabelLightGet mgrMzLabelLightGet;
    private Mgr_MzLabelCroquetteGet mgrMzLabelCroquetteGet;
    private Mgr_MzLabelMapGet mgrMzLabelMapGet;

    private event EveHandMgrState mzLabelMAZESTART;

    private event EveHandMgrState mzLabelREADY;

    private event EveHandMgrState mzLabelREADYGO;

    private event EveHandMgrState mzLabelPLAYING;

    private event EveHandMgrState mzLabelGIVEUP;

    private event EveHandMgrState mzLabelMAP;

    private event EveHandMgrState mzLabelTIMEUP;

    private event EveHandMgrState mzLabelFAILURE;

    private event EveHandMgrState mzLabelGOAL;

    private event EveHandMgrState mzLabelCLEAR;

    private event EveHandMgrState mzLabelGAMEOVER;

    private event EveHandMgrState mzLabelEMPTY;

    void Awake() {
        mgrMzLabelLightGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelLightGet>();
        mgrMzLabelCroquetteGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelCroquetteGet>();
        mgrMzLabelMapGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelMapGet>();
    }

    void Start() {
        //MAZESTARTステート
        //READYステート
        //READYGOステート
        //PLAYINGステート
        //GIVEUPステート
        //MAPステート
        //TIMEUPステート
        mzLabelTIMEUP += new EveHandMgrState(mgrMzLabelLightGet.HideLabelEvent);
        mzLabelTIMEUP += new EveHandMgrState(mgrMzLabelCroquetteGet.HideLabelEvent);
        mzLabelTIMEUP += new EveHandMgrState(mgrMzLabelMapGet.HideLabelEvent);
        //FAILUREステート
        //GOALステート
        mzLabelGOAL += new EveHandMgrState(mgrMzLabelLightGet.HideLabelEvent);
        mzLabelGOAL += new EveHandMgrState(mgrMzLabelCroquetteGet.HideLabelEvent);
        mzLabelGOAL += new EveHandMgrState(mgrMzLabelMapGet.HideLabelEvent);
        //CLEARステート
        //GAMEOVERステート
        mzLabelGAMEOVER += new EveHandMgrState(mgrMzLabelLightGet.HideLabelEvent);
        mzLabelGAMEOVER += new EveHandMgrState(mgrMzLabelCroquetteGet.HideLabelEvent);
        mzLabelGAMEOVER += new EveHandMgrState(mgrMzLabelMapGet.HideLabelEvent);
        //EMPTYステート
    }

    public void EventMAZESTART(object o, EventArgs e) {
        this.mzLabelMAZESTART(this, EventArgs.Empty);
    }

    public void EventREADY(object o, EventArgs e) {
        this.mzLabelREADY(this, EventArgs.Empty);
    }

    public void EventREADYGO(object o, EventArgs e) {
        this.mzLabelREADYGO(this, EventArgs.Empty);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzLabelPLAYING(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.mzLabelGIVEUP(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzLabelMAP(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.mzLabelTIMEUP(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.mzLabelFAILURE(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.mzLabelGOAL(this, EventArgs.Empty);
    }

    public void EventCLEAR(object o, EventArgs e) {
        this.mzLabelCLEAR(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.mzLabelGAMEOVER(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzLabelEMPTY(this, EventArgs.Empty);
    }
}