using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzTextTimer : MonoBehaviour {

    private ManagerMzMaster managerMzMaster;
    private ManagerPlayerMaster managerPlayerMaster;
    private Mgr_GameSE01 mgrGameSE01;

    [SerializeField]
    private Text mzTimerText;
    [SerializeField]
    private int timeLimit;
    private float timeRemaining; //制限時間
    private float countDown = 0;

    private bool timerStarted;

    private event EveHandPLAYSE countDownSE;

    private event EveHandMoveState toTIMEUPState;

    private event EveHandToPlayer playerCtrlOff;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        mgrGameSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        countDownSE += new EveHandPLAYSE(mgrGameSE01.SECountDownEvent);
        toTIMEUPState += new EveHandMoveState(managerMzMaster.ToTIMEUPState);
        playerCtrlOff += new EveHandToPlayer(managerPlayerMaster.PlayerCtrlOff);
        ResetTimer();
        mzTimerText.text = "";
        timerStarted = false;
    }

    void Update() {
        if (timerStarted == true) {
            //残り時間を1秒ずつ引いていく
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 10) {
                mzTimerText.fontStyle = FontStyle.Bold;
                mzTimerText.color = new Color32(255, 0, 0, 255);
                if (timeRemaining <= 5) {
                    CountDown();
                }
            }
            //残り時間が0以下になったらタイマーを停止する
            if (timeRemaining <= 0) {
                timeRemaining = 0;
                this.toTIMEUPState(this, EventArgs.Empty);
                this.playerCtrlOff(this, EventArgs.Empty);
                timerStarted = false;
            }

            //残り時間のテキストを更新する
            mzTimerText.text = "残り時間 : " + (int)timeRemaining + " 秒";
        }
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mzTimerText.fontSize = 32;
        mzTimerText.color = new Color32(255, 255, 255, 255);
        mzTimerText.text = "残り時間 : " + (int)timeRemaining + " 秒";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzTimerText.text = "";
    }

    public void MzTimerStart(object o, EventArgs e) {
        timerStarted = true;
    }

    public void MzTimerStop(object o, EventArgs e) {
        timerStarted = false;
    }

    public void MzTimerCountValue(object o, int i) {
        timeRemaining += i;
    }

    void ResetTimer() {
        timeRemaining = timeLimit;
        timerStarted = false;
    }

    void CountDown() {
        countDown -= Time.deltaTime;
        if (countDown <= 0.0) {
            this.countDownSE(this, EventArgs.Empty);
            countDown = 1.0f;
        }
    }
}