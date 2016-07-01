using System;
using UnityEngine;

public class Mgr_TitleBtnExplain : MonoBehaviour {

    [SerializeField]
    private GameObject buttonExplain;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandMoveState toEXPLAINState;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toEXPLAINState += new EveHandMoveState(managerTitleMaster.ToEXPLAINState);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);

        buttonExplain.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonExplain.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonExplain.gameObject.SetActive(false);
    }

    public void OnButtonExplainClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toEXPLAINState(this, EventArgs.Empty);
    }
}