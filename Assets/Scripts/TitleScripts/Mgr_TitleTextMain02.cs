using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_TitleTextMain02 : MonoBehaviour {

    [SerializeField]
    private Text mainText02;

    void Start() {
        mainText02.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mainText02.fontSize = 60;
        mainText02.color = new Color32(255, 255, 0, 255);
        mainText02.text = "〜スケルトンの迷宮探索〜";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mainText02.text = "";
    }
}