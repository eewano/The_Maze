using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_TitleTextMain01 : MonoBehaviour {

    [SerializeField]
    private Text mainText01;

    void Start() {
        mainText01.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mainText01.fontSize = 120;
        mainText01.color = new Color32(255, 255, 0, 255);
        mainText01.text = "The Maze";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mainText01.text = "";
    }
}