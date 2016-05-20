using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MzTimer : MonoBehaviour {

    private bool timerStarted;    //タイマー動作のフラグ

    [SerializeField]
    private int timeLimit;

    private float timeRemaining;    //制限時間
    private float countDown = 0;
    private Text timerText;
    private MzSoundEffect mzSoundEffect;

    void Start() {
        timerText = GetComponent<Text>();
        mzSoundEffect = GameObject.Find("MzSoundEffect").
        GetComponent<MzSoundEffect>();
        ResetTimer();
    }

    void Update() {
        if (timerStarted) {
            //残り時間を1秒ずつ引いていく
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 10) {
                timerText.color = Color.red;
                timerText.fontStyle = FontStyle.Bold;
                if (timeRemaining <= 5) {
                    CountDown();
                }
            }
            //残り時間が0以下になったらタイマーを停止する
            if (timeRemaining <= 0) {
                timeRemaining = 0;
                timerStarted = false;
            }
        }

        //残り時間のテキストを更新する
        timerText.text = "残り時間 : " + (int)timeRemaining + " 秒";
    }

    //タイマーをリセットする
    public void ResetTimer() {
        timeRemaining = timeLimit;
        timerStarted = false;
    }

    //タイマーを開始する
    public void StartTimer() {
        timerStarted = true;
    }

    //残り時間を取得する
    public float GetTimeRemaining() {
        return timeRemaining;
    }

    //タイマーを停止する
    public void StopTimer() {
        timerStarted = false;
    }

    public void EnemyTouchTimer() {
        timeRemaining -= 30;
    }

    void CountDown() {
        countDown -= Time.deltaTime;
        if (countDown <= 0.0) {
            mzSoundEffect.CountDownSound();
            countDown = 1.0f;
        }
    }
}