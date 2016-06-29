using System;
using UnityEngine;

public class Mgr_MzBtnCtrlBR : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlBR;

    void Start() {
        buttonCtrlBR.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlBR.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlBR.gameObject.SetActive(false);
    }

    public void OnButtonCtrlBRClicked() {
    }
}