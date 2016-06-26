using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzLabelLightGet : MonoBehaviour {

    [SerializeField]
    private Text lightGetLabel;

    void Start() {
        lightGetLabel.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        lightGetLabel.text = "ライト取得";
    }

    public void HideTextEvent(object o, EventArgs e) {
        lightGetLabel.text = "";
    }
}