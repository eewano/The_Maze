using System;
using UnityEngine;

public class Mgr_MzCtrlBtnFR : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlFR;

    void Start() {
        buttonCtrlFR.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlFR.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlFR.gameObject.SetActive(false);
    }

    public void OnButtonCtrlFRClicked() {
    }
}