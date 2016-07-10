﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerMzMaster : MonoBehaviour {

    [SerializeField]
    private GameObject playerGoal;
    [SerializeField]
    private GameObject mzCeiling;
    private ManagerPlayerMaster managerPlayerMaster;
    private Manager_GameSE01 managerMzSE01;
    private Manager_GameSE02 managerMzSE02;
    private Manager_MzText managerMzText;
    private Manager_MzButton managerMzButton;
    private Manager_MzBtnCtrl managerMzBtnCtrl;
    private Manager_MzLabel managerMzLabel;
    private Manager_MzCam managerMzCam;
    private Mgr_MzTextTimer mgrMzTextTimer;
    private AudioSource mzBGM;
    private Mgr_FadeImage mgrFadeImage;
    private Manager_DirLight managerDirLight;

    //敵がいる迷路のみ使用
    private Mgr_Enemy mgrEnemy;

    private event EveHandMgrState mzEventREADY;

    private event EveHandMgrState mzEventREADYGO;

    private event EveHandMgrState mzEventPLAYING;

    private event EveHandMgrState mzEventGIVEUP;

    private event EveHandMgrState mzEventMAP;

    private event EveHandMgrState mzEventTIMEUP;

    private event EveHandMgrState mzEventFAILURE;

    private event EveHandMgrState mzEventGOAL;

    private event EveHandMgrState mzEventCLEAR;

    private event EveHandMgrState mzEventGAMEOVER;

    private event EveHandMgrState mzEventEMPTY;

    private event EveHandMzTimer mzTimerStart;

    private event EveHandMzTimer mzTimerStop;

    private event EveHandToPlayer playerMoveOn;

    private event EveHandToPlayer playerMoveOff;

    private event EveHandFadeImage toFadeBlack;

    private enum GameState {
        DUMMY,
        READY,
        READYGO,
        PLAYING,
        GIVEUP,
        MAP,
        TIMEUP,
        FAILURE,
        GOAL,
        CLEAR,
        GAMEOVER,
        EMPTY
    }

    private GameState state;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        managerMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Manager_GameSE01>();
        managerMzSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Manager_GameSE02>();
        managerMzText = GameObject.Find("Mgr_MzText").GetComponent<Manager_MzText>();
        managerMzButton = GameObject.Find("Mgr_MzButton").GetComponent<Manager_MzButton>();
        managerMzBtnCtrl = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Manager_MzBtnCtrl>();
        managerMzLabel = GameObject.Find("Mgr_MzLabel").GetComponent<Manager_MzLabel>();
        managerMzCam = GameObject.Find("Mgr_MzCamera").GetComponent<Manager_MzCam>();
        mgrMzTextTimer = GameObject.Find("Mgr_MzTimer").GetComponent<Mgr_MzTextTimer>();
        mzBGM = GameObject.Find("MzBGM").GetComponent<AudioSource>();
        mgrFadeImage = GameObject.Find("Mgr_FadeImage").GetComponent<Mgr_FadeImage>();
        managerDirLight = GameObject.Find("Mgr_DirLight").GetComponent<Manager_DirLight>();

        if (GameObject.Find("Mgr_Enemy")) {
            mgrEnemy = GameObject.Find("Mgr_Enemy").GetComponent<Mgr_Enemy>();
        }
        else
        {
            mgrEnemy = null;
        }
    }

    void Start() {
        //DUMMYステート
        //READYステート
        mzEventREADY += new EveHandMgrState(managerMzCam.EventREADY);
        mzEventREADY += new EveHandMgrState(managerMzText.EventREADY);

        mzEventREADY += new EveHandMgrState(mgrMzTextTimer.AppearTextEvent);
        //READYGOステート
        mzEventREADYGO += new EveHandMgrState(managerMzText.EventREADYGO);
        mzEventREADYGO += new EveHandMgrState(managerMzSE01.EventREADYGO);
        //PLAYINGステート
        mzEventPLAYING += new EveHandMgrState(managerMzCam.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerMzButton.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerMzBtnCtrl.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerMzText.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerDirLight.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerPlayerMaster.EventPLAYING);
        //GIVEUPステート
        mzEventGIVEUP += new EveHandMgrState(managerMzButton.EventGIVEUP);
        mzEventGIVEUP += new EveHandMgrState(managerMzBtnCtrl.EventGIVEUP);
        mzEventGIVEUP += new EveHandMgrState(managerMzText.EventGIVEUP);
        //MAPステート
        mzEventMAP += new EveHandMgrState(managerMzCam.EventMAP);
        mzEventMAP += new EveHandMgrState(managerMzButton.EventMAP);
        mzEventMAP += new EveHandMgrState(managerMzBtnCtrl.EventMAP);
        mzEventMAP += new EveHandMgrState(managerDirLight.EventMAP);
        mzEventMAP += new EveHandMgrState(managerPlayerMaster.EventMAP);
        //TIMEUPステート
        mzEventTIMEUP += new EveHandMgrState(managerMzButton.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzBtnCtrl.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzText.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzLabel.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzSE01.EventTIMEUP);
        //FAILUREステート
        mzEventFAILURE += new EveHandMgrState(managerMzButton.EventFAILURE);
        mzEventFAILURE += new EveHandMgrState(managerMzBtnCtrl.EventFAILURE);
        mzEventFAILURE += new EveHandMgrState(managerMzText.EventFAILURE);
        mzEventFAILURE += new EveHandMgrState(managerMzLabel.EventFAILURE);
        //GOALステート
        mzEventGOAL += new EveHandMgrState(managerMzCam.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzButton.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzBtnCtrl.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzText.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzLabel.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzSE02.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerDirLight.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerPlayerMaster.EventGOAL);
        //CLEARステート
        mzEventCLEAR += new EveHandMgrState(managerMzButton.EventCLEAR);
        mzEventCLEAR += new EveHandMgrState(managerMzText.EventCLEAR);
        //GAMEOVERステート
        mzEventGAMEOVER += new EveHandMgrState(managerMzButton.EventGAMEOVER);
        mzEventGAMEOVER += new EveHandMgrState(managerMzText.EventGAMEOVER);
        mzEventGAMEOVER += new EveHandMgrState(managerMzLabel.EventGAMEOVER);

        mzEventGAMEOVER += new EveHandMgrState(mgrMzTextTimer.HideTextEvent);
        //EMPTYステート
        mzEventEMPTY += new EveHandMgrState(managerMzCam.EventEMPTY);
        mzEventEMPTY += new EveHandMgrState(managerMzButton.EventEMPTY);
        mzEventEMPTY += new EveHandMgrState(managerMzBtnCtrl.EventEMPTY);
        mzEventEMPTY += new EveHandMgrState(managerMzText.EventEMPTY);

        mzEventEMPTY += new EveHandMgrState(mgrMzTextTimer.HideTextEvent);
        //タイマーの処理
        mzTimerStart += new EveHandMzTimer(mgrMzTextTimer.MzTimerStart);
        mzTimerStop += new EveHandMzTimer(mgrMzTextTimer.MzTimerStop);
        //プレイヤー操作のOnOff
        playerMoveOn += new EveHandToPlayer(managerPlayerMaster.PlayerCtrlOn);
        playerMoveOff += new EveHandToPlayer(managerPlayerMaster.PlayerCtrlOff);
        //フェード操作
        toFadeBlack += new EveHandFadeImage(mgrFadeImage.StartFadeBlack);

        if (mgrEnemy != null) {
            mzEventPLAYING += new EveHandMgrState(mgrEnemy.EventPLAYING);
            mzEventGIVEUP += new EveHandMgrState(mgrEnemy.EventGIVEUP);
            mzEventMAP += new EveHandMgrState(mgrEnemy.EventMAP);
            mzEventTIMEUP += new EveHandMgrState(mgrEnemy.EventTIMEUP);
            mzEventFAILURE += new EveHandMgrState(mgrEnemy.EventFAILURE);
            mzEventGOAL += new EveHandMgrState(mgrEnemy.EventGOAL);
            mzEventEMPTY += new EveHandMgrState(mgrEnemy.EventEMPTY);
        }

        Dummy();
    }

    void Update() {
        switch (state) {
            case GameState.DUMMY:
                break;

            case GameState.READY:
                if (Input.GetMouseButtonUp(0))
                    ReadyGo();
                break;

            case GameState.READYGO:
                break;

            case GameState.PLAYING:
                break;

            case GameState.GIVEUP:
                break;

            case GameState.MAP:
                break;

            case GameState.TIMEUP:
                break;

            case GameState.FAILURE:
                break;

            case GameState.GOAL:
                break;

            case GameState.CLEAR:
                break;

            case GameState.GAMEOVER:
                break;

            case GameState.EMPTY:
                break;
        }
    }

    void Dummy() {
        state = GameState.DUMMY;
        Invoke("Ready", 0.5f);
    }

    void Ready() {
        state = GameState.READY;
        this.mzEventREADY(this, EventArgs.Empty);
        this.playerMoveOff(this, EventArgs.Empty);
    }

    void ReadyGo() {
        state = GameState.READYGO;
        this.mzEventREADYGO(this, EventArgs.Empty);
        Invoke("Playing", 2.0f);
    }

    void Playing() {
        state = GameState.PLAYING;
        this.mzEventPLAYING(this, EventArgs.Empty);
        this.mzTimerStart(this, EventArgs.Empty);
        this.playerMoveOn(this, EventArgs.Empty);
        mzCeiling.gameObject.SetActive(true);
    }

    void GiveUp() {
        state = GameState.GIVEUP;
        this.mzEventGIVEUP(this, EventArgs.Empty);
        this.mzTimerStop(this, EventArgs.Empty);
        this.playerMoveOff(this, EventArgs.Empty);
    }

    void Map() {
        state = GameState.MAP;
        this.mzEventMAP(this, EventArgs.Empty);
        this.mzTimerStop(this, EventArgs.Empty);
        this.playerMoveOff(this, EventArgs.Empty);
        mzCeiling.gameObject.SetActive(false);
    }

    void TimeUp() {
        state = GameState.TIMEUP;
        this.mzEventTIMEUP(this, EventArgs.Empty);
        this.mzTimerStop(this, EventArgs.Empty);
        Invoke("Failure", 2.0f);
    }

    void Failure() {
        state = GameState.FAILURE;
        this.mzEventFAILURE(this, EventArgs.Empty);
        this.mzTimerStop(this, EventArgs.Empty);
    }

    void Goal() {
        state = GameState.GOAL;
        this.mzEventGOAL(this, EventArgs.Empty);
        this.mzTimerStop(this, EventArgs.Empty);
        this.playerMoveOff(this, EventArgs.Empty);
        Invoke("Clear", 4.0f);
    }

    void Clear() {
        state = GameState.CLEAR;
        this.mzEventCLEAR(this, EventArgs.Empty);
    }

    void GameOver() {
        state = GameState.GAMEOVER;
        mzBGM.Stop();
        this.mzEventGAMEOVER(this, EventArgs.Empty);
        StartCoroutine(ToGameOver());
    }

    void Empty() {
        state = GameState.EMPTY;
        this.mzEventEMPTY(this, EventArgs.Empty);
        this.mzTimerStop(this, EventArgs.Empty);
        this.playerMoveOff(this, EventArgs.Empty);
    }

    public void ToPLAYINGState(object o, EventArgs e) {
        Playing();
    }

    public void ToGIVEUPState(object o, EventArgs e) {
        GiveUp();
    }

    public void ToMAPState(object o, EventArgs e) {
        Map();
    }

    public void ToTIMEUPState(object o, EventArgs e) {
        TimeUp();
    }

    public void ToFAILUREState(object o, EventArgs e) {
        Failure();
    }

    public void ToGAMEOVERState(object o, EventArgs e) {
        GameOver();
    }

    public void ToGOALState(object o, EventArgs e) {
        Goal();
    }

    public void RestartIMethod(object o, EventArgs e) {
        mzBGM.Stop();
        StartCoroutine(Restart());
    }

    public void ToNextMzIMethod(object o, EventArgs e) {
        mzBGM.Stop();
        StartCoroutine(ToNextMz());
    }

    public void ToTitleIMethod(object o, EventArgs e) {
        mzBGM.Stop();
        StartCoroutine(ToTitle());
    }

    IEnumerator Restart() {
        this.toFadeBlack(this, EventArgs.Empty);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ToNextMz() {
        this.toFadeBlack(this, EventArgs.Empty);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ToTitle() {
        this.toFadeBlack(this, EventArgs.Empty);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator ToGameOver() {
        this.toFadeBlack(this, EventArgs.Empty);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("GameOver");
    }



    //----------デバッグ用----------
    public void DebugDUMMY() {
        Dummy();
    }

    public void DebugREADY() {
        Ready();
    }

    public void DebugREADYGO() {
        ReadyGo();
    }

    public void DebugPLAYING() {
        Playing();
    }

    public void DebugGIVEUP() {
        GiveUp();
    }

    public void DebugMAP() {
        Map();
    }

    public void DebugTIMEUP() {
        TimeUp();
    }

    public void DebugFAILURE() {
        Failure();
    }

    public void DebugGOAL() {
        Goal();
    }

    public void DebugCLEAR() {
        Clear();
    }

    public void DebugGAMEOVER() {
        GameOver();
    }

    public void DebugEMPTY() {
        Empty();
    }
    //--------------------
}