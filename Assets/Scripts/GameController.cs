using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public static bool MapCrystal = false;
	public static bool Light = false;
	public static bool Croquette = false;
	public static bool GameIsOver = false;
	public static bool Dead = false;
	public static bool GoalAndClear = false;
	public static bool StartTween = false;

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
		
	[SerializeField] Text MzDescriptionLabel = null;
	[SerializeField] Text MzStartLabel = null;
	[SerializeField] Text MzClearLabel = null;

	[SerializeField] Text MzTimerLabel = null;
	[SerializeField] Text GiveUpLabel = null;
	[SerializeField] Text TimeUpLabel = null;
	[SerializeField] Text FailerLabel = null;
	[SerializeField] Text GoalLabel = null;

	[SerializeField] GameObject GiveUpButton = null;
	[SerializeField] GameObject CancelButton = null;
	[SerializeField] GameObject GameOverButton = null;
	[SerializeField] GameObject MapButton = null;
	[SerializeField] GameObject ToMzButton = null;
	[SerializeField] GameObject RestartButton = null;
	[SerializeField] GameObject NextMzButton = null;
	[SerializeField] GameObject ToTitleButton = null;

	[SerializeField] GameObject PlayerSpawnPoint = null;
	[SerializeField] GameObject PlayerGoal = null;

	private MzTimer mzTimer;

	MzSoundEffect mzSoundEffect;
	CameraController cameraController;
	AudioSource mzBGM;

	void Start()
	{
		MapCrystal = false;
		Light = false;
		Croquette = false;
		GameIsOver = false;
		Dead = false;
		GoalAndClear = false;
		StartTween = false;

		mzSoundEffect = GameObject.Find("MzSoundController").GetComponent<MzSoundEffect>();
		mzTimer = GameObject.Find ("MzTimerLabel").GetComponent<MzTimer> ();
		cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
		mzBGM = GameObject.Find ("MzBGM").GetComponent<AudioSource> ();
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
			if(MapCrystal)
			{
				MapButton.gameObject.SetActive (true);
			}

			if(mzTimer.GetTimeRemaining() == 0)
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
			Dead = true;
			break;

		case GameState.GOAL:
			GoalAndClear = true;
			StartTween = true;

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
		MzDescriptionLabel.enabled = false;
		MzStartLabel.enabled = false;
		MzClearLabel.enabled = false;

		MzTimerLabel.enabled = false;
		GiveUpLabel.enabled = false;
		TimeUpLabel.enabled = false;
		FailerLabel.enabled = false;
		GoalLabel.enabled = false;

		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		MapButton.gameObject.SetActive (false);
		ToMzButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		NextMzButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);

		PlayerSpawnPoint.gameObject.SetActive (false);
	}

	void Ready()
	{
		state = GameState.READY;
		cameraController.ShowReadyCamera();

		AllFalse ();
		MzDescriptionLabel.enabled = true;
		if (SceneManager.GetActiveScene().name == "Maze00") {
			MzDescriptionLabel.text = "0面はチュートリアルです。\nここでは各基本アイテムの効果を説明していきます。\n" +
				"制限時間内にすべてのアイテムを取得した後、ゴールを目指して下さい。\n\n画面クリックでゲーム開始です。";
		}
		else if (SceneManager.GetActiveScene().name == "Maze01") {
			MzDescriptionLabel.text = "1面は、単純な迷路です。\n制限時間内に出口を目指して下さい。\n\n" +
				"画面クリックでゲーム開始です。";
		}
		PlayerGoal.gameObject.SetActive (false);

		mzTimer.ResetTimer();
	}

	void ReadyGo()
	{
		state = GameState.READYGO;
		mzSoundEffect.ReadyGoSound();

		AllFalse ();
		MzStartLabel.enabled = true;
		if (SceneManager.GetActiveScene().name == "Maze00") {
			MzStartLabel.text = "0 面 スタート !";
		}
		else if (SceneManager.GetActiveScene().name == "Maze01") {
			MzStartLabel.text = "1 面 スタート !";
		}
	}

	void Playing()
	{
		state = GameState.PLAYING;
		cameraController.ShowPlayerCamera();

		AllFalse ();
		MzTimerLabel.enabled = true;
		GiveUpButton.gameObject.SetActive (true);
		PlayerSpawnPoint.gameObject.SetActive (true);

		mzTimer.StartTimer ();
		Time.timeScale = 1.0f;
	}

	void GiveUp()
	{
		state = GameState.GIVEUP;

		AllFalse ();
		MzTimerLabel.enabled = true;
		GiveUpLabel.enabled = true;
		CancelButton.gameObject.SetActive (true);
		GameOverButton.gameObject.SetActive (true);

		Time.timeScale = 0.0f;
	}

	void Map()
	{
		state = GameState.MAP;
		cameraController.ShowMapCamera();

		AllFalse ();
		MzTimerLabel.enabled = true;
		ToMzButton.gameObject.SetActive (true);

		Time.timeScale = 0.0f;
	}

	void TimeUp()
	{
		state = GameState.TIMEUP;

		AllFalse ();
		TimeUpLabel.enabled = true;

		mzSoundEffect.TimeUpSound();
	}

	void Failure()
	{
		state = GameState.FAILURE;

		AllFalse ();
		FailerLabel.enabled = true;
		GameOverButton.gameObject.SetActive (true);
		RestartButton.gameObject.SetActive (true);
	}

	void Goal()
	{
		state = GameState.GOAL;

		mzSoundEffect.GoalSound();
		cameraController.ShowGoalCamera();

		AllFalse ();
		GoalLabel.enabled = true;
		PlayerGoal.gameObject.SetActive (true);
	}

	void Clear()
	{
		state = GameState.CLEAR;

		AllFalse ();
		MzClearLabel.enabled = true;
		if (SceneManager.GetActiveScene().name == "Maze00") {
			MzClearLabel.text = "0 面\nクリア !";
		}
		else if (SceneManager.GetActiveScene().name == "Maze01") {
			MzClearLabel.text = "1 面\nクリア !";
		}

		NextMzButton.gameObject.SetActive (true);
		ToTitleButton.gameObject.SetActive (true);
	}



	void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
	}

	void ToTitle()
	{
		SceneManager.LoadScene("Title");
	}


	public void OnGiveUpButtonClicked()
	{
		mzSoundEffect.EnterSound();
		GiveUp();
	}

	public void OnCancelButtonClicked()
	{
		mzSoundEffect.ExitSound();
		Playing();
	}

	public void OnGameOverButtonClicked()
	{
		GameOver();
	}

	public void OnMapButtonClicked()
	{
		mzSoundEffect.EnterSound();
		Map();
	}

	public void OnToMzButtonClicked()
	{
		mzSoundEffect.ExitSound();
		Playing();
	}

	public void OnRestartButtonClicked()
	{
		mzSoundEffect.ToTitleSound();
		Invoke("Restart", 3.0f);
	}
		
	public void OnNextMzButtonClicked()
	{
		mzSoundEffect.EnterSound();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void OnToTitleButtonClicked()
	{
		mzBGM.Stop ();
		mzSoundEffect.ToTitleSound();
		Invoke("ToTitle", 4.0f);
	}
}