using System;
using UnityEngine;

public class Mgr_MzBtnRestart : MonoBehaviour {

    [SerializeField]
    private GameObject buttonRestart;
    private ManagerMzMaster managerMzMaster;
    private Manager_MzButton managerMzButton;
    private Manager_MzText managerMzText;
    private Mgr_MzTextTimer mgrMzTextTimer;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandMoveState toRestartOrder;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        managerMzButton = GameObject.Find("Mgr_MzButton").GetComponent<Manager_MzButton>();
        managerMzText = GameObject.Find("Mgr_MzText").GetComponent<Manager_MzText>();
        mgrMzTextTimer = GameObject.Find("Mgr_MzTimer").GetComponent<Mgr_MzTextTimer>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toRestartOrder += new EveHandMoveState(managerMzMaster.RestartIMethod);
        toRestartOrder += new EveHandMoveState(managerMzButton.EventOTHER);
        toRestartOrder += new EveHandMoveState(managerMzText.EventOTHER);
        toRestartOrder += new EveHandMoveState(mgrMzTextTimer.HideTextEvent);

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