using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MzTimer : MonoBehaviour {

	[SerializeField] int timeLimit = 90;

	//制限時間
	private float timeRemaining;
	//タイマー動作のフラグ
	private bool timerStarted;

	void Start()
	{
		ResetTimer ();
	}

	//タイマーをリセットする
	public void ResetTimer()
	{
		timeRemaining = timeLimit;
		timerStarted = false;
	}

	//タイマーを開始する
	public void StartTimer()
	{
		timerStarted = true;
	}

	//タイマーを停止する
	public void StopTimer()
	{
		timerStarted = false;
	}

	//残り時間を取得する
	public float GetTimeRemaining()
	{
		return timeRemaining;
	}

	void Update()
	{
		if (timerStarted) {
			//残り時間を1秒ずつ引いていく
			timeRemaining -= Time.deltaTime;
			//残り時間が0以下になったらタイマーを停止する
			if (timeRemaining <= 0) {
				timeRemaining = 0;
				timerStarted = false;
			}
		}

		//残り時間のテキストを更新する
		GetComponent<Text>().text  = "残り時間 : " +  (int)timeRemaining + " 秒";
	}
}