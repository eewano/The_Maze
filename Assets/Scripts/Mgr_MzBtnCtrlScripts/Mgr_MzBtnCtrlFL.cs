using System;
using UnityEngine;

public class Mgr_MzBtnCtrlFL : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlFL;

    void Start() {
        buttonCtrlFL.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlFL.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlFL.gameObject.SetActive(false);
    }

    public void OnButtonCtrlFLClicked() {
    }
}