using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_GameSE02 : MonoBehaviour {

    private Mgr_GameSE02 mgrMzSE02;

    private event EveHandMgrState mzSE02MAZESTART;

    private event EveHandMgrState mzSE02READY;

    private event EveHandMgrState mzSE02READYGO;

    private event EveHandMgrState mzSE02PLAYING;

    private event EveHandMgrState mzSE02GIVEUP;

    private event EveHandMgrState mzSE02MAP;

    private event EveHandMgrState mzSE02TIMEUP;

    private event EveHandMgrState mzSE02FAILURE;

    private event EveHandMgrState mzSE02GOAL;

    private event EveHandMgrState mzSE02CLEAR;

    private event EveHandMgrState mzSE02GAMEOVER;

    private event EveHandMgrState mzSE02EMPTY;

    void Awake() {
        mgrMzSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Mgr_GameSE02>();
    }

    void Start() {
        //MAZESTARTステート
        //READYステート
        //READYGOステート
        //PLAYINGステート
        //GIVEUPステート
        //MAPステート
        //TIMEUPステート
        //FAILUREステート
        //GOALステート
        mzSE02GOAL += new EveHandMgrState(mgrMzSE02.SEGoal01Event);
        //CLEARステート
        //GAMEOVERステート
        //EMPTYステート
    }

    public void EventMAZESTART(object o, EventArgs e) {
        this.mzSE02MAZESTART(this, EventArgs.Empty);
    }

    public void EventREADY(object o, EventArgs e) {
        this.mzSE02READY(this, EventArgs.Empty);
    }

    public void EventREADYGO(object o, EventArgs e) {
        this.mzSE02READYGO(this, EventArgs.Empty);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzSE02PLAYING(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.mzSE02GIVEUP(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzSE02MAP(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.mzSE02TIMEUP(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.mzSE02FAILURE(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.mzSE02GOAL(this, EventArgs.Empty);
    }

    public void EventCLEAR(object o, EventArgs e) {
        this.mzSE02CLEAR(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.mzSE02GAMEOVER(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzSE02EMPTY(this, EventArgs.Empty);
    }
}