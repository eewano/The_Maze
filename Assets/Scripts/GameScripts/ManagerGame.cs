using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerGame : ManagerState {

    private GameState state;

    public static bool
    MapCrystal, Light, Croquette, GameIsOver, Fall, Dead, GoalAndClear, StartTween, Fade, MapModeON, MapModeOFF;

    private Renderer playerRenderer;
    private Text mzLabel;
    private Text mzTimerLabel;
    private Text lightLabel;
    private Text croquetteLabel;

    [SerializeField]
    private GameObject getLight;
    [SerializeField]
    private GameObject buttonGiveUp;
    [SerializeField]
    private GameObject buttonCancel;
    [SerializeField]
    private GameObject buttonGameOver;
    [SerializeField]
    private GameObject buttonMap;
    [SerializeField]
    private GameObject buttonToMz;
    [SerializeField]
    private GameObject buttonRestart;
    [SerializeField]
    private GameObject buttonNextMz;
    [SerializeField]
    private GameObject buttonToTitle;

    [SerializeField]
    private GameObject playerGoal;

    [SerializeField]
    private Image fadeBlack;

    private MzTimer mzTimer;
    private MzSoundEffect mzSoundEffect;
    private AudioListener mzAudioListener;
    private AudioListener mzReadyClear;
    private ManagerCamera managerCamera;
    private ManagerPlayer managerPlayer;
    private AudioSource mzBGM;
    private float alpha;

    void Start() {
        mzLabel = GameObject.Find("MzLabel").GetComponent<Text>();
        mzTimerLabel = GameObject.Find("MzTimerLabel").GetComponent<Text>();
        lightLabel = GameObject.Find("LightLabel").GetComponent<Text>();
        croquetteLabel = GameObject.Find("CroquetteLabel").GetComponent<Text>();

        mzTimer = GameObject.Find("MzTimerLabel").
        GetComponent<MzTimer>();
        mzSoundEffect = GameObject.Find("MzSoundEffect").
        GetComponent<MzSoundEffect>();
        mzAudioListener = GameObject.Find("Player").
        GetComponent<AudioListener>();
        mzReadyClear = GameObject.Find("MzSoundEffect").
        GetComponent<AudioListener>();
        managerCamera = GameObject.Find("ManagerCamera").
        GetComponent<ManagerCamera>();
        managerPlayer = GameObject.Find("ManagerPlayer").
        GetComponent<ManagerPlayer>();
        mzBGM = GameObject.Find("MzBGM").
        GetComponent<AudioSource>();
        playerRenderer = GameObject.Find("Player").
        GetComponent<MeshRenderer>();

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
                buttonMap.gameObject.SetActive(MapCrystal);
                getLight.gameObject.SetActive(Light);
                lightLabel.enabled = Light;
                croquetteLabel.enabled = Croquette;

                if (mzTimer.GetTimeRemaining() == 0)
                {
                    mzTimer.StopTimer();
                    TimeUp();
                    GameIsOver = true;
                }
                break;

            case GameState.GIVEUP:
                if (Light == true) {
                    lightLabel.enabled = true;
                }
                if (Croquette == true) {
                    croquetteLabel.enabled = true;
                }
                break;

            case GameState.MAP:
                if (Light == true) {
                    lightLabel.enabled = true;
                }
                if (Croquette == true) {
                    croquetteLabel.enabled = true;
                }
                break;

            case GameState.TIMEUP:
                Invoke("Failure", 2.0f);
                break;

            case GameState.FAILURE:
                Dead = true;
                break;

            case GameState.GOAL:
                GoalAndClear = true;
                StartTween = true;
                mzTimer.StopTimer();

                Invoke("Clear", 4.0f);
                break;

            case GameState.CLEAR:
                break;

            case GameState.GAMEOVER:
                break;

            case GameState.EMPTY:
                break;
        }
    }


    void AllFalse() {
        playerRenderer.enabled = false;

        mzTimerLabel.enabled = false;
        lightLabel.enabled = false;
        croquetteLabel.enabled = false;

        getLight.gameObject.SetActive(false);
        buttonGiveUp.gameObject.SetActive(false);
        buttonCancel.gameObject.SetActive(false);
        buttonGameOver.gameObject.SetActive(false);
        buttonMap.gameObject.SetActive(false);
        buttonToMz.gameObject.SetActive(false);
        buttonRestart.gameObject.SetActive(false);
        buttonNextMz.gameObject.SetActive(false);
        buttonToTitle.gameObject.SetActive(false);

        playerGoal.gameObject.SetActive(false);

        mzAudioListener.enabled = false;
        mzReadyClear.enabled = false;

        fadeBlack.enabled = false;
    }

    void Ready() {
        state = GameState.READY;
        managerCamera.ShowPlayerCamera();
        AllFalse();

        mzReadyClear.enabled = true;
        mzLabel.enabled = true;
        if (SceneManager.GetActiveScene().name == "Maze00") {
            mzLabel.text = "0面はチュートリアルです。\nここでは各基本アイテムの効果を説明していきます。\n" +
            "制限時間内にすべてのアイテムを取得した後、\nゴールを目指して下さい。\n\n画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze01") {
            mzLabel.text = "1面は、単純な迷路です。\n制限時間内に出口を目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze02") {
            mzLabel.text = "2面はロボットが襲ってきます。\n捕まると30秒間気絶させられ、スタート地点に\n" +
            "戻されるので、上手く逃げ回りつつゴールを\n目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze03") {
            mzLabel.text = "3面はクリアするのに鍵のアイテムが\n必要になります。\n" +
            "様々な仕掛けをくぐり抜け、\n鍵を探し出してゴールを目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
        mzTimer.ResetTimer();

        managerPlayer.ControllerAllFalse();
    }

    void ReadyGo() {
        state = GameState.READYGO;
        AllFalse();
        mzSoundEffect.ReadyGoSound();

        mzReadyClear.enabled = true;
        mzLabel.enabled = true;
        if (SceneManager.GetActiveScene().name == "Maze00") {
            mzLabel.text = "0 面 スタート !";
            mzLabel.fontSize = 100;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (SceneManager.GetActiveScene().name == "Maze01") {
            mzLabel.text = "1 面 スタート !";
            mzLabel.fontSize = 100;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (SceneManager.GetActiveScene().name == "Maze02") {
            mzLabel.text = "2 面 スタート !";
            mzLabel.fontSize = 100;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (SceneManager.GetActiveScene().name == "Maze03") {
            mzLabel.text = "3 面 スタート !";
            mzLabel.fontSize = 100;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }

        managerPlayer.ControllerAllFalse();
    }

    void Playing() {
        state = GameState.PLAYING;
        managerCamera.ShowPlayerCamera();
        AllFalse();

        mzLabel.text = "";
        mzTimerLabel.enabled = true;
        buttonGiveUp.gameObject.SetActive(true);
        mzAudioListener.enabled = true;

        mzTimer.StartTimer();
        Time.timeScale = 1.0f;

        managerPlayer.ControllerAllTrue();
    }

    void GiveUp() {
        state = GameState.GIVEUP;
        Time.timeScale = 0.0f;
        AllFalse();

        mzLabel.text = "本当にギブアップ\nしますか？";
        mzLabel.fontSize = 48;
        mzLabel.color = new Color(255f / 255f, 128f / 255f, 0f / 255f);
        mzTimerLabel.enabled = true;
        buttonCancel.gameObject.SetActive(true);
        buttonGameOver.gameObject.SetActive(true);
        mzReadyClear.enabled = true;

        managerPlayer.ControllerAllFalse();
    }

    void Map() {
        state = GameState.MAP;
        managerCamera.ShowMapCamera();
        Time.timeScale = 0.0f;
        mzLabel.text = "";
        AllFalse();

        playerRenderer.enabled = true;
        mzTimerLabel.enabled = true;
        buttonToMz.gameObject.SetActive(true);
        mzReadyClear.enabled = true;

        managerPlayer.ControllerAllFalse();
    }

    void TimeUp() {
        state = GameState.TIMEUP;
        AllFalse();
        mzSoundEffect.TimeUpSound();

        mzLabel.text = "時間切れ！";
        mzLabel.fontSize = 100;
        mzLabel.color = new Color(255f / 255f, 64f / 255f, 0f / 255f);
        mzReadyClear.enabled = true;

        managerPlayer.ControllerAllFalse();
    }

    void Failure() {
        state = GameState.FAILURE;
        managerCamera.ShowPlayerCamera();
        AllFalse();

        mzLabel.text = "脱出失敗！";
        mzLabel.fontSize = 100;
        mzLabel.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        buttonGameOver.gameObject.SetActive(true);
        buttonRestart.gameObject.SetActive(true);
        mzReadyClear.enabled = true;

        managerPlayer.ControllerAllFalse();
    }

    void Goal() {
        state = GameState.GOAL;
        managerCamera.ShowGoalCamera();
        AllFalse();
        mzSoundEffect.GoalSound();

        mzLabel.text = "GOAL！";
        mzLabel.fontSize = 100;
        mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        playerGoal.gameObject.SetActive(true);
        mzReadyClear.enabled = true;

        managerPlayer.ControllerAllFalse();
    }

    void Clear() {
        state = GameState.CLEAR;

        if (SceneManager.GetActiveScene().name == "Maze00") {
            mzLabel.text = "0 面 クリア !\nさあ次からが本格的な\n" +
            "迷路探索の始まりです !";
            mzLabel.fontSize = 60;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (SceneManager.GetActiveScene().name == "Maze01") {
            mzLabel.text = "1 面\nクリア !";
            mzLabel.fontSize = 100;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (SceneManager.GetActiveScene().name == "Maze02") {
            mzLabel.text = "2 面\nクリア !";
            mzLabel.fontSize = 100;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (SceneManager.GetActiveScene().name == "Maze03") {
            mzLabel.text = "3 面\nクリア !";
            mzLabel.fontSize = 100;
            mzLabel.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }

        buttonNextMz.gameObject.SetActive(true);
        buttonToTitle.gameObject.SetActive(true);

        managerPlayer.ControllerAllFalse();
    }


    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Restart() {
        yield return new WaitForSeconds(1.0f);
        Fade = true;
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ToTitle() {
        yield return new WaitForSeconds(1.0f);
        Fade = true;
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator ToNextMz() {
        yield return new WaitForSeconds(1.0f);
        Fade = true;
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void OnButtonGiveUpClicked() {
        mzSoundEffect.EnterSound();
        GiveUp();
    }

    public void OnButtonCancelClicked() {
        mzSoundEffect.ExitSound();
        Playing();
    }

    public void OnButtonGameOverClicked() {
        GameOver();
    }

    public void OnButtonMapClicked() {
        mzSoundEffect.EnterSound();
        MapModeON = true;
        MapModeOFF = false;
        //Pauser.Pause ();
        Map();
    }

    public void OnButtonToMzClicked() {
        mzSoundEffect.ExitSound();
        MapModeON = false;
        MapModeOFF = true;
        //Pauser.Resume ();
        Playing();
    }

    public void OnButtonRestartClicked() {
        mzBGM.Stop();
        mzSoundEffect.EnterSound();
        fadeBlack.enabled = true;
        StartCoroutine(Restart());
    }

    public void OnButtonNextMzClicked() {
        mzBGM.Stop();
        mzSoundEffect.EnterSound();
        fadeBlack.enabled = true;
        StartCoroutine(ToNextMz());
    }

    public void OnButtonToTitleClicked() {
        mzBGM.Stop();
        mzSoundEffect.EnterSound();
        fadeBlack.enabled = true;
        StartCoroutine(ToTitle());
    }
}