using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_TitleTextExplain01 : MonoBehaviour {

    [SerializeField]
    private Text explainText01;

    void Start() {
        explainText01.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        explainText01.fontSize = 120;
        explainText01.color = new Color32(255, 255, 0, 255);
        explainText01.text = "ゲームの説明";
    }

    public void HideTextEvent(object o, EventArgs e) {
        explainText01.text = "";
    }
}