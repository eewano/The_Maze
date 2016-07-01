using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerTitleMaster : MonoBehaviour {

    private Manager_TitleText managerTitleText;
    private Manager_TitleButton managerTitleBtn;
    private AudioSource titleBGM;

    private event EveHandMgrState titleEventDUMMY;

    private event EveHandMgrState titleEventMAIN;

    private event EveHandMgrState titleEventEXPLAIN;

    private event EveHandMgrState titleEventGAMESTART;

    private event EveHandMgrState titleEventEMPTY;

    private enum TitleState {
        DUMMY,
        MAIN,
        EXPLAIN,
        GAMESTART,
        EMPTY
    }

    private TitleState state;

    void Awake() {
        managerTitleText = GameObject.Find("Mgr_TitleText").GetComponent<Manager_TitleText>();
        managerTitleBtn = GameObject.Find("Mgr_TitleButton").GetComponent<Manager_TitleButton>();
        titleBGM = GameObject.Find("TitleBGM").GetComponent<AudioSource>();
    }

    void Start() {
        //DUMMYステート
        //MAINステート
        titleEventMAIN += new EveHandMgrState(managerTitleText.TitleEventMAIN);
        titleEventMAIN += new EveHandMgrState(managerTitleBtn.TitleEventMAIN);
        //EXPLAINステート
        titleEventEXPLAIN += new EveHandMgrState(managerTitleText.TitleEventEXPLAIN);
        titleEventEXPLAIN += new EveHandMgrState(managerTitleBtn.TitleEventEXPLAIN);
        //GAMESTARTステート
        //EMPTYステート

        Dummy();
    }

    void Update() {
        switch (state) {
            case TitleState.DUMMY:
                break;

            case TitleState.MAIN:
                break;

            case TitleState.EXPLAIN:
                break;

            case TitleState.GAMESTART:
                break;

            case TitleState.EMPTY:
                break;
        }
    }

    void Dummy() {
        state = TitleState.DUMMY;
        Invoke("Main", 0.5f);
    }

    void Main() {
        state = TitleState.MAIN;
        this.titleEventMAIN(this, EventArgs.Empty);
    }

    void Explain() {
        state = TitleState.EXPLAIN;
        this.titleEventEXPLAIN(this, EventArgs.Empty);
    }

    void GameStart() {
        state = TitleState.GAMESTART;
        titleBGM.Stop();
    }

    void Empty() {
        state = TitleState.EMPTY;
    }

    public void ToDUMMYState(object o, EventArgs e) {
        Dummy();
    }

    public void ToMAINState(object o, EventArgs e) {
        Main();
    }

    public void ToEXPLAINState(object o, EventArgs e) {
        Explain();
    }

    public void ToGAMESTARTState(object o, EventArgs e) {
        GameStart();
    }

    public void ToEMPTYState(object o, EventArgs e) {
        Empty();
    }

    public void StartMaze(object o, int i) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + i);
    }
}