using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_MzTextReady : MonoBehaviour {

    private Text mzReadyText;

    void Awake() {
        mzReadyText = GameObject.Find("MzTextMain").GetComponent<Text>();
    }

    public void AppearTextEvent(object o, EventArgs e) {
        if (SceneManager.GetActiveScene().name == "Maze00") {
            mzReadyText.fontSize = 100;
            mzReadyText.color = new Color32(255, 255, 0, 255);
            mzReadyText.text = "0 面 スタート !";
        }
        else if (SceneManager.GetActiveScene().name == "Maze01") {
            mzReadyText.fontSize = 100;
            mzReadyText.color = new Color32(255, 255, 0, 255);
            mzReadyText.text = "1 面 スタート !";
        }
        else if (SceneManager.GetActiveScene().name == "Maze02") {
            mzReadyText.fontSize = 100;
            mzReadyText.color = new Color32(255, 255, 0, 255);
            mzReadyText.text = "2 面 スタート !";
        }
        else if (SceneManager.GetActiveScene().name == "Maze03") {
            mzReadyText.fontSize = 100;
            mzReadyText.color = new Color32(255, 255, 0, 255);
            mzReadyText.text = "3 面 スタート !";
        }
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzReadyText.text = "";
    }
}