using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz06 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz06;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze06;

    private event EveHandMoveState toStopBGM;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze06 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toStopBGM += new EveHandMoveState(managerTitleMaster.ToGAMESTARTState);

        buttonToMz06.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz06.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz06.gameObject.SetActive(false);
    }

    public void OnButtonToMz06Clicked() {
        this.playSE(this, EventArgs.Empty);
        this.toStopBGM(this, EventArgs.Empty);
        StartCoroutine(ToMz06());
    }

    IEnumerator ToMz06() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze06(this, 6);
    }
}