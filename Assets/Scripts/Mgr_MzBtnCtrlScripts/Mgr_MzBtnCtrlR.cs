using System;
using UnityEngine;

public class Mgr_MzBtnCtrlR : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlR;

    void Start() {
        buttonCtrlR.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlR.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlR.gameObject.SetActive(false);
    }

    public void OnButtonCtrlRClicked() {
    }
}