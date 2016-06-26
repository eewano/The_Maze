using System;
using UnityEngine;

public class Mgr_MzBtnGiveUp : MonoBehaviour {

    [SerializeField]
    private GameObject buttonGiveUp;

    void Start() {
        buttonGiveUp.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonGiveUp.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonGiveUp.gameObject.SetActive(false);
    }
}