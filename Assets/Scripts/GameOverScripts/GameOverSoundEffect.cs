using UnityEngine;
using System.Collections;

public class GameOverSoundEffect : MonoBehaviour {

	private AudioSource GameOverBGM;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		GameOverBGM = audioSources [0];
	}

	public void GameOverSound()
	{
		GameOverBGM.PlayOneShot (GameOverBGM.clip);
	}
}
