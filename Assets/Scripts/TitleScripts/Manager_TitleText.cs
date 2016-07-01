using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_TitleText : MonoBehaviour {

    private Mgr_TitleTextMain01 mgrTitleTextMain01;
    private Mgr_TitleTextMain02 mgrTitleTextMain02;
    private Mgr_TitleTextExplain01 mgrTitleTextExplain01;
    private Mgr_TitleTextExplain02 mgrTitleTextExplain02;

    private event EveHandMgrState titleTextMAIN;

    private event EveHandMgrState titleTextEXPLAIN;

    private event EveHandMgrState titleTextGAMESTART;

    private event EveHandMgrState titleTextEMPTY;

    void Awake() {
        mgrTitleTextMain01 = GameObject.Find("Mgr_TitleText").GetComponent<Mgr_TitleTextMain01>();
        mgrTitleTextMain02 = GameObject.Find("Mgr_TitleText").GetComponent<Mgr_TitleTextMain02>();
        mgrTitleTextExplain01 = GameObject.Find("Mgr_TitleText").GetComponent<Mgr_TitleTextExplain01>();
        mgrTitleTextExplain02 = GameObject.Find("Mgr_TitleText").GetComponent<Mgr_TitleTextExplain02>();
    }

	void Start () {
        //TITLEステート
        titleTextMAIN += new EveHandMgrState(mgrTitleTextExplain01.HideTextEvent);
        titleTextMAIN += new EveHandMgrState(mgrTitleTextExplain02.HideTextEvent);
        titleTextMAIN += new EveHandMgrState(mgrTitleTextMain01.AppearTextEvent);
        titleTextMAIN += new EveHandMgrState(mgrTitleTextMain02.AppearTextEvent);
        //DESCRIPTIONステート
        titleTextEXPLAIN += new EveHandMgrState(mgrTitleTextMain01.HideTextEvent);
        titleTextEXPLAIN += new EveHandMgrState(mgrTitleTextMain02.HideTextEvent);
        titleTextEXPLAIN += new EveHandMgrState(mgrTitleTextExplain01.AppearTextEvent);
        titleTextEXPLAIN += new EveHandMgrState(mgrTitleTextExplain02.AppearTextEvent);
        //GAMESTARTステート
        //EMPTYステート
	}

    public void TitleEventMAIN(object o, EventArgs e) {
        this.titleTextMAIN(this, EventArgs.Empty);
    }

    public void TitleEventEXPLAIN(object o, EventArgs e) {
        this.titleTextEXPLAIN(this, EventArgs.Empty);
    }

    public void TitleEventGAMESTART(object o, EventArgs e) {
    }

    public void TitleEventEMPTY(object o, EventArgs e) {
    }
}
