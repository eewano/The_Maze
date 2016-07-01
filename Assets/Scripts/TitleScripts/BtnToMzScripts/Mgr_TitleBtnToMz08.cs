using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz08 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz08;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze08;

    private event EveHandMoveState toStopBGM;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze08 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toStopBGM += new EveHandMoveState(managerTitleMaster.ToGAMESTARTState);

        buttonToMz08.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz08.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz08.gameObject.SetActive(false);
    }

    public void OnButtonToMz08Clicked() {
        this.playSE(this, EventArgs.Empty);
        this.toStopBGM(this, EventArgs.Empty);
        StartCoroutine(ToMz08());
    }

    IEnumerator ToMz08() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze08(this, 8);
    }
}