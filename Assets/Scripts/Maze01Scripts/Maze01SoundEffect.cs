﻿using UnityEngine;
using System.Collections;

public class Maze01SoundEffect : MonoBehaviour {
	
	private AudioSource Maze01BGM;
	private AudioSource GoalSE;
	private AudioSource EnterSE;
	private AudioSource ExitSE;
	private AudioSource ReadyGoSE;
	private AudioSource TimeUpSE;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		Maze01BGM = audioSources [0];
		GoalSE = audioSources [1];
		EnterSE = audioSources [2];
		ExitSE = audioSources [3];
		ReadyGoSE = audioSources [4];
		TimeUpSE = audioSources [5];
	}

	public void EnterSound() {
		Maze01BGM.PlayOneShot (EnterSE.clip);
	}

	public void ExitSound() {
		ExitSE.PlayOneShot (ExitSE.clip);
	}

	public void ReadyGoSound() {
		ReadyGoSE.PlayOneShot (ReadyGoSE.clip);
	}

	public void TimeUpSound() {
		TimeUpSE.PlayOneShot (TimeUpSE.clip);
	}

	public void GoalSound() {
		GoalSE.PlayOneShot (GoalSE.clip);
	}

	public void ToTitleSound() {
		EnterSE.PlayOneShot (EnterSE.clip);
		Destroy (Maze01BGM);
	}
}