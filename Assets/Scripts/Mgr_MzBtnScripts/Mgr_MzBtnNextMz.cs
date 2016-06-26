using System;
using UnityEngine;

public class Mgr_MzBtnNextMz : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToNextMz;

    void Start() {
        buttonToNextMz.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToNextMz.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToNextMz.gameObject.SetActive(false);
    }
}