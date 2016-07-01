using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerMzMaster : MonoBehaviour {

    [SerializeField]
    private Text mzTimerText;
    private MzTimer mzTimer;
    //SEサウンド出力用
    private Manager_GameSE01 managerMzSE01;
    private Manager_GameSE02 managerMzSE02;
    //テキスト表示用
    private Manager_MzText managerMzText;
    //ボタン表示用
    private Manager_MzButton managerMzButton;
    //コントロールボタン表示用
    private Manager_MzBtnCtrl managerMzBtnCtrl;
    //マップ画面でのアイテム表示用
    private Manager_MzItem01 managerMzItem01;
    //取得アイテム表示用
    private Manager_MzLabel managerMzLabel;
    //カメラ用
    private Manager_MzCam managerMzCam;

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
        mzTimerText = GameObject.Find("MzTimerText").GetComponent<Text>();
        mzTimer = GameObject.Find("MzTimerText").GetComponent<MzTimer>();
        //SEサウンド出力用
        managerMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Manager_GameSE01>();
        managerMzSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Manager_GameSE02>();
        //テキスト表示用
        managerMzText = GameObject.Find("Mgr_MzText").GetComponent<Manager_MzText>();
        //ボタン表示用
        managerMzButton = GameObject.Find("Mgr_MzButton").GetComponent<Manager_MzButton>();
        //コントロールボタン表示用
        managerMzBtnCtrl = GameObject.Find("Mgr_MzBtnCtrl").GetComponent<Manager_MzBtnCtrl>();
        //マップ画面でのアイテム表示用
        managerMzItem01 = GameObject.Find("Mgr_MzItem01").GetComponent<Manager_MzItem01>();
        //アイテム取得ラベル用
        managerMzLabel = GameObject.Find("Mgr_MzLabel").GetComponent<Manager_MzLabel>();
        //カメラ用
        managerMzCam = GameObject.Find("Mgr_MzCamera").GetComponent<Manager_MzCam>();
    }

    void Start() {
        //DUMMYステート
        mzEventDUMMY += new EveHandMgrState(managerMzCam.EventDUMMY);
        //READYステート
        mzEventREADY += new EveHandMgrState(managerMzCam.EventREADY);
        mzEventREADY += new EveHandMgrState(managerMzText.EventREADY);
        //READYGOステート
        mzEventREADYGO += new EveHandMgrState(managerMzText.EventREADYGO);
        mzEventREADYGO += new EveHandMgrState(managerMzSE01.EventREADYGO);
        //PLAYINGステート
        mzEventPLAYING += new EveHandMgrState(managerMzCam.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerMzButton.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerMzBtnCtrl.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerMzText.EventPLAYING);
        mzEventPLAYING += new EveHandMgrState(managerMzItem01.EventPLAYING);
        //GIVEUPステート
        mzEventGIVEUP += new EveHandMgrState(managerMzButton.EventGIVEUP);
        mzEventGIVEUP += new EveHandMgrState(managerMzBtnCtrl.EventGIVEUP);
        mzEventGIVEUP += new EveHandMgrState(managerMzText.EventGIVEUP);
        //MAPステート
        mzEventMAP += new EveHandMgrState(managerMzCam.EventMAP);
        mzEventMAP += new EveHandMgrState(managerMzButton.EventMAP);
        mzEventMAP += new EveHandMgrState(managerMzBtnCtrl.EventMAP);
        mzEventMAP += new EveHandMgrState(managerMzItem01.EventMAP);
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
        //EMPTYステート
        mzEventEMPTY += new EveHandMgrState(managerMzCam.EventEMPTY);
        mzEventEMPTY += new EveHandMgrState(managerMzButton.EventEMPTY);
        mzEventEMPTY += new EveHandMgrState(managerMzBtnCtrl.EventEMPTY);
        mzEventEMPTY += new EveHandMgrState(managerMzText.EventEMPTY);
        mzEventEMPTY += new EveHandMgrState(managerMzItem01.EventEMPTY);

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
                if (mzTimer.GetTimeRemaining() == 0)
                {
                    mzTimer.StopTimer();
                    TimeUp();
                }
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
        this.mzEventDUMMY(this, EventArgs.Empty);
        Invoke("Ready", 0.5f);
    }

    void Ready() {
        state = GameState.READY;
        this.mzEventREADY(this, EventArgs.Empty);
    }

    void ReadyGo() {
        state = GameState.READYGO;
        this.mzEventREADYGO(this, EventArgs.Empty);
        Invoke("Playing", 2.0f);
    }

    void Playing() {
        state = GameState.PLAYING;
        this.mzEventPLAYING(this, EventArgs.Empty);
    }

    void GiveUp() {
        state = GameState.GIVEUP;
        this.mzEventGIVEUP(this, EventArgs.Empty);
    }

    void Map() {
        state = GameState.MAP;
        this.mzEventMAP(this, EventArgs.Empty);
    }

    void TimeUp() {
        state = GameState.TIMEUP;
        this.mzEventTIMEUP(this, EventArgs.Empty);
        Invoke("Failure", 2.0f);
    }

    void Failure() {
        state = GameState.FAILURE;
        this.mzEventFAILURE(this, EventArgs.Empty);
    }

    void Goal() {
        state = GameState.GOAL;
        this.mzEventGOAL(this, EventArgs.Empty);
        Invoke("Clear", 4.0f);
    }

    void Clear() {
        state = GameState.CLEAR;
        this.mzEventCLEAR(this, EventArgs.Empty);
    }

    void GameOver() {
        state = GameState.GAMEOVER;
        this.mzEventGAMEOVER(this, EventArgs.Empty);
        StartCoroutine(ToGameOver());
    }

    void Empty() {
        state = GameState.EMPTY;
        this.mzEventEMPTY(this, EventArgs.Empty);
    }

    public void ToGIVEUPState(object o, EventArgs e) {
        GiveUp();
    }

    public void ToPLAYINGState(object o, EventArgs e) {
        Playing();
    }

    public void ToMAPState(object o, EventArgs e) {
        Map();
    }

    public void ToGAMEOVERState(object o, EventArgs e) {
        GameOver();
    }

    public void RestartIMethod(object o, EventArgs e) {
        StartCoroutine(Restart());
    }

    public void ToNextMzIMethod(object o, EventArgs e) {
        StartCoroutine(ToNextMz());
    }

    public void ToTitleIMethod(object o, EventArgs e) {
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