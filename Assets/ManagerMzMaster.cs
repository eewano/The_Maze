using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public delegate void EventHandler01(object sender, EventArgs e);

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
    private Mgr_MzBtnToMz mgrMzBtnToMz;
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

    private event EventHandler01 mzEventREADY;

    private event EventHandler01 mzEventREADYGO;

    private event EventHandler01 mzEventPLAYING;

    private event EventHandler01 mzEventGIVEUP;

    private event EventHandler01 mzEventMAP;

    private event EventHandler01 mzEventTIMEUP;

    private event EventHandler01 mzEventFAILURE;

    private event EventHandler01 mzEventGOAL;

    private event EventHandler01 mzEventCLEAR;

    private event EventHandler01 mzEventGAMEOVER;

    private event EventHandler01 mzEventEMPTY;

    enum GameState {
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
        mgrMzBtnToMz = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnToMz>();
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

        //READYステート
        mzEventREADY += new EventHandler01(mgrMzCamPlayer.AppearCamEvent);
        mzEventREADY += new EventHandler01(mgrMzTextIntro.AppearTextEvent);
        //READYGOステート
        mzEventREADYGO += new EventHandler01(mgrMzTextIntro.HideTextEvent);
        mzEventREADYGO += new EventHandler01(mgrMzTextReady.AppearTextEvent);
        mzEventREADYGO += new EventHandler01(mgrMzSE01.SEReadyGoEvent);

        //PLAYINGステート
        mzEventPLAYING += new EventHandler01(mgrMzBtnCancel.HideBtnEvent);
        mzEventPLAYING += new EventHandler01(mgrMzBtnGameOver.HideBtnEvent);
        mzEventPLAYING += new EventHandler01(mgrMzTextReady.HideTextEvent);
        mzEventPLAYING += new EventHandler01(mgrMzTextGiveUp.HideTextEvent);
        mzEventPLAYING += new EventHandler01(mgrMzBtnGiveUp.AppearBtnEvent);
        //GIVEUPステート
        mzEventGIVEUP += new EventHandler01(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventGIVEUP += new EventHandler01(mgrMzTextGiveUp.AppearTextEvent);
        mzEventGIVEUP += new EventHandler01(mgrMzBtnCancel.AppearBtnEvent);
        mzEventGIVEUP += new EventHandler01(mgrMzBtnGameOver.AppearBtnEvent);
        //MAPステート
        //TIMEUPステート
        mzEventTIMEUP += new EventHandler01(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventTIMEUP += new EventHandler01(mgrMzTextTimeUp.AppearTextEvent);
        mzEventTIMEUP += new EventHandler01(mgrMzSE01.SETimeUpEvent);
        //FAILUREステート
        mzEventFAILURE += new EventHandler01(mgrMzTextTimeUp.HideTextEvent);
        mzEventFAILURE += new EventHandler01(mgrMzBtnRestart.AppearBtnEvent);
        mzEventFAILURE += new EventHandler01(mgrMzBtnGameOver.AppearBtnEvent);
        mzEventFAILURE += new EventHandler01(mgrMzTextFailure.AppearTextEvent);
        //GOALステート
        mzEventGOAL += new EventHandler01(mgrMzCamPlayer.HideCamEvent);
        mzEventTIMEUP += new EventHandler01(mgrMzBtnGiveUp.HideBtnEvent);
        mzEventGOAL += new EventHandler01(mgrMzCamGoal.AppearCamEvent);
        mzEventGOAL += new EventHandler01(mgrMzTextGoal.AppearTextEvent);
        mzEventGOAL += new EventHandler01(mgrMzSE02.SEGoal01Event);
        //CLEARステート
        mzEventCLEAR += new EventHandler01(mgrMzTextGoal.HideTextEvent);
        mzEventCLEAR += new EventHandler01(mgrMzBtnNextMz.AppearBtnEvent);
        mzEventCLEAR += new EventHandler01(mgrMzBtnToTitle.AppearBtnEvent);
        mzEventCLEAR += new EventHandler01(mgrMzTextClear.AppearTextEvent);
        //GAMEOVERステート
        mzEventGAMEOVER += new EventHandler01(mgrMzBtnCancel.HideBtnEvent);
        mzEventGAMEOVER += new EventHandler01(mgrMzBtnGameOver.HideBtnEvent);
        mzEventGAMEOVER += new EventHandler01(mgrMzTextGiveUp.HideTextEvent);
        mzEventGAMEOVER += new EventHandler01(mgrMzTextFailure.HideTextEvent);
        //EMPTYステート

        Ready();
    }

    void Update() {
        switch (state) {
            case GameState.READY:
                if (Input.GetMouseButtonUp(0))
                    ReadyGo();
                break;

            case GameState.READYGO:
                Invoke("Playing", 2.0f);
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
                Invoke("Failure", 2.0f);
                break;

            case GameState.FAILURE:
                break;

            case GameState.GOAL:
                Invoke("Clear", 4.0f);
                break;

            case GameState.CLEAR:
                break;

            case GameState.GAMEOVER:
                break;
        }
    }

    void Ready() {
        state = GameState.READY;
        this.mzEventREADY(this, EventArgs.Empty);
    }

    void ReadyGo() {
        state = GameState.READYGO;
        this.mzEventREADYGO(this, EventArgs.Empty);
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
    }

    void Failure() {
        state = GameState.FAILURE;
        this.mzEventFAILURE(this, EventArgs.Empty);
    }

    void Goal() {
        state = GameState.GOAL;
        this.mzEventGOAL(this, EventArgs.Empty);
    }

    void Clear() {
        state = GameState.CLEAR;
        this.mzEventCLEAR(this, EventArgs.Empty);
    }

    void GameOver() {
        state = GameState.GAMEOVER;
        SceneManager.LoadScene("GameOver");
    }

    void Empty() {
        state = GameState.EMPTY;
    }
}