using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	enum GameState
	{
		READY,
		READYGO,
		PLAYING,
		GOAL,
		CLEAR,
		TIMEUP,
		FAILURE,
		GIVEUP,
		GAMEOVER
	}

	/*---各テキストやボタン---*/
	[SerializeField] Text Maze01StartLabel;
	[SerializeField] Text Maze01descriptionLabel;
	[SerializeField] Text Maze01GoalLabel;
	[SerializeField] Text Maze01ClearLabel;
	[SerializeField] Text FailerLabel;
	[SerializeField] Text Maze01TimerLabel;
	[SerializeField] Text TimeUpLabel;
	[SerializeField] Text GiveUpLabel;
	[SerializeField] GameObject NextMazeButton;
	[SerializeField] GameObject ToTitleButton;
	[SerializeField] GameObject GameOverButton;
	[SerializeField] GameObject RestartButton;
	[SerializeField] GameObject GiveUpButton;
	[SerializeField] GameObject CancelButton;
	[SerializeField] GameObject ReadyCamera;
	[SerializeField] GameObject SpawnPoint;
	[SerializeField] GameObject Player;
	/*----------------------*/

	/*---タイマーとステート---*/
	private Timer maze01Timer;
	private GameState state;
	/*----------------------*/

	//1面で使用するサウンド
	Maze01SoundEffect maze01soundEffect;

	[SerializeField] Image FadeBlack;
	float Alpha;
	bool FadeOut;

	void Start()
	{
		FadeOut = false;
		Alpha = 0;
		FadeBlack.gameObject.SetActive(false);

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

		case GameState.GOAL:
			maze01soundEffect.GoalSound();
			Invoke ("Clear", 4.0f);
			enabled = false;
			break;

		case GameState.CLEAR:
			if(FadeOut == true)
			{
				FadeBlack.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, Alpha);
				Alpha += Time.deltaTime;
				if(Alpha >= 1)
				{
					Invoke("ToTitle", 2.0f);
				}
			}
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
		Maze01GoalLabel.enabled = false;
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
		Maze01GoalLabel.enabled = false;
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
		Maze01GoalLabel.enabled = false;
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

	void Goal()
	{
		state = GameState.GOAL;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01GoalLabel.enabled = true;
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
		ReadyCamera.gameObject.SetActive (false);
	}

	void Clear()
	{
		state = GameState.CLEAR;

		enabled = true;
		
		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01GoalLabel.enabled = false;
		Maze01ClearLabel.enabled = true;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = false;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = false;
		
		NextMazeButton.gameObject.SetActive (true);
		ToTitleButton.gameObject.SetActive (true);
		RestartButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (false);
	}

	void TimeUp()
	{
		state = GameState.TIMEUP;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01GoalLabel.enabled = false;
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
		Maze01GoalLabel.enabled = false;
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
		Maze01GoalLabel.enabled = false;
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
		SceneManager.LoadScene("GameOver");
	}

	void ToTitle()
	{
		SceneManager.LoadScene("Title");
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
	}
		
	public void OnNextMazeButtonClicked()
	{
		maze01soundEffect.EnterSound();
	}

	public void OnToTitleButtonClicked()
	{
		maze01soundEffect.ToTitleSound();

		if(FadeBlack.gameObject.activeSelf == false)
		{
			FadeBlack.gameObject.SetActive(true);
			FadeOut = true;
		}
		Invoke("CLEAR", 2.0f);
	}

	public void OnGameOverButtonClicked()
	{
		GameOver();
	}

	public void OnRestartButtonClicked()
	{
		maze01soundEffect.ToTitleSound();
		Invoke("Restart", 3.0f);
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