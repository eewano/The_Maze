using System;
using UnityEngine;

public class Mgr_MzBtnCancel : MonoBehaviour {

    [SerializeField]
    private GameObject buttonCancel;
    private ManagerMzMaster managerMzMaster;
    private Mgr_GameSE01 mgrMzSE01;
    private Mgr_PlayerBtnCtrl mgrPlayerBtnCtrl;

    private event EveHandMoveState toPLAYINGState;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        mgrPlayerBtnCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnCtrl>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toPLAYINGState += new EveHandMoveState(managerMzMaster.ToPLAYINGState);
        toPLAYINGState += new EveHandMoveState(mgrPlayerBtnCtrl.BtnCtrlChangeToBtn);
        playSE += new EveHandPLAYSE(mgrMzSE01.SECancelEvent);

        buttonCancel.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonCancel.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonCancel.gameObject.SetActive(false);
    }

    public void OnButtonCancelClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toPLAYINGState(this, EventArgs.Empty);
    }
}