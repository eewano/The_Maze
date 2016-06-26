using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_MzTextFailure : MonoBehaviour {

    [SerializeField]
    private Text mzFailureText;

    void Start() {
        mzFailureText.text = "";
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