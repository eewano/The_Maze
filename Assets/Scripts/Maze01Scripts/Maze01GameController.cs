using UnityEngine;
using System.Collections;

public class Maze01GameController : MonoBehaviour {

	enum GameState
	{
		READY,
		PLAYING,
		CLEAR,
		GAMEOVER
	}

	GameState state;

	public PlayerController player;
	public Text GameStartLabel;
	public Text DescriptionLabel;
	public Text TimeleftLabel;
	public Text StageClearLabel;
	SoundEffect soundEffect;

	void Start () {
		READY ();
	}

	void LateUpdate()
	{
		switch(state)
		{
		case GameState.READY:
			if(Input.GetMouseButtonDown(0))
				Playing();
			break;

		case GameState.PLAYING:
			if(Player.IsDead())
				Gameover();
			break;

		case GameState.CLEAR:
			if(Player.IsGameCleared())
				GameClear();
			break;

		case GameState.GAMEOVER:
			if(Input.GetMouseButtonDown(0))
				Reload();
			break;
		}
	}

	void Ready()
	{
		state = GameState.READY;

		SpawnPoint.SetSteerActive (false);
		GameStartLabel.enabled = true;
		DescriptionLabel.enabled = true;
		soundEffect = GameObject.Find ("Maze01SoundController").GetComponent<Maze01SoundEffect> ();
	}

	void Playing()
	{
		state GameState.PLAYING;
	}

	void Clear()
	{
		state GameState.CLEAR;
	}

	void Gameover()
	{
		state GameState.GAMEOVER;
	}

	void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
