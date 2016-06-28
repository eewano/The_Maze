using System;
using UnityEngine;

public class Mgr_MzCtrlBtnBL : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlBL;

    void Start() {
        buttonCtrlBL.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlBL.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlBL.gameObject.SetActive(false);
    }

    public void OnButtonCtrlBLClicked() {
    }
}