using System;
using UnityEngine;

public class ManagerMzButton : MonoBehaviour {

    [SerializeField]
    private GameObject buttonGiveUp;
    [SerializeField]
    private GameObject buttonCancel;
    [SerializeField]
    private GameObject buttonGameOver;
    [SerializeField]
    private GameObject buttonMap;
    [SerializeField]
    private GameObject buttonToMz;
    [SerializeField]
    private GameObject buttonRestart;
    [SerializeField]
    private GameObject buttonToNextMz;
    [SerializeField]
    private GameObject buttonToTitle;

    void Start() {
        AllFalse();
    }

    public void BtnREADY_AppearEvent(object o, EventArgs e) {
        AllFalse();
    }

    public void BtnREADYGO_AppearEvent(object o, EventArgs e) {
        AllFalse();
    }

    public void BtnPLAYING_AppearEvent(object o, EventArgs e) {
        AllFalse();
        buttonGiveUp.gameObject.SetActive(true);
    }

    public void BtnGIVEUP_AppearEvent(object o, EventArgs e) {
        AllFalse();
        buttonCancel.gameObject.SetActive(true);
        buttonGameOver.gameObject.SetActive(true);
    }

    public void BtnMAP_AppearEvent(object o, EventArgs e) {
        AllFalse();
        buttonToMz.gameObject.SetActive(true);
    }

    public void BtnTIMEUP_AppearEvent(object o, EventArgs e) {
        AllFalse();
    }

    public void BtnFAILURE_AppearEvent(object o, EventArgs e) {
        AllFalse();
        buttonGameOver.gameObject.SetActive(true);
        buttonRestart.gameObject.SetActive(true);
    }

    public void BtnGOAL_AppearEvent(object o, EventArgs e) {
        AllFalse();
    }

    public void BtnToNextMzAppearEvent(object o, EventArgs e) {
        AllFalse();
        buttonToNextMz.gameObject.SetActive(true);
    }

    public void BtnCLEAR_AppearEvent(object o, EventArgs e) {
        AllFalse();
        buttonToNextMz.gameObject.SetActive(true);
        buttonToTitle.gameObject.SetActive(true);
    }

    public void BtnHideEvent(object o, EventArgs e) {
        AllFalse();
    }

    void AllFalse() {
        buttonGiveUp.gameObject.SetActive(false);
        buttonCancel.gameObject.SetActive(false);
        buttonGameOver.gameObject.SetActive(false);
        buttonMap.gameObject.SetActive(false);
        buttonToMz.gameObject.SetActive(false);
        buttonRestart.gameObject.SetActive(false);
        buttonToNextMz.gameObject.SetActive(false);
        buttonToTitle.gameObject.SetActive(false);
    }
}