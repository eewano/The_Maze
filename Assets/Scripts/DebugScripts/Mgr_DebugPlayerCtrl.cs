using System;
using UnityEngine;

public class Mgr_DebugPlayerCtrl : MonoBehaviour {

    private Mgr_PlayerBtnCtrl mgrPlayerBtnCtrl;
    private Mgr_PlayerKeyCtrl mgrPlayerKeyCtrl;

    private event EveHandDebug changeToCtrlBtn;

    private event EveHandDebug changeToCtrlKey;

    void Awake() {
        mgrPlayerBtnCtrl = GameObject.Find("Player").GetComponent<Mgr_PlayerBtnCtrl>();
        mgrPlayerKeyCtrl = GameObject.Find("Player").GetComponent<Mgr_PlayerKeyCtrl>();
    }

    void Start() {
        changeToCtrlBtn += new EveHandDebug(mgrPlayerBtnCtrl.CtrlChangeToBtn);
        changeToCtrlBtn += new EveHandDebug(mgrPlayerKeyCtrl.CtrlChangeToBtn);

        changeToCtrlKey += new EveHandDebug(mgrPlayerBtnCtrl.CtrlChangeToKey);
        changeToCtrlKey += new EveHandDebug(mgrPlayerKeyCtrl.CtrlChangeToKey);
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