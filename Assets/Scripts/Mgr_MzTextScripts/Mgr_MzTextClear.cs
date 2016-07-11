using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_MzTextClear : MonoBehaviour {

    private Text mzClearText;

    void Awake() {
        mzClearText = GameObject.Find("MzTextMain").GetComponent<Text>();
    }

    public void AppearTextEvent(object o, EventArgs e) {
        if (SceneManager.GetActiveScene().name == "Maze00") {
            mzClearText.fontSize = 60;
            mzClearText.color = new Color32(255, 255, 0, 255);
            mzClearText.text = "0 面 クリア !\nさあ次からが本格的な\n" +
            "迷路探索の始まりです !";
        }
        else if (SceneManager.GetActiveScene().name == "Maze01") {
            mzClearText.fontSize = 100;
            mzClearText.color = new Color32(255, 255, 0, 255);
            mzClearText.text = "1 面\nクリア !";
        }
        else if (SceneManager.GetActiveScene().name == "Maze02") {
            mzClearText.fontSize = 100;
            mzClearText.color = new Color32(255, 255, 0, 255);
            mzClearText.text = "2 面\nクリア !";
        }
        else if (SceneManager.GetActiveScene().name == "Maze03") {
            mzClearText.fontSize = 100;
            mzClearText.color = new Color32(255, 255, 0, 255);
            mzClearText.text = "3 面\nクリア !";
        }
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzClearText.text = "";
    }
}