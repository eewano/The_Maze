using System;
using UnityEngine;

public class Mgr_MzBtnCtrlBL : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlBL;

    void Start() {
        buttonCtrlBL.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlBL.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlBL.gameObject.SetActive(false);
    }

    public void OnButtonCtrlBLClicked() {
    }
}