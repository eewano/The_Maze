using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_TitleTextExplain02 : MonoBehaviour {

    [SerializeField]
    private Text explainText02;

    void Start() {
        explainText02.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        explainText02.fontSize = 28;
        explainText02.color = new Color32(255, 255, 155, 255);
        explainText02.text = "　恐れを知らないスケルトンが、様々な仕掛けのある迷路を探索するゲームです。" +
        "コントローラーボタンを駆使して制限時間内に迷路から脱出出来たらクリアとなります。\n" +
        "　尚、迷路によってルールが異なる他、様々なアイテムや仕掛けもありますので、各迷路のスタート画面の説明を" +
        "良く読んでから遊んで下さい。まずは0面からプレイする事を薦めます。";
    }

    public void HideTextEvent(object o, EventArgs e) {
        explainText02.text = "";
    }
}