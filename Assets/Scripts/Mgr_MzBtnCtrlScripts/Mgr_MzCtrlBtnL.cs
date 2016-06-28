using System;
using UnityEngine;

public class Mgr_MzCtrlBtnL : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlL;

    void Start() {
        buttonCtrlL.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCtrlL.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCtrlL.gameObject.SetActive(false);
    }

    public void OnButtonCtrlLClicked() {
    }
}