using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzTextTimeUp : MonoBehaviour {

    private Text mzTimeUpText;

    void Awake() {
        mzTimeUpText = GameObject.Find("MzTextMain").GetComponent<Text>();
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mzTimeUpText.fontSize = 100;
        mzTimeUpText.color = new Color32(255, 64, 0, 255);
        mzTimeUpText.text = "時間切れ！";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzTimeUpText.text = "";
    }
}