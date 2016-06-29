using System;
using UnityEngine;

public class Mgr_MzBtnCtrlF : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlF;

    void Start() {
        buttonCtrlF.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlF.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlF.gameObject.SetActive(false);
    }

    public void OnButtonCtrlFClicked() {
    }
}