using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz10 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz10;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze10;

    private event EveHandMoveState toStopBGM;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze10 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toStopBGM += new EveHandMoveState(managerTitleMaster.ToGAMESTARTState);

        buttonToMz10.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz10.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz10.gameObject.SetActive(false);
    }

    public void OnButtonToMz10Clicked() {
        this.playSE(this, EventArgs.Empty);
        this.toStopBGM(this, EventArgs.Empty);
        StartCoroutine(ToMz10());
    }

    IEnumerator ToMz10() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze10(this, 10);
    }
}