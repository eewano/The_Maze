using System;
using UnityEngine;

public class Mgr_MzBtnMap : MonoBehaviour {

    [SerializeField]
    private GameObject buttonMap;

    void Start() {
        buttonMap.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonMap.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonMap.gameObject.SetActive(false);
    }
}