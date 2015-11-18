using UnityEngine;
using System.Collections;

public class Maze01SoundEffect : MonoBehaviour {
	
	private AudioSource Maze01BGM;
	private AudioSource ClearSE;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		Maze01BGM = audioSources [0];
		ClearSE = audioSources [1];
	}

	public void Maze01GameStart() {
		Maze01BGM.PlayOneShot (Maze01BGM.clip);
	}

	public void Maze01Clear() {
		Destroy(Maze01BGM);
		ClearSE.PlayOneShot (ClearSE.clip);
	}
}
