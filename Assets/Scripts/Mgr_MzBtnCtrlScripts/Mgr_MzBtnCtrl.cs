using System;
using UnityEngine;

public class Mgr_MzBtnCtrl : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCtrlF;
    [SerializeField]
    private GameObject buttonCtrlB;
    [SerializeField]
    private GameObject buttonCtrlL;
    [SerializeField]
    private GameObject buttonCtrlR;
    [SerializeField]
    private GameObject buttonCtrlFL;
    [SerializeField]
    private GameObject buttonCtrlFR;
    [SerializeField]
    private GameObject buttonCtrlBL;
    [SerializeField]
    private GameObject buttonCtrlBR;

    void Start() {
        buttonCtrlF.gameObject.SetActive(false);
        buttonCtrlB.gameObject.SetActive(false);
        buttonCtrlL.gameObject.SetActive(false);
        buttonCtrlR.gameObject.SetActive(false);
        buttonCtrlFL.gameObject.SetActive(false);
        buttonCtrlFR.gameObject.SetActive(false);
        buttonCtrlBL.gameObject.SetActive(false);
        buttonCtrlBR.gameObject.SetActive(false);
    }

    public void AppearBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlF.gameObject.SetActive(true);
        buttonCtrlB.gameObject.SetActive(true);
        buttonCtrlL.gameObject.SetActive(true);
        buttonCtrlR.gameObject.SetActive(true);
        buttonCtrlFL.gameObject.SetActive(true);
        buttonCtrlFR.gameObject.SetActive(true);
        buttonCtrlBL.gameObject.SetActive(true);
        buttonCtrlBR.gameObject.SetActive(true);
    }

    public void HideBtnCtrlEvent(object o, EventArgs e) {
        buttonCtrlF.gameObject.SetActive(false);
        buttonCtrlB.gameObject.SetActive(false);
        buttonCtrlL.gameObject.SetActive(false);
        buttonCtrlR.gameObject.SetActive(false);
        buttonCtrlFL.gameObject.SetActive(false);
        buttonCtrlFR.gameObject.SetActive(false);
        buttonCtrlBL.gameObject.SetActive(false);
        buttonCtrlBR.gameObject.SetActive(false);
    }
}