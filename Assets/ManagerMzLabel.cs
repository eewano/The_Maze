using System;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMzLabel : MonoBehaviour {

    [SerializeField]
    private Text lightGetLabel;
    [SerializeField]
    private Text croquetteGetLabel;

    void Start() {
        lightGetLabel.text = "";
        croquetteGetLabel.text = "";
    }

    public void LightBallGetEvent(object o, EventArgs e) {
        lightGetLabel.text = "ライト : OK";
    }

    public void CroquetteGetEvent(object o, EventArgs e) {
        croquetteGetLabel.text = "コロッケ : OK";
    }
}