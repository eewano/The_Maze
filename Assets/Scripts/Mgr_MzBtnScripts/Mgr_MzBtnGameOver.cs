using System;
using UnityEngine;

public class Mgr_MzBtnGameOver : MonoBehaviour {

    [SerializeField]
    private GameObject buttonGameOver;
    private ManagerMzMaster managerMzMaster;

    private event EveHandMoveState toGAMEOVERState;

    void Awake() {
        managerMzMaster = GameObject.Find("ManagerMzMaster").GetComponent<ManagerMzMaster>();
    }

    void Start() {
        toGAMEOVERState += new EveHandMoveState(managerMzMaster.ToGameOverMethod);
        buttonGameOver.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        buttonGameOver.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        buttonGameOver.gameObject.SetActive(false);
    }

    public void OnButtonGameOverClicked() {
        this.toGAMEOVERState(this, EventArgs.Empty);
    }
}