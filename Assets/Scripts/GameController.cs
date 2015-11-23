using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	enum GameState
	{
		READY,
		READYGO,
		PLAYING,
		CLEAR,
		TIMEUP,
		FAILURE,
		GIVEUP,
		GAMEOVER
	}

	/*---各テキストやボタン---*/
	public Text Maze01StartLabel;
	public Text Maze01descriptionLabel;
	public Text Maze01ClearLabel;
	public Text FailerLabel;
	public Text Maze01TimerLabel;
	public Text TimeUpLabel;
	public Text GiveUpLabel;
	public GameObject NextMazeButton;
	public GameObject ToTitleButton;
	public GameObject GameOverButton;
	public GameObject RestartButton;
	public GameObject GiveUpButton;
	public GameObject CancelButton;
	public GameObject ReadyCamera;
	public GameObject SpawnPoint;
	/*----------------------*/

	/*---タイマーとステート---*/
	private Timer maze01Timer;
	private GameState state;
	/*----------------------*/

	//1面のサウンド
	Maze01SoundEffect maze01soundEffect;

	void Start()
	{
		//サウンド類とTimerスクリプトを呼び出す
		maze01soundEffect = GameObject.Find("Maze01SoundController").GetComponent<Maze01SoundEffect>();
		maze01Timer = GameObject.Find ("Maze01TimerLabel").GetComponent<Timer> ();
		Ready ();
	}

	void Update()
	{
		switch (state) {

		case GameState.READY:
			if (Input.GetMouseButtonDown (0))
				ReadyGo ();
			break;

		case GameState.READYGO:
			Invoke("Playing", 2.0f);
			break;

		case GameState.PLAYING:
			//残り時間が0になったらタイムオーバーのステートに移行する
			if(maze01Timer.GetTimeRemaining() == 0)
			{
				maze01Timer.StopTimer();
				TimeUp();
			}
			break;

		case GameState.CLEAR:
			break;

		case GameState.TIMEUP:
			Invoke("Failure", 2.0f);
			break;

		case GameState.FAILURE:
			break;

		case GameState.GIVEUP:
			//残り時間が0になったらタイムオーバーのステートに移行する
			if(maze01Timer.GetTimeRemaining() == 0)
			{
				maze01Timer.StopTimer();
				TimeUp();
			}
			break;

		case GameState.GAMEOVER:
			break;
		}
	}

	void Ready()
	{
		state = GameState.READY;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = true;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = false;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (true);

		maze01Timer.ResetTimer();
	}

	void ReadyGo()
	{
		state = GameState.READYGO;

		Maze01StartLabel.enabled = true;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = false;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (true);

		maze01soundEffect.ReadyGoSound();
	}

	void Playing()
	{
		state = GameState.PLAYING;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = true;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = false;

		RestartButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (true);
		CancelButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (true);
		ReadyCamera.gameObject.SetActive (false);

		maze01Timer.StartTimer ();

		Time.timeScale = 1.0f;
	}

	void Clear()
	{
		state = GameState.CLEAR;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = true;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = false;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (true);
		RestartButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (false);

		maze01soundEffect.ClearSound();
	}

	void TimeUp()
	{
		state = GameState.TIMEUP;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = true;
		TimeUpLabel.enabled = true;
		GiveUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (false);

		maze01soundEffect.TimeUpSound();
	}

	void Failure()
	{
		state = GameState.FAILURE;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = true;
		Maze01TimerLabel.enabled = false;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (true);
		GameOverButton.gameObject.SetActive (true);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (false);
	}

	void GiveUp()
	{
		state = GameState.GIVEUP;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = true;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = true;

		NextMazeButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (true);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (true);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (false);

		Time.timeScale = 0.0f;
	}

	void GameOver()
	{
		Application.LoadLevel("GameOver");
	}

	void ToTitle()
	{
		Application.LoadLevel("Title");
	}
		
	public void OnNextMazeButtonClicked()
	{
		maze01soundEffect.EnterSound();
	}

	public void OnToTitleButtonClicked()
	{
		maze01soundEffect.ToTitleSound();
		Invoke("ToTitle", 3.0f);
	}

	public void OnGameOverButtonClicked()
	{
		GameOver();
	}

	public void OnRestartButtonClicked()
	{
		maze01soundEffect.EnterSound();
		Invoke("Ready", 2.0f);
	}

	public void OnGiveUpButtonClicked()
	{
		maze01soundEffect.EnterSound();
		GiveUp();
	}

	public void OnCancelButtonClicked()
	{
		maze01soundEffect.ExitSound();
		Playing();
	}
}