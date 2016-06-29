using System;
using UnityEngine;

public class Mgr_MzBtnToTitle : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToTitle;
    private ManagerMzMaster managerMzMaster;
    private Mgr_MzSE01 mgrMzSE01;

    private event EveHandMoveState toTitleOrder;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_MzSE01").GetComponent<Mgr_MzSE01>();
    }

    void Start() {
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toTitleOrder += new EveHandMoveState(managerMzMaster.ToTitleIMethod);

        buttonToTitle.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToTitle.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToTitle.gameObject.SetActive(false);
    }

    public void OnButtonToTitleClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toTitleOrder(this, EventArgs.Empty);
    }
}