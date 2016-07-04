using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerTitleMaster : MonoBehaviour {

    private Manager_TitleText managerTitleText;
    private Manager_TitleButton managerTitleBtn;
    private AudioSource titleBGM;
    private ImageFade imageFadeBlack;

    private event EveHandMgrState titleEventMAINMEMU;

    private event EveHandMgrState titleEventEXPLAIN;

    private event EveHandMgrState titleEventGAMESTART;

    private enum TitleState {
        DUMMY,
        MAINMENU,
        EXPLAIN,
        GAMESTART,
        EMPTY
    }
    private TitleState state;

    void Awake() {
        managerTitleText = GameObject.Find("Mgr_TitleText").GetComponent<Manager_TitleText>();
        managerTitleBtn = GameObject.Find("Mgr_TitleButton").GetComponent<Manager_TitleButton>();
        titleBGM = GameObject.Find("TitleBGM").GetComponent<AudioSource>();
        imageFadeBlack = GameObject.Find("FadeBlack").GetComponent<ImageFade>();
    }

    void Start() {
        //DUMMYステート
        //MAINステート
        titleEventMAINMEMU += new EveHandMgrState(managerTitleText.TitleEventMAINMENU);
        titleEventMAINMEMU += new EveHandMgrState(managerTitleBtn.TitleEventMAINMENU);
        //EXPLAINステート
        titleEventEXPLAIN += new EveHandMgrState(managerTitleText.TitleEventEXPLAIN);
        titleEventEXPLAIN += new EveHandMgrState(managerTitleBtn.TitleEventEXPLAIN);
        //GAMESTARTステート
        titleEventGAMESTART += new EveHandMgrState(managerTitleBtn.TitleEventGAMESTART);
        //EMPTYステート

        Dummy();
    }

    void Update() {
        switch (state) {
            case TitleState.DUMMY:
                break;

            case TitleState.MAINMENU:
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
        Invoke("MainMenu", 0.5f);
    }

    void MainMenu() {
        state = TitleState.MAINMENU;
        this.titleEventMAINMEMU(this, EventArgs.Empty);
    }

    void Explain() {
        state = TitleState.EXPLAIN;
        this.titleEventEXPLAIN(this, EventArgs.Empty);
    }

    void GameStart() {
        state = TitleState.GAMESTART;
        this.titleEventGAMESTART(this, EventArgs.Empty);
        titleBGM.Stop();
        imageFadeBlack.show();
    }

    void Empty() {
        state = TitleState.EMPTY;
    }

    public void ToDUMMYState(object o, EventArgs e) {
        Dummy();
    }

    public void ToMAINMENUState(object o, EventArgs e) {
        MainMenu();
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