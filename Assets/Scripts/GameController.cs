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
	public Text Maze01StartLabel;
	public Text Maze01descriptionLabel;
	public Text Maze01ClearLabel;
	public Text Maze01TimelimitLabel;
	public GameObject NextMazeButton;
	public GameObject ReturnButton;
	public GameObject RestartButton;

	void Start()
	{
		maze01soundEffect = GameObject.Find("Maze01SoundController").GetComponent<Maze01SoundEffect>();
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
		Maze01TimelimitLabel.enabled = false;

		NextMazeButton.gameObject.SetActive (false);
		RestartButton.gameObject.SetActive (false);
		ReturnButton.gameObject.SetActive (false);

		/*
		Maze01SoundEffect maze01soundEffect;
		public Text Maze01StartLabel;
		public Text Maze01descriptionLabel;
		public Text Maze01ClearLabel;
		public Text Maze01TimelimitLabel;
		public GameObject NextMazeButton;
		public GameObject ReturnButton;
		public GameObject RestartButton;
		*/
	}

	void Playing()
	{
		state = GameState.PLAYING;

		Maze01TimelimitLabel.enabled = false;
	}

	void Clear()
	{
		state = GameState.CLEAR;

		Maze01ClearLabel.enabled = true;
		NextMazeButton.gameObject.SetActive (true);
		ReturnButton.gameObject.SetActive (true);
	}

	void GameOver()
	{
		state = GameState.GAMEOVER;

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
}