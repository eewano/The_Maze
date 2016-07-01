using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_GameSE01 : MonoBehaviour {

    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandMgrState mzSE01MAZESTART;

    private event EveHandMgrState mzSE01READY;

    private event EveHandMgrState mzSE01READYGO;

    private event EveHandMgrState mzSE01PLAYING;

    private event EveHandMgrState mzSE01GIVEUP;

    private event EveHandMgrState mzSE01MAP;

    private event EveHandMgrState mzSE01TIMEUP;

    private event EveHandMgrState mzSE01FAILURE;

    private event EveHandMgrState mzSE01GOAL;

    private event EveHandMgrState mzSE01CLEAR;

    private event EveHandMgrState mzSE01GAMEOVER;

    private event EveHandMgrState mzSE01EMPTY;

    void Awake() {
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        //MAZESTARTステート
        //READYステート
        //READYGOステート
        mzSE01READYGO += new EveHandMgrState(mgrMzSE01.SEReadyGoEvent);
        //PLAYINGステート
        //GIVEUPステート
        //MAPステート
        //TIMEUPステート
        mzSE01TIMEUP += new EveHandMgrState(mgrMzSE01.SETimeUpEvent);
        //FAILUREステート
        //GOALステート
        //CLEARステート
        //GAMEOVERステート
        //EMPTYステート
    }

    public void EventMAZESTART(object o, EventArgs e) {
        this.mzSE01MAZESTART(this, EventArgs.Empty);
    }

    public void EventREADY(object o, EventArgs e) {
        this.mzSE01READY(this, EventArgs.Empty);
    }

    public void EventREADYGO(object o, EventArgs e) {
        this.mzSE01READYGO(this, EventArgs.Empty);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzSE01PLAYING(this, EventArgs.Empty);
    }

    public void EventGIVEUP(object o, EventArgs e) {
        this.mzSE01GIVEUP(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzSE01MAP(this, EventArgs.Empty);
    }

    public void EventTIMEUP(object o, EventArgs e) {
        this.mzSE01TIMEUP(this, EventArgs.Empty);
    }

    public void EventFAILURE(object o, EventArgs e) {
        this.mzSE01FAILURE(this, EventArgs.Empty);
    }

    public void EventGOAL(object o, EventArgs e) {
        this.mzSE01GOAL(this, EventArgs.Empty);
    }

    public void EventCLEAR(object o, EventArgs e) {
        this.mzSE01CLEAR(this, EventArgs.Empty);
    }

    public void EventGAMEOVER(object o, EventArgs e) {
        this.mzSE01GAMEOVER(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzSE01EMPTY(this, EventArgs.Empty);
    }
}