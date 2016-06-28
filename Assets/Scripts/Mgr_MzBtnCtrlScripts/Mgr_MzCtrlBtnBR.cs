using System;
using UnityEngine;

public class Mgr_MzCtrlBtnBR : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlBR;

    void Start() {
        buttonCtrlBR.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlBR.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlBR.gameObject.SetActive(false);
    }

    public void OnButtonCtrlBRClicked() {
    }
}