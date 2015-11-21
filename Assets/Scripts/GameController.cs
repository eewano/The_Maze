using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	enum GameState
	{
		READY,
		PLAYING,
		CLEAR,
		GAMEOVER
	}

	GameState state;

	Maze01SoundEffect maze01soundEffect;
	Timer maze01Timer;
	public Text Maze01StartLabel;
	public Text Maze01descriptionLabel;
	public Text Maze01ClearLabel;
	public Text GameOverLabel;
	public Text Maze01TimerLabel;
	public GameObject NextMazeButton;
	public GameObject ReturnButton;
	public GameObject RestartButton;
	public GameObject GiveUpButton;
	public GameObject SpawnPoint;
	public GameObject ReadyCamera;

	void Start()
	{
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
			break;

		case GameState.CLEAR:
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
		GameOverLabel.enabled = false;
		Maze01TimerLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (false);
		SpawnPoint.gameObject.SetActive (false);
		ReadyCamera.gameObject.SetActive (true);
	}

	void Playing()
	{
		state = GameState.PLAYING;

		Maze01StartLabel.enabled = true;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		GameOverLabel.enabled = false;
		Maze01TimerLabel.enabled = true;

		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (false);
		GiveUpButton.gameObject.SetActive (true);
		SpawnPoint.gameObject.SetActive (true);
		ReadyCamera.gameObject.SetActive (false);

		maze01Timer.StartTimer ();

		maze01soundEffect.ReadyGoSound();
		Destroy(Maze01StartLabel, 2.0f);
	}

	void Clear()
	{
		state = GameState.CLEAR;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = true;
		GameOverLabel.enabled = false;
		Maze01TimerLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (true);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (true);
	}

	void GameOver()
	{
		state = GameState.GAMEOVER;

		Maze01StartLabel.enabled = false;
		Maze01descriptionLabel.enabled = false;
		Maze01ClearLabel.enabled = false;
		GameOverLabel.enabled = true;
		Maze01TimerLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (true);
		ReturnButton.gameObject.SetActive (true);
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
		maze01soundEffect.ExitSound();
	}
}