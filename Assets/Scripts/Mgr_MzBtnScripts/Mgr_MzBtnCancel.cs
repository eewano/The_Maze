using System;
using UnityEngine;

public class Mgr_MzBtnCancel : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCancel;

    void Start() {
        buttonCancel.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCancel.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCancel.gameObject.SetActive(false);
    }
}