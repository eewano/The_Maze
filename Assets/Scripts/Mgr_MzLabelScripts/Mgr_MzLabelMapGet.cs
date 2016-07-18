using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzLabelMapGet : MonoBehaviour {

    [SerializeField]
    private Text mapGetLabel;

    void Start() {
        mapGetLabel.text = "";
    }

    public void AppearLabelEvent(object o, EventArgs e) {
        mapGetLabel.text = "マップOK";
    }

    public void HideLabelEvent(object o, EventArgs e) {
        mapGetLabel.text = "";
    }
}