using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerClearText : MonoBehaviour {

    [SerializeField]
    private Text mzClearText;

    void Start() {
        mzClearText.text = "";
    }

    public void TextAppearEvent(object o, EventArgs e) {
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

    public void TextHideEvent(object o, EventArgs e) {
        mzClearText.text = "";
    }
}