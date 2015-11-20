using UnityEngine;
using System.Collections;

public class Maze01SoundEffect : MonoBehaviour {
	
	private AudioSource Maze01BGM;
	private AudioSource ClearSE;
	private AudioSource EnterSE;
	private AudioSource ExitSE;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		Maze01BGM = audioSources [0];
		ClearSE = audioSources [1];
		EnterSE = audioSources [2];
		ExitSE = audioSources [3];
	}

	public void EnterSound() {
		Maze01BGM.PlayOneShot (EnterSE.clip);
	}

	public void ExitSound() {
		ClearSE.PlayOneShot (ExitSE.clip);
	}
}
