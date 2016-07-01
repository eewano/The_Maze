using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz01 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz01;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze01;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze01 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);

        buttonToMz01.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz01.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz01.gameObject.SetActive(false);
    }

    public void OnButtonToMz01Clicked() {
        this.playSE(this, EventArgs.Empty);
        StartCoroutine(ToMz01());
    }

    IEnumerator ToMz01() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze01(this, 1);
    }
}