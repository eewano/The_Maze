using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	enum GameState
	{
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

	public static bool
		MapCrystal,
		Light,
		Croquette,
		GameIsOver,
		Fall,
		Dead,
		GoalAndClear,
		StartTween,
		Fade,
		MapModeON,
		MapModeOFF;

	[SerializeField] private GameObject player;
	private Renderer playerRenderer;

	[SerializeField] private Text mzDescriptionLabel;
	[SerializeField] private Text mzStartLabel;
	[SerializeField] private Text mzClearLabel;

	[SerializeField] private Text mzTimerLabel;
	[SerializeField] private Text lightLabel;
	[SerializeField] private Text croquetteLabel;
	[SerializeField] private Text giveUpLabel;
	[SerializeField] private Text timeUpLabel;
	[SerializeField] private Text failerLabel;
	[SerializeField] private Text goalLabel;

	[SerializeField] private GameObject buttonForward;
	[SerializeField] private GameObject buttonBack;
	[SerializeField] private GameObject buttonLeft;
	[SerializeField] private GameObject buttonRight;
	[SerializeField] private GameObject buttonFL;
	[SerializeField] private GameObject buttonFR;
	[SerializeField] private GameObject buttonBL;
	[SerializeField] private GameObject buttonBR;

	[SerializeField] private GameObject getLight;
	[SerializeField] private GameObject buttonGiveUp;
	[SerializeField] private GameObject buttonCancel;
	[SerializeField] private GameObject buttonGameOver;
	[SerializeField] private GameObject buttonMap;
	[SerializeField] private GameObject buttonToMz;
	[SerializeField] private GameObject buttonRestart;
	[SerializeField] private GameObject buttonNextMz;
	[SerializeField] private GameObject buttonToTitle;

	[SerializeField] private GameObject playerGoal;

	[SerializeField] private Image fadeBlack;

	private MzTimer mzTimer;
	private MzSoundEffect mzSoundEffect;
	private AudioListener mzAudioListener;
	private AudioListener mzReadyClear;
	private CameraManager cameraController;
	private AudioSource mzBGM;
	private float alpha;

	void Awake()
	{
		mzTimer = GameObject.Find ("MzTimerLabel").
			GetComponent<MzTimer>();
		mzSoundEffect = GameObject.Find("MzSoundEffect").
			GetComponent<MzSoundEffect>();
		mzAudioListener = GameObject.Find("Player").
			GetComponent<AudioListener>();
		mzReadyClear = GameObject.Find("MzSoundEffect").
			GetComponent<AudioListener>();
		cameraController = GameObject.Find("CameraManager").
			GetComponent<CameraManager>();
		mzBGM = GameObject.Find ("MzBGM").
			GetComponent<AudioSource>();
		playerRenderer = GameObject.Find ("Player").
			GetComponent<MeshRenderer> ();
	}

	void Start()
	{
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

		Ready ();
	}
		
	void Update()
	{
		switch (state) {

		case GameState.READY:
			if (Input.GetMouseButtonUp (0))
				ReadyGo ();
			break;

		case GameState.READYGO:
			Invoke("Playing", 2.0f);
			break;

		case GameState.PLAYING:
			if (MapCrystal == true) {
				buttonMap.gameObject.SetActive (true);
			} else {
				buttonMap.gameObject.SetActive (false);
			}
			if(Light == true) {
				getLight.gameObject.SetActive (true);
				lightLabel.enabled = true;
			}
			if(Croquette == true) {
				croquetteLabel.enabled = true;
			}

			if(mzTimer.GetTimeRemaining() == 0)
			{
				mzTimer.StopTimer();
				TimeUp();
				GameIsOver = true;
			}
			break;

		case GameState.GIVEUP:
			if(Light) {
				lightLabel.enabled = true;
			}
			if(Croquette) {
				croquetteLabel.enabled = true;
			}
			break;

		case GameState.MAP:
			if(Light) {
				lightLabel.enabled = true;
			}
			if(Croquette) {
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

			Invoke ("Clear", 4.0f);
			break;

		case GameState.CLEAR:
			break;

		case GameState.GAMEOVER:
			break;
		}
	}


	void AllFalse()
	{
		playerRenderer.enabled = false;

		mzDescriptionLabel.enabled = false;
		mzStartLabel.enabled = false;
		mzClearLabel.enabled = false;

		mzTimerLabel.enabled = false;
		lightLabel.enabled = false;
		croquetteLabel.enabled = false;
		giveUpLabel.enabled = false;
		timeUpLabel.enabled = false;
		failerLabel.enabled = false;
		goalLabel.enabled = false;

		buttonForward.gameObject.SetActive (false);
		buttonBack.gameObject.SetActive (false);
		buttonLeft.gameObject.SetActive (false);
		buttonRight.gameObject.SetActive (false);
		buttonFL.gameObject.SetActive (false);
		buttonFR.gameObject.SetActive (false);
		buttonBL.gameObject.SetActive (false);
		buttonBR.gameObject.SetActive (false);

		getLight.gameObject.SetActive (false);
		buttonGiveUp.gameObject.SetActive (false);
		buttonCancel.gameObject.SetActive (false);
		buttonGameOver.gameObject.SetActive (false);
		buttonMap.gameObject.SetActive (false);
		buttonToMz.gameObject.SetActive (false);
		buttonRestart.gameObject.SetActive (false);
		buttonNextMz.gameObject.SetActive (false);
		buttonToTitle.gameObject.SetActive (false);

		playerGoal.gameObject.SetActive (false);

		mzAudioListener.enabled = false;
		mzReadyClear.enabled = false;

		fadeBlack.enabled = false;
	}

	void Ready()
	{
		state = GameState.READY;
		cameraController.ShowPlayerCamera();
		AllFalse();

		player.gameObject.SetActive (true);
		mzReadyClear.enabled = true;
		mzDescriptionLabel.enabled = true;
		if (SceneManager.GetActiveScene().name == "Maze00") {
			mzDescriptionLabel.text = "0面はチュートリアルです。\nここでは各基本アイテムの効果を説明していきます。\n" +
				"制限時間内にすべてのアイテムを取得した後、\nゴールを目指して下さい。\n\n画面クリックでゲーム開始です。";
		}
		else if (SceneManager.GetActiveScene().name == "Maze01") {
			mzDescriptionLabel.text = "1面は、単純な迷路です。\n制限時間内に出口を目指して下さい。\n\n" +
				"画面クリックでゲーム開始です。";
		}
		else if (SceneManager.GetActiveScene().name == "Maze02") {
			mzDescriptionLabel.text = "2面はロボットが襲ってきます。\n捕まると30秒間気絶させられ、スタート地点に\n" +
				"戻されるので、上手く逃げ回りつつゴールを\n目指して下さい。\n\n" +
				"画面クリックでゲーム開始です。";
		}
		mzTimer.ResetTimer();
	}

	void ReadyGo()
	{
		state = GameState.READYGO;
		AllFalse();
		mzSoundEffect.ReadyGoSound();

		mzReadyClear.enabled = true;
		mzStartLabel.enabled = true;
		if (SceneManager.GetActiveScene().name == "Maze00") {
			mzStartLabel.text = "0 面 スタート !";
		}
		else if (SceneManager.GetActiveScene().name == "Maze01") {
			mzStartLabel.text = "1 面 スタート !";
		}
		else if (SceneManager.GetActiveScene().name == "Maze02") {
			mzStartLabel.text = "2 面 スタート !";
		}
	}

	void Playing()
	{
		state = GameState.PLAYING;
		AllFalse();

		mzTimerLabel.enabled = true;
		buttonForward.gameObject.SetActive (true);
		buttonBack.gameObject.SetActive (true);
		buttonLeft.gameObject.SetActive (true);
		buttonRight.gameObject.SetActive (true);
		buttonFL.gameObject.SetActive (true);
		buttonFR.gameObject.SetActive (true);
		buttonBL.gameObject.SetActive (true);
		buttonBR.gameObject.SetActive (true);
		buttonGiveUp.gameObject.SetActive (true);
		mzAudioListener.enabled = true;

		mzTimer.StartTimer ();
		Time.timeScale = 1.0f;
	}

	void GiveUp()
	{
		state = GameState.GIVEUP;
		Time.timeScale = 0.0f;
		AllFalse();

		mzTimerLabel.enabled = true;
		giveUpLabel.enabled = true;
		buttonCancel.gameObject.SetActive (true);
		buttonGameOver.gameObject.SetActive (true);
		mzReadyClear.enabled = true;
	}

	void Map()
	{
		state = GameState.MAP;
		cameraController.ShowMapCamera();
		Time.timeScale = 0.0f;
		AllFalse();

		player.gameObject.SetActive (true);
		playerRenderer.enabled = true;
		mzTimerLabel.enabled = true;
		buttonToMz.gameObject.SetActive (true);
		mzReadyClear.enabled = true;
	}

	void TimeUp()
	{
		state = GameState.TIMEUP;
		AllFalse();
		mzSoundEffect.TimeUpSound();

		timeUpLabel.enabled = true;
		mzReadyClear.enabled = true;
	}

	void Failure()
	{
		state = GameState.FAILURE;
		cameraController.ShowPlayerCamera();
		AllFalse();

		failerLabel.enabled = true;
		buttonGameOver.gameObject.SetActive (true);
		buttonRestart.gameObject.SetActive (true);
		mzReadyClear.enabled = true;
	}

	void Goal()
	{
		state = GameState.GOAL;
		cameraController.ShowGoalCamera();
		AllFalse();
		mzSoundEffect.GoalSound();

		goalLabel.enabled = true;
		playerGoal.gameObject.SetActive (true);
		mzReadyClear.enabled = true;
	}

	void Clear()
	{
		state = GameState.CLEAR;

		mzClearLabel.enabled = true;
		if (SceneManager.GetActiveScene().name == "Maze00") {
			mzClearLabel.text = "0 面 クリア !\nさあ次からが本格的な\n" +
				"迷路探索の始まりです !";
			mzClearLabel.fontSize = 60;
		}
		else if (SceneManager.GetActiveScene().name == "Maze01") {
			mzClearLabel.text = "1 面\nクリア !";
		}
		else if (SceneManager.GetActiveScene().name == "Maze02") {
			mzClearLabel.text = "2 面\nクリア !";
		}

		goalLabel.enabled = false;
		buttonNextMz.gameObject.SetActive (true);
		buttonToTitle.gameObject.SetActive (true);
	}


	void GameOver() {
		SceneManager.LoadScene("GameOver");
	}

	void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	void ToTitle() {
		SceneManager.LoadScene ("Title");
	}

	void ToNextMz() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
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
		mzBGM.Stop ();
		mzSoundEffect.EnterSound();
		fadeBlack.enabled = true;
		Fade = true;
		Invoke("Restart", 3.0f);
	}

	public void OnButtonNextMzClicked() {
		mzBGM.Stop ();
		mzSoundEffect.EnterSound ();
		fadeBlack.enabled = true;
		Fade = true;
		Invoke ("ToNextMz", 3.0f);
	}

	public void OnButtonToTitleClicked() {
		mzBGM.Stop ();
		mzSoundEffect.EnterSound ();
		fadeBlack.enabled = true;
		Fade = true;
		Invoke ("ToTitle", 4.0f);
	}
}