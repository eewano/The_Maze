using System;
using UnityEngine;

public class Mgr_MzBtnMap : MonoBehaviour {

    [SerializeField]
    private GameObject buttonMap;
    private ManagerMzMaster managerMzMaster;
    private Mgr_GameSE01 mgrMzSE01;
    private Mgr_PlayerBtnCtrl mgrPlayerBtnCtrl;

    private bool valid = true;

    private event EveHandMoveState toMAPState;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        mgrPlayerBtnCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnCtrl>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMAPState += new EveHandMoveState(managerMzMaster.ToMAPState);
        toMAPState += new EveHandMoveState(mgrPlayerBtnCtrl.BtnCtrlChangeToKey);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);

        buttonMap.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonMap.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonMap.gameObject.SetActive(false);
    }

    public void OnButtonMapClicked() {
        if (valid == true)
        {
            this.playSE(this, EventArgs.Empty);
            this.toMAPState(this, EventArgs.Empty);
        }
    }

    public void ButtonValidOFF(object o, EventArgs e) {
        valid = false;
    }

    public void ButtonValidON(object o, EventArgs e) {
        valid = true;
    }
}