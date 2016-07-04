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
    private Mgr_TitleBtnToMz04 mgrTitleBtnToMz04;
    private Mgr_TitleBtnToMz05 mgrTitleBtnToMz05;
    private Mgr_TitleBtnToMz06 mgrTitleBtnToMz06;
    private Mgr_TitleBtnToMz07 mgrTitleBtnToMz07;
    private Mgr_TitleBtnToMz08 mgrTitleBtnToMz08;
    private Mgr_TitleBtnToMz09 mgrTitleBtnToMz09;
    private Mgr_TitleBtnToMz10 mgrTitleBtnToMz10;

    private event EveHandMgrState titleBtnMAINMENU;

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
        mgrTitleBtnToMz04 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz04>();
        mgrTitleBtnToMz05 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz05>();
        mgrTitleBtnToMz06 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz06>();
        mgrTitleBtnToMz07 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz07>();
        mgrTitleBtnToMz08 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz08>();
        mgrTitleBtnToMz09 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz09>();
        mgrTitleBtnToMz10 = GameObject.Find("Mgr_TitleButton").GetComponent<Mgr_TitleBtnToMz10>();
    }

    void Start() {
        //MAINステート
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMain.HideBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnExplain.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz00.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz01.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz02.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz03.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz04.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz05.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz06.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz07.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz08.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz09.AppearBtnEvent);
        titleBtnMAINMENU += new EveHandMgrState(mgrTitleBtnToMz10.AppearBtnEvent);
        //EXPLAINステート
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnExplain.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz00.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz01.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz02.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz03.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz04.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz05.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz06.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz07.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz08.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz09.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMz10.HideBtnEvent);
        titleBtnEXPLAIN += new EveHandMgrState(mgrTitleBtnToMain.AppearBtnEvent);
        //GAMESTARTステート
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnExplain.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz00.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz01.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz02.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz03.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz04.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz05.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz06.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz07.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz08.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz09.HideBtnEvent);
        titleBtnGAMESTART += new EveHandMgrState(mgrTitleBtnToMz10.HideBtnEvent);
        //EMPTYステート
    }

    public void TitleEventMAINMENU(object o, EventArgs e) {
        this.titleBtnMAINMENU(this, EventArgs.Empty);
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