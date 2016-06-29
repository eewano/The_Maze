using System;
using UnityEngine;

public class Mgr_MzBtnNextMz : MonoBehaviour {

    [SerializeField]
    private GameObject buttonToNextMz;
    private ManagerMzMaster managerMzMaster;
    private Mgr_MzSE01 mgrMzSE01;

    private event EveHandMoveState toNextMzOrder;

    private event EveHandPLAYSE playSE;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
        mgrMzSE01 = GameObject.Find("Mgr_MzSE01").GetComponent<Mgr_MzSE01>();
    }

    void Start() {
        playSE += new EveHandPLAYSE(mgrMzSE01.SEEnterEvent);
        toNextMzOrder += new EveHandMoveState(managerMzMaster.ToNextMzIMethod);

        buttonToNextMz.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonToNextMz.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonToNextMz.gameObject.SetActive(false);
    }

    public void OnButtonToNextMzClicked() {
        this.playSE(this, EventArgs.Empty);
        this.toNextMzOrder(this, EventArgs.Empty);
    }
}