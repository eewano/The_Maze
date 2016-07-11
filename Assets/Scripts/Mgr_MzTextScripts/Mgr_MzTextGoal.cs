using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzTextGoal : MonoBehaviour {

    private Text mzGoalText;

    void Awake() {
        mzGoalText = GameObject.Find("MzTextMain").GetComponent<Text>();
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mzGoalText.fontSize = 100;
        mzGoalText.color = new Color32(255, 255, 0, 255);
        mzGoalText.text = "GOAL！";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzGoalText.text = "";
    }
}