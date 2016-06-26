using System;
using UnityEngine;

public class Mgr_MzBtnRestart : MonoBehaviour {

    [SerializeField]
    private GameObject buttonRestart;

    void Start() {
        buttonRestart.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonRestart.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonRestart.gameObject.SetActive(false);
    }
}