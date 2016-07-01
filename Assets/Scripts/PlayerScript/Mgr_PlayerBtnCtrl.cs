using System;
using UnityEngine;

public class Mgr_PlayerBtnCtrl : MonoBehaviour {

    public float
    maxFSpeed, maxBSpeed, maxRotSpeed, rotSpeed;
    private float
    curSpeed, curRotSpeed, playerSpeed, playerRotSpeed;

    private bool
    btnCtrl, ctrlF, ctrlB, ctrlL, ctrlR, ctrlFL, ctrlFR, ctrlBL, ctrlBR;

    public void PushBtnFwdDown() {
        ctrlF = true;
    }

    public void PushBtnFwdUp() {
        ctrlF = false;
    }

    public void PushBtnBwdDown() {
        ctrlB = true;
    }

    public void PushBtnBwdUp() {
        ctrlB = false;
    }

    public void PushBtnLeftDown() {
        ctrlL = true;
    }

    public void PushBtnLeftUp() {
        ctrlL = false;
    }

    public void PushBtnRightDown() {
        ctrlR = true;
    }

    public void PushBtnRightUp() {
        ctrlR = false;
    }

    public void PushBtnFLDown() {
        ctrlFL = true;
    }

    public void PushBtnFLUp() {
        ctrlFL = false;
    }

    public void PushBtnFRDown() {
        ctrlFR = true;
    }

    public void PushBtnFRUp() {
        ctrlFR = false;
    }

    public void PushBtnBLDown() {
        ctrlBL = true;
    }

    public void PushBtnBLUp() {
        ctrlBL = false;
    }

    public void PushBtnBRDown() {
        ctrlBR = true;
    }

    public void PushBtnBRUp() {
        ctrlBR = false;
    }

    void Start() {
        btnCtrl = false;
        ctrlF = false;
        ctrlB = false;
        ctrlL = false;
        ctrlR = false;
        ctrlFL = false;
        ctrlFR = false;
        ctrlBL = false;
        ctrlBR = false;
    }

    void Update() {
        if (btnCtrl == true) {
            if (ctrlF == true) {
                MoveF();
            } else if (ctrlB == true) {
                MoveB();
            } else if (ctrlL == true) {
                RotateL();
            } else if (ctrlR == true) {
                RotateR();
            } else if (ctrlFL == true) {
                MoveRotFL();
            } else if (ctrlFR == true) {
                MoveRotFR();
            } else if (ctrlBL == true) {
                MoveRotBL();
            } else if (ctrlBR == true) {
                MoveRotBR();
            } else {
                playerSpeed = 0;
                playerRotSpeed = 0;
            }
        }

        curSpeed = Mathf.Lerp(curSpeed, playerSpeed, 10.0f * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);

        curRotSpeed = Mathf.Lerp(curRotSpeed, playerRotSpeed, 10.0f * Time.deltaTime);
        transform.Rotate(0, -rotSpeed * Time.deltaTime * curRotSpeed, 0.0f);
    }

    void MoveF() {
        playerSpeed = maxFSpeed;
    }

    void MoveB() {
        playerSpeed = -maxBSpeed;
    }

    void RotateL() {
        playerRotSpeed = maxRotSpeed;
    }

    void RotateR() {
        playerRotSpeed = -maxRotSpeed;
    }

    void MoveRotFL() {
        playerSpeed = maxFSpeed;
        playerRotSpeed = maxRotSpeed;
    }

    void MoveRotFR() {
        playerSpeed = maxFSpeed;
        playerRotSpeed = -maxRotSpeed;
    }

    void MoveRotBL() {
        playerSpeed = -maxBSpeed;
        playerRotSpeed = maxRotSpeed;
    }

    void MoveRotBR() {
        playerSpeed = -maxBSpeed;
        playerRotSpeed = -maxRotSpeed;
    }

    public void DebugCtrlChangeToKey(object o, EventArgs e) {
        btnCtrl = false;
    }

    public void DebugCtrlChangeToBtn(object o, EventArgs e) {
        btnCtrl = true;
    }
}