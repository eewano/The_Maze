using System;
using UnityEngine;

public class Mgr_TitleBtnToMain : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMain;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandMoveState toMAINState;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMAINState += new EveHandMoveState(managerTitleMaster.ToMAINState);
        playSE += new EveHandPLAYSE(mgrMzSE01.SECancelEvent);

        buttonToMain.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMain.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMain.gameObject.SetActive(false);
    }

    public void OnButtonToMainClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toMAINState(this, EventArgs.Empty);
    }
}