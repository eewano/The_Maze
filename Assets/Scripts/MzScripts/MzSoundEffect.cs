using UnityEngine;
using System.Collections;

public class MzSoundEffect : MonoBehaviour {
	
	private AudioSource GoalSE;
	private AudioSource EnterSE;
	private AudioSource ExitSE;
	private AudioSource ReadyGoSE;
	private AudioSource TimeUpSE;
	private AudioSource LightBallSE;
	private AudioSource CroquetteSE;
	private AudioSource MapCrystalSE;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		ReadyGoSE = audioSources [0];
		EnterSE = audioSources [1];
		ExitSE = audioSources [2];
		LightBallSE = audioSources [3];
		CroquetteSE = audioSources [4];
		MapCrystalSE = audioSources [5];
		TimeUpSE = audioSources [6];
		GoalSE = audioSources [7];
	}

	public void EnterSound() {
		EnterSE.PlayOneShot (EnterSE.clip);
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
	}

	public void LightBallSound() {
		LightBallSE.PlayOneShot (LightBallSE.clip);
	}

	public void CroquetteSound() {
		CroquetteSE.PlayOneShot (CroquetteSE.clip);
	}

	public void MapCrystalSound() {
		MapCrystalSE.PlayOneShot (MapCrystalSE.clip);
	}
}