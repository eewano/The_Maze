using System;
using UnityEngine;

public class Mgr_MzCtrlBtnR : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlR;

    void Start() {
        buttonCtrlR.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlR.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlR.gameObject.SetActive(false);
    }

    public void OnButtonCtrlRClicked() {
    }
}