using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public delegate void EventHandler01(object sender, EventArgs e);

public class ManagerGame : MonoBehaviour {

    [SerializeField]
    private Text mzTimerText;
    private MzTimer mzTimer;
    private MzSoundEffect mzSoundEffect;

    private event EventHandler01 objectAppear;
    private event EventHandler01 playSound;

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
        GAMEOVER
    }

    private GameState state;

    private bool
    MapCrystal, Light, Croquette, GameIsOver, Fall, Dead, GoalAndClear, StartTween, Fade, MapModeON, MapModeOFF;

    void Awake() {
        mzTimerText = GameObject.Find("MzTimerText").GetComponent<Text>();
        mzTimer = GameObject.Find("MzTimerText").GetComponent<MzTimer>();
        mzSoundEffect = GameObject.Find("MzSoundEffect").GetComponent<MzSoundEffect>();
    }

    void Start() {
        MapCrystal = false;
        Light = false;
        Croquette = false;
        GameIsOver = false;
        Fall = false;
        Dead = false;
        GoalAndClear = false;
        StartTween = false;
        Fade = false;
        MapModeON = false;
        MapModeOFF = false;
        Ready();

//        objectAppear += new EventHandler01();

//        objectAppear += new EventHandler01();
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
                    GameIsOver = true;
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
    }

    void ReadyGo() {
        state = GameState.READYGO;
        this.playSound(this, EventArgs.Empty);
    }

    void Playing() {
        state = GameState.PLAYING;
    }

    void GiveUp() {
        state = GameState.GIVEUP;
    }

    void Map() {
        state = GameState.MAP;
    }

    void TimeUp() {
        state = GameState.TIMEUP;
    }

    void Failure() {
        state = GameState.FAILURE;
    }

    void Goal() {
        state = GameState.GOAL;
        this.playSound(this, EventArgs.Empty);
    }

    void Clear() {
        state = GameState.CLEAR;;
    }

    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }
}