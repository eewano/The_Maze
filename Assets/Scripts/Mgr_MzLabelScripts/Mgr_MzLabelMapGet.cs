using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzLabelMapGet : MonoBehaviour {

    [SerializeField]
    private Text mapGetLabel;

    void Start() {
        mapGetLabel.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        mapGetLabel.text = "マップ取得";
    }

    public void HideTextEvent(object o, EventArgs e) {
        mapGetLabel.text = "";
    }
}