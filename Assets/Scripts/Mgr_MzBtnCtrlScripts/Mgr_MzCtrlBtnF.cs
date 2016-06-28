using System;
using UnityEngine;

public class Mgr_MzCtrlBtnF : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlF;

    void Start() {
        buttonCtrlF.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlF.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlF.gameObject.SetActive(false);
    }

    public void OnButtonCtrlFClicked() {
    }
}