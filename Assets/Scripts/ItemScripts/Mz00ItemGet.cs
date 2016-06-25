using System;
using UnityEngine;
using UnityEngine.UI;

public class Mz00ItemGet : MonoBehaviour {

    [SerializeField]
    private Text tutorialText;
    [SerializeField]
    private Image tutorialImage;

    void Start() {
        tutorialText.text = "";
        tutorialImage.gameObject.SetActive(false);
    }

    public void Mz00LightGetHandler(object o, EventArgs e) {
        tutorialImage.gameObject.SetActive(true);
        tutorialText.color = new Color32(255, 255, 255, 192);
        tutorialText.text = "< 照明 >\n\n" +
        "迷路全体の照明が点灯し、\n" +
        "迷路内がより明るく見える様になります。\n";
    }

    public void Mz00CroquetteGetHandler(object o, EventArgs e) {
        tutorialImage.gameObject.SetActive(true);
        tutorialImage.color = new Color32(255, 255, 255, 192);
        tutorialText.text = "< カレーコロッケ >\n\n" +
        "スケルトンが覚醒し、移動及び\n" +
        "旋回スピードがアップします。\n";
    }

    public void Mz00MapGetHandler(object o, EventArgs e) {
        tutorialImage.gameObject.SetActive(true);
        tutorialText.color = new Color32(255, 255, 255, 192);
        tutorialText.text = "< マップ表示クリスタル >\n\n" +
        "迷路の全体を表示し確認する事が\n" +
        "出来る様になります。\n" +
        "マップ画面を見たい場合は、画面左下の\n" +
        "「全体マップ」を押して切り替えて下さい。";
    }

    public void Mz00ClearFlagHandler(object o, EventArgs e) {
        tutorialImage.gameObject.SetActive(true);
        tutorialText.color = new Color32(255, 220, 255, 192);
        tutorialText.text = "これですべてのアイテムが\n" +
        "取り終わりました。\n" +
        "ゴールまで目指して下さい。";
    }

    public void ImageDeleteHandler(object o, EventArgs e) {
        tutorialText.text = "";
        tutorialImage.gameObject.SetActive(false);
    }
}