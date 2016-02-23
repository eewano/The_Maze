using UnityEngine;
using System.Collections;

public class MzSoundEffect : MonoBehaviour {

	private AudioSource
		readyGoSE,
		enterSE,
		exitSE,
		lightBallSE,
		croquetteSE,
		mapCrystalSE,
		shutterSE,
		timeUpSE,
		goalSE,
		enemyTouchSE,
		countDownSE;

	void Awake()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		readyGoSE = audioSources [0];
		enterSE = audioSources [1];
		exitSE = audioSources [2];
		lightBallSE = audioSources [3];
		croquetteSE = audioSources [4];
		mapCrystalSE = audioSources [5];
		shutterSE = audioSources [6];
		timeUpSE = audioSources [7];
		goalSE = audioSources [8];
		enemyTouchSE = audioSources [9];
		countDownSE = audioSources [10];
	}

	public void ReadyGoSound() {
		readyGoSE.PlayOneShot (readyGoSE.clip);
	}

	public void EnterSound() {
		enterSE.PlayOneShot (enterSE.clip);
	}

	public void ExitSound() {
		exitSE.PlayOneShot (exitSE.clip);
	}

	public void LightBallSound() {
		lightBallSE.PlayOneShot (lightBallSE.clip);
	}

	public void CroquetteSound() {
		croquetteSE.PlayOneShot (croquetteSE.clip);
	}

	public void MapCrystalSound() {
		mapCrystalSE.PlayOneShot (mapCrystalSE.clip);
	}

	public void ShutterSound() {
		shutterSE.PlayOneShot (shutterSE.clip);
	}

	public void TimeUpSound() {
		timeUpSE.PlayOneShot (timeUpSE.clip);
	}

	public void GoalSound() {
		goalSE.PlayOneShot (goalSE.clip);
	}

	public void EnemyTouchSound() {
		enemyTouchSE.PlayOneShot (enemyTouchSE.clip);
	}

	public void CountDownSound() {
		countDownSE.PlayOneShot (countDownSE.clip);
	}
}