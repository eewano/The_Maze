using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzTextFailure : MonoBehaviour {

    private Text mzFailureText;

    void Awake() {
        mzFailureText = GameObject.Find("MzTextMain").GetComponent<Text>();
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mzFailureText.fontSize = 100;
        mzFailureText.color = new Color32(255, 0, 0, 255);
        mzFailureText.text = "脱出失敗！";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzFailureText.text = "";
    }
}