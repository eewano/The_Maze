using UnityEngine;
using System.Collections;

public class TitleSoundEffect : MonoBehaviour {

	private AudioSource TitleBGM;
	private AudioSource EnterSE;
	private AudioSource ExitSE;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		TitleBGM = audioSources [0];
		EnterSE = audioSources [1];
		ExitSE = audioSources [2];
	}

	public void Enter()
	{
		EnterSE.PlayOneShot (EnterSE.clip);
	}

	public void Exit()
	{
		ExitSE.PlayOneShot (ExitSE.clip);
	}

	public void GameEnter()
	{
		EnterSE.PlayOneShot (EnterSE.clip);
		Destroy (TitleBGM);
	}
}
