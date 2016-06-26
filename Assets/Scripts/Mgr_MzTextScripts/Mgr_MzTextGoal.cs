using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_MzTextGoal : MonoBehaviour {

    [SerializeField]
    private Text mzGoalText;

    void Start() {
        mzGoalText.text = "";
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