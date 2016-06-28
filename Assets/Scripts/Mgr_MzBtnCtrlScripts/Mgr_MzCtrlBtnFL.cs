using System;
using UnityEngine;

public class Mgr_MzCtrlBtnFL : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlFL;

    void Start() {
        buttonCtrlFL.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlFL.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlFL.gameObject.SetActive(false);
    }

    public void OnButtonCtrlFLClicked() {
    }
}