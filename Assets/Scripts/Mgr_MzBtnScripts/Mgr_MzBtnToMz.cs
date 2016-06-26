using System;
using UnityEngine;

public class Mgr_MzBtnToMz : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz;

    void Start() {
        buttonToMz.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz.gameObject.SetActive(false);
    }
}