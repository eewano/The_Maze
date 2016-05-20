﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mz00Manager : MonoBehaviour {

    public static bool Mz00Goal = false;

    private bool FirstMapFlag;
    private bool FirstCroqFlag;
    private bool FirstLightFlag;
    private bool AllItemGet;

    private Text tutorialLabel;

    [SerializeField]
    private Image tutorialImage;

    void Start() {
        tutorialLabel = GameObject.Find("TutorialLabel").GetComponent<Text>();
        tutorialImage.gameObject.SetActive(false);

        FirstMapFlag = false;
        FirstCroqFlag = false;
        FirstLightFlag = false;
        AllItemGet = false;
    }

    void Update() {
        if (FirstMapFlag == true &&
        FirstCroqFlag == true &&
        FirstLightFlag == true &&
        AllItemGet == true)
        {
            tutorialImage.gameObject.SetActive(true);
            tutorialLabel.text = "これですべてのアイテムが\n取り終わりました。\n\n" +
            "ゴールまで目指して下さい。";
            Time.timeScale = 0.0f;
            if (Input.GetMouseButtonDown(0)) {
                Time.timeScale = 1.0f;
                tutorialImage.gameObject.SetActive(false);
                Mz00Goal = true;
                AllItemGet = false;
            }
        }

        if (GameManager.MapCrystal == true && FirstMapFlag == false) {
            tutorialImage.gameObject.SetActive(true);
            tutorialLabel.text = "< マップ表示クリスタル >\n\n迷路の全体を表示し確認する事が\n" +
            "出来る様になります。\nマップ画面を見たい場合は、画面左下の\n「全体マップ」を押して" +
            "切り替えて下さい。\n\n※画面クリックで戻ります。";
            Time.timeScale = 0.0f;
            if (Input.GetMouseButtonDown(0)) {
                Time.timeScale = 1.0f;
                tutorialImage.gameObject.SetActive(false);
                FirstMapFlag = true;
                AllItemGet = true;
            }
        }

        if (GameManager.Croquette == true && FirstCroqFlag == false) {
            tutorialImage.gameObject.SetActive(true);
            tutorialLabel.text = "< カレーコロッケ >\n\nスケルトンが覚醒し、移動及び\n" +
            "旋回スピードがアップします。\n\n※画面クリックで戻ります。";
            Time.timeScale = 0.0f;
            if (Input.GetMouseButtonDown(0)) {
                Time.timeScale = 1.0f;
                tutorialImage.gameObject.SetActive(false);
                FirstCroqFlag = true;
                AllItemGet = true;
            }
        }

        if (GameManager.Light == true && FirstLightFlag == false) {
            tutorialImage.gameObject.SetActive(true);
            tutorialLabel.text = "< 照明 >\n\n迷路全体の照明が点灯し、\n" +
            "迷路内がより明るく見える様になります。\n\n※画面クリックで戻ります。";
            Time.timeScale = 0.0f;
            if (Input.GetMouseButtonDown(0)) {
                Time.timeScale = 1.0f;
                tutorialImage.gameObject.SetActive(false);
                FirstLightFlag = true;
                AllItemGet = true;
            }
        }
    }
}