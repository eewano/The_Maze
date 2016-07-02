using System;
using UnityEngine;

public class Mgr_MzBtnToTitle : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToTitle;
    private ManagerMzMaster managerMzMaster;
    private Manager_MzButton managerMzButton;
    private Manager_MzText managerMzText;
    private Mgr_MzTextTimer mgrMzTextTimer;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandMoveState toTitleOrder;

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
        toTitleOrder += new EveHandMoveState(managerMzMaster.ToTitleIMethod);
        toTitleOrder += new EveHandMoveState(managerMzButton.EventOTHER);
        toTitleOrder += new EveHandMoveState(managerMzText.EventOTHER);
        toTitleOrder += new EveHandMoveState(mgrMzTextTimer.HideTextEvent);

        buttonToTitle.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToTitle.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToTitle.gameObject.SetActive(false);
    }

    public void OnButtonToTitleClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toTitleOrder(this, EventArgs.Empty);
    }
}