using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	enum GameState
	{
		READY,
		PLAYING,
		CLEAR,
		TIMEUP,
		GAMEOVER
	}

	/*---各テキストやボタン---*/
	public Text Maze01StartLabel;
	public Text Maze01descriptionLabel;
	public Text Maze01ClearLabel;
	public Text FailerLabel;
	public Text Maze01TimerLabel;
	public Text TimeUpLabel;
	public GameObject NextMazeButton;
	public GameObject ReturnButton;
	public GameObject RestartButton;
	public GameObject GiveUpButton;
	public GameObject SpawnPoint;
	public GameObject ReadyCamera;
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
				Playing ();
			break;

		case GameState.PLAYING:
			Destroy(Maze01StartLabel, 2.0f);

			if(maze01Timer.GetTimeRemaining() == 0)
			{
				maze01Timer.StopTimer();
				TimeUp();
			}
			break;

		case GameState.CLEAR:
			break;

		case GameState.TIMEUP:
			//Invoke("GameOver", 2.0f * Time.deltaTime);
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

		Maze01StartLabel.gameObject.SetActive (true);
		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (true);

		maze01Timer.StartTimer();
	}

	void Playing()
	{
		state = GameState.PLAYING;

		Maze01StartLabel.enabled = true;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = true;
		TimeUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (true);
		SpawnPoint.gameObject.SetActive (true);
		ReadyCamera.gameObject.SetActive (false);

		maze01soundEffect.ReadyGoSound();
		maze01Timer.StartTimer ();
	}

	void Clear()
	{
		state = GameState.CLEAR;

		//Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = true;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = false;
		TimeUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (true);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (true);
		GiveUpButton.gameObject.SetActive (false);
	}

	void TimeUp()
	{
		state = GameState.TIMEUP;

		//Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = true;
		TimeUpLabel.enabled = true;

		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (false);

		maze01soundEffect.TimeUpSound();
	}

	void GameOver()
	{
		state = GameState.GAMEOVER;

		//Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = true;
		Maze01TimerLabel.enabled = false;
		TimeUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (true);
		ReturnButton.gameObject.SetActive (true);
		GiveUpButton.gameObject.SetActive (false);
	}

	void Restart()
	{
		state = GameState.GAMEOVER;
	}

	void ReturnToTitle()
	{
		Application.LoadLevel("Title");
	}
		
	public void OnNextMazeButtonClicked()
	{
		maze01soundEffect.EnterSound();
	}

	public void OnReturnButtonClicked()
	{
		maze01soundEffect.ExitSound();
	}

	public void OnRestartButtonClicked()
	{
		maze01soundEffect.EnterSound();
	}

	public void OnGiveUpButtonClicked()
	{
		maze01soundEffect.EnterSound();
		//Invoke("Ready", 2.0f * Time.deltaTime);

	}
}