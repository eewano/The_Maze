using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerMzText : MonoBehaviour {

    [SerializeField]
    private Text mzIntroText;

    void Start() {
        mzIntroText.text = "";
    }

    public void TextAppearEvent(object o, EventArgs e) {
        if (SceneManager.GetActiveScene().name == "Maze00") {
            mzIntroText.text = "0面はチュートリアルです。\nここでは各基本アイテムの効果を説明していきます。\n" +
            "制限時間内にすべてのアイテムを取得した後、\nゴールを目指して下さい。\n\n画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze01") {
            mzIntroText.text = "1面は、単純な迷路です。\n制限時間内に出口を目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze02") {
            mzIntroText.text = "2面はロボットが襲ってきます。\n捕まると30秒間気絶させられ、スタート地点に\n" +
            "戻されるので、上手く逃げ回りつつゴールを\n目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze03") {
            mzIntroText.text = "3面はクリアするのに鍵のアイテムが\n必要になります。\n" +
            "様々な仕掛けをくぐり抜け、\n鍵を探し出してゴールを目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
    }

    public void TextHideEvent(object o, EventArgs e) {
        mzIntroText.text = "";
    }
}