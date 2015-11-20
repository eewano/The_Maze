using UnityEngine;
using System.Collections;

public class Maze01SoundEffect : MonoBehaviour {
	
	private AudioSource Maze01BGM;
	private AudioSource ClearSE;
	private AudioSource EnterSE;
	private AudioSource ExitSE;
	private AudioSource ReadyGoSE;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		Maze01BGM = audioSources [0];
		ClearSE = audioSources [1];
		EnterSE = audioSources [2];
		ExitSE = audioSources [3];
		ReadyGoSE = audioSources [4];
	}

	public void EnterSound() {
		Maze01BGM.PlayOneShot (EnterSE.clip);
	}

	public void ExitSound() {
		ClearSE.PlayOneShot (ExitSE.clip);
	}

	public void ReadyGoSound() {
		ReadyGoSE.PlayOneShot (ReadyGoSE.clip);
	}
}
