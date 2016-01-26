using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static bool MapCrystal = false;
	public static bool Light = false;
	public static bool Croquette = false;
	public static bool GameIsOver = false;
	public static bool Fall = false;
	public static bool Dead = false;
	public static bool GoalAndClear = false;
	public static bool StartTween = false;

	[SerializeField] Text MzDescriptionLabel = null;
	[SerializeField] Text MzStartLabel = null;
	[SerializeField] Text MzClearLabel = null;

	[SerializeField] Text MzTimerLabel = null;
	[SerializeField] Text GiveUpLabel = null;
	[SerializeField] Text TimeUpLabel = null;
	[SerializeField] Text FailerLabel = null;
	[SerializeField] Text GoalLabel = null;

	[SerializeField] GameObject ForwardButton = null;
	[SerializeField] GameObject BackButton = null;
	[SerializeField] GameObject LeftButton = null;
	[SerializeField] GameObject RightButton = null;
	[SerializeField] GameObject FLButton = null;
	[SerializeField] GameObject FRButton = null;
	[SerializeField] GameObject BLButton = null;
	[SerializeField] GameObject BRButton = null;

	[SerializeField] GameObject GiveUpButton = null;
	[SerializeField] GameObject CancelButton = null;
	[SerializeField] GameObject GameOverButton = null;
	[SerializeField] GameObject MapButton = null;
	[SerializeField] GameObject ToMzButton = null;
	[SerializeField] GameObject RestartButton = null;
	[SerializeField] GameObject NextMzButton = null;
	[SerializeField] GameObject ToTitleButton = null;

	[SerializeField] GameObject Player = null;
	[SerializeField] GameObject PlayerGoal = null;

	private MzTimer mzTimer;
	private MzSoundEffect mzSoundEffect;
	private CameraController cameraController;
	private AudioSource mzBGM;

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
		MzDescriptionLabel.enabled = false;
		MzStartLabel.enabled = false;
		MzClearLabel.enabled = false;

		MzTimerLabel.enabled = false;
		GiveUpLabel.enabled = false;
		TimeUpLabel.enabled = false;
		FailerLabel.enabled = false;
		GoalLabel.enabled = false;

		ForwardButton.gameObject.SetActive (false);
		BackButton.gameObject.SetActive (false);
		LeftButton.gameObject.SetActive (false);
		RightButton.gameObject.SetActive (false);
		FLButton.gameObject.SetActive (false);
		FRButton.gameObject.SetActive (false);
		BLButton.gameObject.SetActive (false);
		BRButton.gameObject.SetActive (false);

		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		MapButton.gameObject.SetActive (false);
		ToMzButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		NextMzButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);

		Player.gameObject.SetActive (false);
		PlayerGoal.gameObject.SetActive (false);
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
		ForwardButton.gameObject.SetActive (true);
		BackButton.gameObject.SetActive (true);
		LeftButton.gameObject.SetActive (true);
		RightButton.gameObject.SetActive (true);
		FLButton.gameObject.SetActive (true);
		FRButton.gameObject.SetActive (true);
		BLButton.gameObject.SetActive (true);
		BRButton.gameObject.SetActive (true);
		GiveUpButton.gameObject.SetActive (true);
		Player.gameObject.SetActive (true);

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
		Player.gameObject.SetActive (true);

		Time.timeScale = 0.0f;
	}

	void Map()
	{
		state = GameState.MAP;
		cameraController.ShowMapCamera();

		AllFalse ();
		MzTimerLabel.enabled = true;
		ToMzButton.gameObject.SetActive (true);
		Player.gameObject.SetActive (true);

		Time.timeScale = 0.0f;
	}

	void TimeUp()
	{
		state = GameState.TIMEUP;

		AllFalse ();
		TimeUpLabel.enabled = true;
		Player.gameObject.SetActive (true);

		mzSoundEffect.TimeUpSound();
	}

	void Failure()
	{
		state = GameState.FAILURE;
		cameraController.ShowPlayerCamera();

		AllFalse ();
		FailerLabel.enabled = true;
		GameOverButton.gameObject.SetActive (true);
		RestartButton.gameObject.SetActive (true);
		Player.gameObject.SetActive (true);
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

		MzClearLabel.enabled = true;
		if (SceneManager.GetActiveScene().name == "Maze00") {
			MzClearLabel.text = "0 面 クリア !\nさあ次からが本格的な\n迷路探索の始まりです !";
			MzClearLabel.fontSize = 60;
		}
		else if (SceneManager.GetActiveScene().name == "Maze01") {
			MzClearLabel.text = "1 面\nクリア !";
		}

		GoalLabel.enabled = false;
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

	void ToNext()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
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
		mzBGM.Stop ();
		mzSoundEffect.ToTitleSound();
		Invoke("Restart", 3.0f);
	}

	public void OnNextMzButtonClicked()
	{
		//AllFalse ();
		mzBGM.Stop ();
		mzSoundEffect.EnterSound();
		Invoke("ToNext", 4.0f);
		//return;
	}

	public void OnToTitleButtonClicked()
	{
		//AllFalse ();
		mzBGM.Stop ();
		mzSoundEffect.ToTitleSound();
		Invoke("ToTitle", 4.0f);
		//return;
	}
}