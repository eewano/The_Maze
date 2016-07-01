using System;
using UnityEngine;

public class Mgr_MzBtnNextMz : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToNextMz;
    private ManagerMzMaster managerMzMaster;
    private Manager_MzButton managerMzButton;
    private Manager_MzText managerMzText;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandMoveState toNextMzOrder;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        managerMzButton = GameObject.Find("Mgr_MzButton").GetComponent<Manager_MzButton>();
        managerMzText = GameObject.Find("Mgr_MzText").GetComponent<Manager_MzText>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toNextMzOrder += new EveHandMoveState(managerMzMaster.ToNextMzIMethod);
        toNextMzOrder += new EveHandMoveState(managerMzButton.EventOTHER);
        toNextMzOrder += new EveHandMoveState(managerMzText.EventOTHER);

        buttonToNextMz.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToNextMz.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToNextMz.gameObject.SetActive(false);
    }

    public void OnButtonToNextMzClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toNextMzOrder(this, EventArgs.Empty);
    }
}