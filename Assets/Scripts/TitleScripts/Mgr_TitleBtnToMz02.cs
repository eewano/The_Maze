using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz02 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz02;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze02;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze02 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);

        buttonToMz02.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz02.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz02.gameObject.SetActive(false);
    }

    public void OnButtonToMz02Clicked() {
        this.playSE(this, EventArgs.Empty);
        StartCoroutine(ToMz02());
    }

    IEnumerator ToMz02() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze02(this, 2);
    }
}