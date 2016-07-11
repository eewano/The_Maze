using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzTextGiveUp : MonoBehaviour {

    private Text mzGiveUpText;

    void Awake() {
        mzGiveUpText = GameObject.Find("MzTextMain").GetComponent<Text>();
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mzGiveUpText.fontSize = 48;
        mzGiveUpText.color = new Color32(255, 128, 0, 255);
        mzGiveUpText.text = "本当にギブアップ\nしますか？";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzGiveUpText.text = "";
    }
}