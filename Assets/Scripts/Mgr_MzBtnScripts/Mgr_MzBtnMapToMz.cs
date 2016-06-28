﻿using System;
using UnityEngine;

public class Mgr_MzBtnMapToMz : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz;
    private ManagerMzMaster managerMzMaster;
    private Mgr_MzSE01 mgrMzSE01;

    private event EveHandMoveState toPLAYINGState;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_MzSE01").GetComponent<Mgr_MzSE01>();
    }

    void Start() {
        toPLAYINGState += new EveHandMoveState(managerMzMaster.ToPlayingMethod);
        playSE += new EveHandPLAYSE(mgrMzSE01.SECancelEvent);

        buttonToMz.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz.gameObject.SetActive(false);
    }

    public void OnButtonMapToMzClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toPLAYINGState(this, EventArgs.Empty);
    }
}