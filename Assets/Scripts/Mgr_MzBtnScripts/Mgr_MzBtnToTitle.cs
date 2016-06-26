using System;
using UnityEngine;

public class Mgr_MzBtnToTitle : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToTitle;

    void Start() {
        buttonToTitle.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToTitle.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToTitle.gameObject.SetActive(false);
    }
}