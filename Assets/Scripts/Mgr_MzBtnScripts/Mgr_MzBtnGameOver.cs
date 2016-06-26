using System;
using UnityEngine;

public class Mgr_MzBtnGameOver : MonoBehaviour {

    [SerializeField]
    private GameObject buttonGameOver;

    void Start() {
        buttonGameOver.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonGameOver.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonGameOver.gameObject.SetActive(false);
    }
}