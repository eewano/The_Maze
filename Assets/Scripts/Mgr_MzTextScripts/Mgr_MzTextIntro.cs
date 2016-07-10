﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_MzTextIntro : MonoBehaviour {

    private Text mzIntroText;
    private Outline mzIntroOutLine;

    void Awake() {
        mzIntroText = GameObject.Find("MzTextMain").GetComponent<Text>();
        mzIntroOutLine = GameObject.Find("MzTextMain").GetComponent<Outline>();
    }

    void Start() {
        mzIntroText.fontSize = 32;
        mzIntroText.color = new Color32(255, 255, 255, 255);
        mzIntroOutLine.effectDistance = new Vector2(2, -2);
        mzIntroOutLine.enabled = false;
    }

    public void AppearTextEvent(object o, EventArgs e) {
        if (SceneManager.GetActiveScene().name == "Maze00") {
            mzIntroOutLine.enabled = false;
            mzIntroText.text = "0面はチュートリアルです。\nここでは各基本アイテムの効果を説明していきます。\n" +
            "制限時間内にすべてのアイテムを取得した後、\nゴールを目指して下さい。\n\n画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze01") {
            mzIntroOutLine.enabled = false;
            mzIntroText.text = "1面は、単純な迷路です。\n制限時間内に出口を目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze02") {
            mzIntroOutLine.enabled = false;
            mzIntroText.text = "2面はロボットが襲ってきます。\n捕まると30秒間気絶させられ、スタート地点に\n" +
            "戻されるので、上手く逃げ回りつつゴールを\n目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
        else if (SceneManager.GetActiveScene().name == "Maze03") {
            mzIntroOutLine.enabled = true;
            mzIntroText.text = "3面はクリアするのに鍵のアイテムが\n必要になります。\n" +
            "様々な仕掛けをくぐり抜け、\n鍵を探し出してゴールを目指して下さい。\n\n" +
            "画面クリックでゲーム開始です。";
        }
    }

    public void HideTextEvent(object o, EventArgs e) {
        mzIntroText.text = "";
    }
}