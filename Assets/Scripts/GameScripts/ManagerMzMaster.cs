using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerMzMaster : MonoBehaviour {

    //プレイヤー制御用
    private ManagerPlayerMaster managerPlayerMaster;
    //SEサウンド出力用
    private Manager_GameSE01 managerMzSE01;
    private Manager_GameSE02 managerMzSE02;
    //テキスト表示用
    private Manager_MzText managerMzText;
    //ボタン表示用
    private Manager_MzButton managerMzButton;
    //コントロールボタン表示用
    private Manager_MzBtnCtrl managerMzBtnCtrl;
    //取得アイテム表示用
    private Manager_MzLabel managerMzLabel;
    //カメラ用
    private Manager_MzCam managerMzCam;
    //タイマー管理用
    private Mgr_MzTextTimer mgrMzTextTimer;
    //迷路BGM
    private AudioSource mzBGM;

    private event EveHandMgrState mzEventDUMMY;

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
        //プレイヤー制御用
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        //SEサウンド出力用
        managerMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Manager_GameSE01>();
        managerMzSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Manager_GameSE02>();
        //テキスト表示用
        managerMzText = GameObject.Find("Mgr_MzText").GetComponent<Manager_MzText>();
        //ボタン表示用
        managerMzButton = GameObject.Find("Mgr_MzButton").GetComponent<Manager_MzButton>();
        //コントロールボタン表示用
        managerMzBtnCtrl = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Manager_MzBtnCtrl>();
        //アイテム取得ラベル用
        managerMzLabel = GameObject.Find("Mgr_MzLabel").GetComponent<Manager_MzLabel>();
        //カメラ用
        managerMzCam = GameObject.Find("Mgr_MzCamera").GetComponent<Manager_MzCam>();
        //タイマー管理用
        mgrMzTextTimer = GameObject.Find("Mgr_MzTimer").GetComponent<Mgr_MzTextTimer>();
        mzBGM = GameObject.Find("MzBGM").GetComponent<AudioSource>();
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
        //GIVEUPステート
        mzEventGIVEUP += new EveHandMgrState(managerMzButton.EventGIVEUP);
        mzEventGIVEUP += new EveHandMgrState(managerMzBtnCtrl.EventGIVEUP);
        mzEventGIVEUP += new EveHandMgrState(managerMzText.EventGIVEUP);
        //MAPステート
        mzEventMAP += new EveHandMgrState(managerMzCam.EventMAP);
        mzEventMAP += new EveHandMgrState(managerMzButton.EventMAP);
        mzEventMAP += new EveHandMgrState(managerMzBtnCtrl.EventMAP);
        //TIMEUPステート
        mzEventTIMEUP += new EveHandMgrState(managerMzButton.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzBtnCtrl.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzText.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzLabel.EventTIMEUP);
        mzEventTIMEUP += new EveHandMgrState(managerMzSE01.EventTIMEUP);
        //FAILUREステート
        mzEventFAILURE += new EveHandMgrState(managerMzButton.EventFAILURE);
        mzEventFAILURE += new EveHandMgrState(managerMzText.EventFAILURE);
        //GOALステート
        mzEventGOAL += new EveHandMgrState(managerMzCam.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzButton.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzBtnCtrl.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzText.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzLabel.EventGOAL);
        mzEventGOAL += new EveHandMgrState(managerMzSE02.EventGOAL);
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

    public void ToGAMEOVERState(object o, EventArgs e) {
        GameOver();
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
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ToNextMz() {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ToTitle() {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator ToGameOver() {
        yield return new WaitForSeconds(3.0f);
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