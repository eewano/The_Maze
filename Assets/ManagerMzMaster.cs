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
    private Mgr_MzSE01 mgrMzSE01;
    private Mgr_MzSE02 mgrMzSE02;
    //テキスト表示用
    private Mgr_MzTextClear mgrMzTextClear;
    private Mgr_MzTextFailure mgrMzTextFailure;
    private Mgr_MzTextGiveUp mgrMzTextGiveUp;
    private Mgr_MzTextGoal mgrMzTextGoal;
    private Mgr_MzTextIntro mgrMzTextIntro;
    private Mgr_MzTextReady mgrMzTextReady;
    private Mgr_MzTextTimeUp mgrMzTextTimeUp;
    //ボタン表示用
    private Mgr_MzBtnGiveUp mgrMzBtnGiveUp;
    private Mgr_MzBtnCancel mgrMzBtnCancel;
    private Mgr_MzBtnGameOver mgrMzBtnGameOver;
    private Mgr_MzBtnMap mgrMzBtnMap;
    private Mgr_MzBtnMapToMz mgrMzBtnMapToMz;
    private Mgr_MzBtnRestart mgrMzBtnRestart;
    private Mgr_MzBtnNextMz mgrMzBtnNextMz;
    private Mgr_MzBtnToTitle mgrMzBtnToTitle;
    //取得アイテム表示用
    private Mgr_MzLabelLightGet mgrMzLabelLightGet;
    private Mgr_MzLabelCroquetteGet mgrMzLabelCroquetteGet;
    private Mgr_MzLabelMapGet mgrMzLabelMapGet;
    //カメラ用
    private Mgr_MzCamPlayer mgrMzCamPlayer;
    private Mgr_MzCamMap mgrMzCamMap;
    private Mgr_MzCamGoal mgrMzCamGoal;

    private event EveHandMgrState mzEventMAZESTART;

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

    enum GameState {
        MAZESTART,
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

    //    private bool
    //    MapCrystal, Light, Croquette, GameIsOver, Fall, Dead, GoalAndClear, StartTween, Fade, MapModeON, MapModeOFF;

    void Awake() {
        mzTimerText = GameObject.Find("MzTimerText").GetComponent<Text>();
        mzTimer = GameObject.Find("MzTimerText").GetComponent<MzTimer>();
        //SEサウンド出力用
        mgrMzSE01 = GameObject.Find("Mgr_MzSE01").GetComponent<Mgr_MzSE01>();
        mgrMzSE02 = GameObject.Find("Mgr_MzSE02").GetComponent<Mgr_MzSE02>();
        //テキスト表示用
        mgrMzTextClear = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextClear>();
        mgrMzTextFailure = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextFailure>();
        mgrMzTextGiveUp = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextGiveUp>();
        mgrMzTextGoal = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextGoal>();
        mgrMzTextIntro = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextIntro>();
        mgrMzTextReady = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextReady>();
        mgrMzTextTimeUp = GameObject.Find("Mgr_MzText").GetComponent<Mgr_MzTextTimeUp>();
        //ボタン表示用
        mgrMzBtnGiveUp = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnGiveUp>();
        mgrMzBtnCancel = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnCancel>();
        mgrMzBtnGameOver = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnGameOver>();
        mgrMzBtnMap = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnMap>();
        mgrMzBtnMapToMz = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnMapToMz>();
        mgrMzBtnRestart = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnRestart>();
        mgrMzBtnNextMz = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnNextMz>();
        mgrMzBtnToTitle = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnToTitle>();
        //アイテム取得ラベル用
        mgrMzLabelLightGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelLightGet>();
        mgrMzLabelCroquetteGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelCroquetteGet>();
        mgrMzLabelMapGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelMapGet>();
        //カメラ用
        mgrMzCamPlayer = GameObject.Find("Mgr_MzCamera").GetComponent<Mgr_MzCamPlayer>();
        mgrMzCamMap = GameObject.Find("Mgr_MzCamera").GetComponent<Mgr_MzCamMap>();
        mgrMzCamGoal = GameObject.Find("Mgr_MzCamera").GetComponent<Mgr_MzCamGoal>();
    }

    void Start() {
        //        MapCrystal = false;
        //        Light = false;
        //        Croquette = false;
        //        GameIsOver = false;
        //        Fall = false;
        //        Dead = false;
        //        GoalAndClear = false;
        //        StartTween = false;
        //        Fade = false;
        //        MapModeON = false;
        //        MapModeOFF = false;

        //MAZESTARTステート
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventMAZESTART += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventMAZESTART += new EveHandMgrState(mgrMzCamPlayer.AppearCamEvent);
        //READYステート
        mzEventREADY += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventREADY += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventREADY += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventREADY += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventREADY += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventREADY += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventREADY += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventREADY += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventREADY += new EveHandMgrState(mgrMzTextIntro.AppearTextEvent);
        //READYGOステート
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventREADYGO += new EveHandMgrState(mgrMzCamPlayer.AppearCamEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzTextIntro.AppearTextEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzTextIntro.HideTextEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzTextReady.AppearTextEvent);
        mzEventREADYGO += new EveHandMgrState(mgrMzSE01.SEReadyGoEvent);

        //PLAYINGステート
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventPLAYING += new EveHandMgrState(mgrMzCamMap.HideCamEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzCamPlayer.AppearCamEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzTextReady.HideTextEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzTextGiveUp.HideTextEvent);
        mzEventPLAYING += new EveHandMgrState(mgrMzBtnGiveUp.AppearBtnEvent);
        //GIVEUPステート
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventGIVEUP += new EveHandMgrState(mgrMzTextGiveUp.AppearTextEvent);
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnCancel.AppearBtnEvent);
        mzEventGIVEUP += new EveHandMgrState(mgrMzBtnGameOver.AppearBtnEvent);
        //MAPステート
        mzEventMAP += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventMAP += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventMAP += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventMAP += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventMAP += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventMAP += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventMAP += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventMAP += new EveHandMgrState(mgrMzCamPlayer.HideCamEvent);
        mzEventMAP += new EveHandMgrState(mgrMzCamMap.AppearCamEvent);
        mzEventMAP += new EveHandMgrState(mgrMzBtnMapToMz.AppearBtnEvent);
        //TIMEUPステート
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventTIMEUP += new EveHandMgrState(mgrMzTextTimeUp.AppearTextEvent);
        mzEventTIMEUP += new EveHandMgrState(mgrMzSE01.SETimeUpEvent);
        //FAILUREステート
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventFAILURE += new EveHandMgrState(mgrMzTextTimeUp.HideTextEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnRestart.AppearBtnEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzBtnGameOver.AppearBtnEvent);
        mzEventFAILURE += new EveHandMgrState(mgrMzTextFailure.AppearTextEvent);
        //GOALステート
        mzEventGOAL += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventGOAL += new EveHandMgrState(mgrMzCamPlayer.HideCamEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzCamGoal.AppearCamEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzTextGoal.AppearTextEvent);
        mzEventGOAL += new EveHandMgrState(mgrMzSE02.SEGoal01Event);
        //CLEARステート
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);

        mzEventCLEAR += new EveHandMgrState(mgrMzTextGoal.HideTextEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnNextMz.AppearBtnEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzBtnToTitle.AppearBtnEvent);
        mzEventCLEAR += new EveHandMgrState(mgrMzTextClear.AppearTextEvent);
        //GAMEOVERステート
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventGAMEOVER += new EveHandMgrState(mgrMzTextGiveUp.HideTextEvent);
        mzEventGAMEOVER += new EveHandMgrState(mgrMzTextFailure.HideTextEvent);
        //EMPTYステート
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnCancel.HideBtnEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnGameOver.HideBtnEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnMap.HideBtnEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnMapToMz.HideBtnEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnRestart.HideBtnEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnNextMz.HideBtnEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzBtnToTitle.HideBtnEvent);

        mzEventEMPTY += new EveHandMgrState(mgrMzTextClear.HideTextEvent);
        mzEventEMPTY += new EveHandMgrState(mgrMzTextFailure.HideTextEvent);

        MazeStart();
    }

    void Update() {
        switch (state) {
            case GameState.MAZESTART:
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

    void MazeStart() {
        state = GameState.MAZESTART;
        this.mzEventMAZESTART(this, EventArgs.Empty);
        Invoke("Ready", 1.5f);
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
    }

    public void ToGiveUpMethod(object o, EventArgs e) {
        GiveUp();
    }

    public void ToPlayingMethod(object o, EventArgs e) {
        Playing();
    }

    public void ToMapMethod(object o, EventArgs e) {
        Map();
    }

    public void ToGameOverMethod(object o, EventArgs e) {
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
        this.mzEventEMPTY(this, EventArgs.Empty);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ToNextMz() {
        this.mzEventEMPTY(this, EventArgs.Empty);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ToTitle() {
        this.mzEventEMPTY(this, EventArgs.Empty);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator ToGameOver() {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("GameOver");
    }


    //----------デバッグ用----------
    public void DebugMAZESTART() {
        MazeStart();
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