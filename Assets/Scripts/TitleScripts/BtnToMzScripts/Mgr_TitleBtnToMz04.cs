using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz04 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz04;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze04;

    private event EveHandMoveState toStopBGM;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze04 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toStopBGM += new EveHandMoveState(managerTitleMaster.ToGAMESTARTState);

        buttonToMz04.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz04.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz04.gameObject.SetActive(false);
    }

    public void OnButtonToMz04Clicked() {
        this.playSE(this, EventArgs.Empty);
        this.toStopBGM(this, EventArgs.Empty);
        StartCoroutine(ToMz04());
    }

    IEnumerator ToMz04() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze04(this, 4);
    }
}