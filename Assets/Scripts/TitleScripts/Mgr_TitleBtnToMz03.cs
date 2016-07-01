using System;
using UnityEngine;
using System.Collections;

public class Mgr_TitleBtnToMz03 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz03;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze03;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze03 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);

        buttonToMz03.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz03.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz03.gameObject.SetActive(false);
    }

    public void OnButtonToMz03Clicked() {
        this.playSE(this, EventArgs.Empty);
        StartCoroutine(ToMz03());
    }

    IEnumerator ToMz03() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze03(this, 3);
    }
}