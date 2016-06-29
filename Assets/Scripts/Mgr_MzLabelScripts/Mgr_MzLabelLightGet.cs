using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzLabelLightGet : MonoBehaviour {

    [SerializeField]
    private Text lightGetLabel;

    void Start() {
        lightGetLabel.text = "";
    }

    public void AppearLabelEvent(object o, EventArgs e) {
        lightGetLabel.text = "ライト取得";
    }

    public void HideLabelEvent(object o, EventArgs e) {
        lightGetLabel.text = "";
    }
}