using System;
using UnityEngine;

public class Mgr_MzBtnCtrlFR : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlFR;

    void Start() {
        buttonCtrlFR.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlFR.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlFR.gameObject.SetActive(false);
    }

    public void OnButtonCtrlFRClicked() {
    }
}