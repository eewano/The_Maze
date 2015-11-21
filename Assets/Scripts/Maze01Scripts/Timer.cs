using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public int timeLimit = 90;

	private float timeRemaining = 0;

	private bool timerStarted;

	void Start()
	{
		ResetTimer ();
	}

	public void ResetTimer()
	{
		timeRemaining = timeLimit;
		timerStarted = false;
	}

	public void StartTimer()
	{
		timerStarted = true;
	}

	public void StopTimer()
	{
		timerStarted = false;
	}

	public float GetTimeRemaining()
	{
		return timeRemaining;
	}

	void Update()
	{
		if (timerStarted) {
			timeRemaining -= Time.deltaTime;
			if (timeRemaining <= 0) {
				timeRemaining = 0;
				timerStarted = false;
			}
		}

		//int Seisuu = CeilToInt(timeRemaining);

		GetComponent<Text>().text  = "残り時間 : " +  (int)timeRemaining + " 秒";
	}
}