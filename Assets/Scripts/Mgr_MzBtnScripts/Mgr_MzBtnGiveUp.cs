﻿using System;
using UnityEngine;

public class Mgr_MzBtnGiveUp : MonoBehaviour {

    [SerializeField]
    private GameObject buttonGiveUp;
    private ManagerMzMaster managerMzMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandMoveState toGIVEUPState;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toGIVEUPState += new EveHandMoveState(managerMzMaster.ToGIVEUPState);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);

        buttonGiveUp.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonGiveUp.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonGiveUp.gameObject.SetActive(false);
    }

    public void OnButtonGiveUpClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toGIVEUPState(this, EventArgs.Empty);
    }
}