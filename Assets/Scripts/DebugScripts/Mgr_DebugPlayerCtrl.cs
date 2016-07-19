using System;
using UnityEngine;

public class Mgr_DebugPlayerCtrl : MonoBehaviour {

    private Mgr_PlayerBtnCtrl mgrPlayerBtnCtrl;
    private Mgr_PlayerKeyCtrl mgrPlayerKeyCtrl;

    private event EveHandDebug changeToCtrlBtn;

    private event EveHandDebug changeToCtrlKey;

    void Awake() {
        mgrPlayerBtnCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnCtrl>();
        mgrPlayerKeyCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerKeyCtrl>();
    }

    void Start() {
        changeToCtrlBtn += new EveHandDebug(mgrPlayerBtnCtrl.BtnCtrlChangeToBtn);
        changeToCtrlBtn += new EveHandDebug(mgrPlayerKeyCtrl.KeyCtrlChangeToBtn);

        changeToCtrlKey += new EveHandDebug(mgrPlayerBtnCtrl.BtnCtrlChangeToKey);
        changeToCtrlKey += new EveHandDebug(mgrPlayerKeyCtrl.KeyCtrlChangeToKey);
    }

    void Update() {
        if (Input.GetKeyUp("b")) {
            Debug.Log("CtrlBtn");
            this.changeToCtrlBtn(this, EventArgs.Empty);
        }
        else if (Input.GetKeyUp("k")) {
            Debug.Log("CtrlKey");
            this.changeToCtrlKey(this, EventArgs.Empty);
        }
    }
}