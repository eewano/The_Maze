using System;
using UnityEngine;

public class Mgr_MzBtnRestart : MonoBehaviour {

    [SerializeField]
    private GameObject buttonRestart;
    private ManagerMzMaster managerMzMaster;
    private Mgr_MzSE01 mgrMzSE01;

    private event EveHandMoveState toRestartOrder;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_MzSE01").GetComponent<Mgr_MzSE01>();
    }

    void Start() {
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toRestartOrder += new EveHandMoveState(managerMzMaster.RestartIMethod);

        buttonRestart.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonRestart.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonRestart.gameObject.SetActive(false);
    }

    public void OnButtonRestartClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toRestartOrder(this, EventArgs.Empty);
    }
}