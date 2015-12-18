using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static bool GameIsOver = false;
	public static bool GoalAndClear = false;
	public static bool MapCrystalGet = false;

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
		MAP,
		GAMEOVER
	}

	/*---各テキストやボタン---*/
	[SerializeField] Text Maze01StartLabel = null;
	[SerializeField] Text Maze01descriptionLabel = null;
	[SerializeField] Text Maze01GoalLabel = null;
	[SerializeField] Text Maze01ClearLabel = null;
	[SerializeField] Text FailerLabel = null;
	[SerializeField] Text Maze01TimerLabel = null;
	[SerializeField] Text TimeUpLabel = null;
	[SerializeField] Text GiveUpLabel = null;
	[SerializeField] GameObject NextMazeButton = null;
	[SerializeField] GameObject ToTitleButton = null;
	[SerializeField] GameObject GameOverButton = null;
	[SerializeField] GameObject RestartButton = null;
	[SerializeField] GameObject GiveUpButton = null;
	[SerializeField] GameObject CancelButton = null;
	[SerializeField] GameObject MapButton = null;
	[SerializeField] GameObject ToMazeButton = null;
	[SerializeField] GameObject SpawnPoint = null;
	[SerializeField] GameObject ReadyLight = null;
	[SerializeField] GameObject Player;
	/*----------------------*/

	/*---タイマーとステート---*/
	private Timer maze01Timer;
	private GameState state;
	/*----------------------*/

	//1面で使用するサウンド
	Maze01SoundEffect maze01soundEffect;
	CameraController cameraController;

	[SerializeField] Image FadeBlack = null;
	float Alpha;
	bool FadeOut;

	void Start()
	{
		GameIsOver = false;
		GoalAndClear = false;
		MapCrystalGet = false;
		FadeOut = false;
		Alpha = 0;
		FadeBlack.gameObject.SetActive(false);

		//サウンド類とTimerスクリプトを呼び出す
		maze01soundEffect = GameObject.Find("Maze01SoundController").GetComponent<Maze01SoundEffect>();
		maze01Timer = GameObject.Find ("Maze01TimerLabel").GetComponent<Timer> ();
		cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
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
			if(MapCrystalGet)
			{
				MapButton.gameObject.SetActive (true);
			}
			//残り時間が0になったらタイムオーバーのステートに移行する
			if(maze01Timer.GetTimeRemaining() == 0)
			{
				maze01Timer.StopTimer();
				TimeUp();
				GameIsOver = true;
			}
			break;

		case GameState.GOAL:
			GoalAndClear = true;
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
			break;

		case GameState.MAP:
			break;

		case GameState.GAMEOVER:
			break;
		}
	}

	void Ready()
	{
		state = GameState.READY;

		cameraController.ShowReadyCamera();

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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (true);

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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (true);

		maze01soundEffect.ReadyGoSound();
	}

	void Playing()
	{
		state = GameState.PLAYING;

		cameraController.ShowPlayerCamera();

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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (true);
		ReadyLight.gameObject.SetActive (false);



		maze01Timer.StartTimer ();

		Time.timeScale = 1.0f;
	}

	void Goal()
	{
		state = GameState.GOAL;

		cameraController.ShowGoalCamera();

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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (false);
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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (false);
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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (false);

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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (false);
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
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (false);

		Time.timeScale = 0.0f;
	}

	void Map()
	{
		state = GameState.MAP;

		cameraController.ShowMapCamera();

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01GoalLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		FailerLabel.enabled = false;
		Maze01TimerLabel.enabled = true;
		TimeUpLabel.enabled = false;
		GiveUpLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		ToTitleButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		GameOverButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		CancelButton.gameObject.SetActive (false);
		MapButton.gameObject.SetActive (false);
		ToMazeButton.gameObject.SetActive (true);
		SpawnPoint.gameObject.SetActive (false);
		ReadyLight.gameObject.SetActive (false);

		Time.timeScale = 0.0f;

		return;
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

	public void OnMapButtonClicked()
	{
		maze01soundEffect.EnterSound();
		Map();
	}

	public void OnToMazeButtonClicked()
	{
		maze01soundEffect.ExitSound();
		Playing();
	}
}