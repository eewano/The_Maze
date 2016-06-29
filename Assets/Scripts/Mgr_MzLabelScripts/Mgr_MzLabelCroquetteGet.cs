using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_MzLabelCroquetteGet : MonoBehaviour {

    [SerializeField]
    private Text croquetteLabel;

    void Start() {
        croquetteLabel.text = "";
    }

    public void AppearLabelEvent(object o, EventArgs e) {
        croquetteLabel.text = "コロッケ取得";
    }

    public void HideLabelEvent(object o, EventArgs e) {
        croquetteLabel.text = "";
    }
}