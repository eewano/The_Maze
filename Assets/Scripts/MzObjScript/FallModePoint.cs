using System;
using UnityEngine;

public class FallModePoint : MonoBehaviour {

    private Mgr_PlayerKeyCtrl mgrPlayerKeyCtrl;
    private Mgr_PlayerBtnCtrl mgrPlayerBtnCtrl;

    private event EveHandToPlayer playerCtrlOff;

    void Awake() {
        mgrPlayerKeyCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerKeyCtrl>();
        mgrPlayerBtnCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnCtrl>();
    }

    void Start() {
        playerCtrlOff += new EveHandToPlayer(mgrPlayerBtnCtrl.BtnCtrlChangeToKey);
        playerCtrlOff += new EveHandToPlayer(mgrPlayerKeyCtrl.KeyCtrlChangeToBtn);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            this.playerCtrlOff(this, EventArgs.Empty);
        }
    }
}