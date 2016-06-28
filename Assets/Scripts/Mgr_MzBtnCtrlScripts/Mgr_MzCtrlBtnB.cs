using System;
using UnityEngine;

public class Mgr_MzCtrlBtnB : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlB;

    void Start() {
        buttonCtrlB.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlB.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlB.gameObject.SetActive(false);
    }

    public void OnButtonCtrlBClicked() {
    }
}