using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz09 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz09;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze09;

    private event EveHandMoveState toStopBGM;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze09 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toStopBGM += new EveHandMoveState(managerTitleMaster.ToGAMESTARTState);

        buttonToMz09.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz09.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz09.gameObject.SetActive(false);
    }

    public void OnButtonToMz09Clicked() {
        this.playSE(this, EventArgs.Empty);
        this.toStopBGM(this, EventArgs.Empty);
        StartCoroutine(ToMz09());
    }

    IEnumerator ToMz09() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze09(this, 9);
    }
}