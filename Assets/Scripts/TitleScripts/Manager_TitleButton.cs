using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_TitleButton : MonoBehaviour {

    private Mgr_TitleBtnExplain mgrTitleBtnExplain;
    private Mgr_TitleBtnToMain mgrTitleBtnToMain;
    private Mgr_TitleBtnToMz00 mgrTitleBtnToMz00;
    private Mgr_TitleBtnToMz01 mgrTitleBtnToMz01;
    private Mgr_TitleBtnToMz02 mgrTitleBtnToMz02;
    private Mgr_TitleBtnToMz03 mgrTitleBtnToMz03;

    private event EveHandMgrState titleBtnMAIN;

    private event EveHandMgrState titleBtnEXPLAIN;

    private event EveHandMgrState titleBtnGAMESTART;

    private event EveHandMgrState titleBtnEMPTY;

    void Awake() {
        mgrTitleBtnExplain = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnExplain>();
        mgrTitleBtnToMain = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMain>();
        mgrTitleBtnToMz00 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz00>();
        mgrTitleBtnToMz01 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz01>();
        mgrTitleBtnToMz02 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz02>();
        mgrTitleBtnToMz03 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz03>();
    }

    void Start() {
        //MAINステート
        titleBtnMAIN += new EveHandMgrState(mgrTitleBtnToMain.HideBtnEvent);
        titleBtnMAIN += new EveHandMgrState(mgrTitleBtnExplain.AppearBtnEvent);
        titleBtnMAIN += new EveHandMgrState(mgrTitleBtnToMz00.AppearBtnEvent);
        titleBtnMAIN += new EveHandMgrState(mgrTitleBtnToMz01.AppearBtnEvent);
        titleBtnMAIN += new EveHandMgrState(mgrTitleBtnToMz02.AppearBtnEvent);
        titleBtnMAIN += new EveHandMgrState(mgrTitleBtnToMz03.AppearBtnEvent);
        //EXPLAINステート
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnExplain.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz00.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz01.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz02.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz03.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMain.AppearBtnEvent);
        //GAMESTARTステート
        //EMPTYステート
    }

    public void TitleEventMAIN(object o, EventArgs e) {
        this.titleBtnMAIN(this, EventArgs.Empty);
    }

    public void TitleEventEXPLAIN(object o, EventArgs e) {
        this.titleBtnEXPLAIN(this, EventArgs.Empty);
    }

    public void TitleEventGAMESTART(object o, EventArgs e) {
        this.titleBtnGAMESTART(this, EventArgs.Empty);
    }

    public void TitleEventEMPTY(object o, EventArgs e) {
        this.titleBtnEMPTY(this, EventArgs.Empty);
    }
}