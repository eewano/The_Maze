using System;
using UnityEngine;

public class Mgr_MzBtnCtrlL : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlL;

    void Start() {
        buttonCtrlL.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlL.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlL.gameObject.SetActive(false);
    }

    public void OnButtonCtrlLClicked() {
    }
}