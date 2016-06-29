using System;
using UnityEngine;

public class Mgr_MzBtnCtrlB : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlB;

    void Start() {
        buttonCtrlB.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlB.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlB.gameObject.SetActive(false);
    }

    public void OnButtonCtrlBClicked() {
    }
}