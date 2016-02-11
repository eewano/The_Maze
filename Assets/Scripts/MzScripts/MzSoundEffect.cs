using UnityEngine;
using System.Collections;

public class MzSoundEffect : MonoBehaviour {

	private AudioSource ReadyGoSE;
	private AudioSource EnterSE;
	private AudioSource ExitSE;
	private AudioSource LightBallSE;
	private AudioSource CroquetteSE;
	private AudioSource MapCrystalSE;
	private AudioSource ShutterSE;
	private AudioSource TimeUpSE;
	private AudioSource GoalSE;
	private AudioSource EnemyTouchSE;

	void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		ReadyGoSE = audioSources [0];
		EnterSE = audioSources [1];
		ExitSE = audioSources [2];
		LightBallSE = audioSources [3];
		CroquetteSE = audioSources [4];
		MapCrystalSE = audioSources [5];
		ShutterSE = audioSources [6];
		TimeUpSE = audioSources [7];
		GoalSE = audioSources [8];
		EnemyTouchSE = audioSources [9];
	}

	public void ReadyGoSound() {
		ReadyGoSE.PlayOneShot (ReadyGoSE.clip);
	}

	public void EnterSound() {
		EnterSE.PlayOneShot (EnterSE.clip);
	}

	public void ExitSound() {
		ExitSE.PlayOneShot (ExitSE.clip);
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

	public void ShutterSound() {
		ShutterSE.PlayOneShot (ShutterSE.clip);
	}

	public void TimeUpSound() {
		TimeUpSE.PlayOneShot (TimeUpSE.clip);
	}

	public void GoalSound() {
		GoalSE.PlayOneShot (GoalSE.clip);
	}

	public void EnemyTouchSound() {
		EnemyTouchSE.PlayOneShot (EnemyTouchSE.clip);
	}
}