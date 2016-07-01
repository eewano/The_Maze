using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_TitleBtnToMz00 : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToMz00;
    private ManagerTitleMaster managerTitleMaster;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandGoToMaze toMaze00;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        toMaze00 += new EveHandGoToMaze(managerTitleMaster.StartMaze);
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);

        buttonToMz00.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToMz00.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToMz00.gameObject.SetActive(false);
    }

    public void OnButtonToMz00Clicked() {
        this.playSE(this, EventArgs.Empty);
        StartCoroutine(ToMz00());
    }

    IEnumerator ToMz00() {
        yield return new WaitForSeconds(4.0f);
        this.toMaze00(this, 0);
    }
}