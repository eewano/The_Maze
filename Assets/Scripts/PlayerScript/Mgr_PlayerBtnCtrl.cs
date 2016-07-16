using System;
using UnityEngine;

public class Mgr_PlayerBtnCtrl : MonoBehaviour {

    [SerializeField]
    private float walkFwdSEInterval;
    private float count = 0;
    [SerializeField]
    private float walkBackSEInterval;
    private CameraWalking cameraWalking;
    private CameraSEWalk cameraSEWalk;

    public float
    maxFSpeed, maxBSpeed, maxRotSpeed, rotSpeed;
    private float
    curSpeed, curRotSpeed, playerSpeed, playerRotSpeed;

    private bool
    btnCtrl, ctrlF, ctrlB, ctrlL, ctrlR, ctrlFL, ctrlFR, ctrlBL, ctrlBR, anyBtnPush;

    private event EveHandToPlayer cameraToWalk;

    private event EveHandToPlayer cameraToBack;

    public void PushBtnFwdDown() {
        anyBtnPush = true;
        ctrlF = true;
    }

    public void PushBtnFwdUp() {
        anyBtnPush = false;
        ctrlF = false;
    }

    public void PushBtnBwdDown() {
        anyBtnPush = true;
        ctrlB = true;
    }

    public void PushBtnBwdUp() {
        anyBtnPush = false;
        ctrlB = false;
    }

    public void PushBtnLeftDown() {
        anyBtnPush = true;
        ctrlL = true;
    }

    public void PushBtnLeftUp() {
        anyBtnPush = false;
        ctrlL = false;
    }

    public void PushBtnRightDown() {
        anyBtnPush = true;
        ctrlR = true;
    }

    public void PushBtnRightUp() {
        anyBtnPush = false;
        ctrlR = false;
    }

    public void PushBtnFLDown() {
        anyBtnPush = true;
        ctrlFL = true;
    }

    public void PushBtnFLUp() {
        anyBtnPush = false;
        ctrlFL = false;
    }

    public void PushBtnFRDown() {
        anyBtnPush = true;
        ctrlFR = true;
    }

    public void PushBtnFRUp() {
        anyBtnPush = false;
        ctrlFR = false;
    }

    public void PushBtnBLDown() {
        anyBtnPush = true;
        ctrlBL = true;
    }

    public void PushBtnBLUp() {
        anyBtnPush = false;
        ctrlBL = false;
    }

    public void PushBtnBRDown() {
        anyBtnPush = true;
        ctrlBR = true;
    }

    public void PushBtnBRUp() {
        anyBtnPush = false;
        ctrlBR = false;
    }

    void Awake() {
        cameraWalking = GameObject.Find("CameraPosition").GetComponent<CameraWalking>();
        cameraSEWalk = GameObject.Find("MzCamPlayer").GetComponent<CameraSEWalk>();
    }

    void Start() {
        cameraToWalk = new EveHandToPlayer(cameraWalking.PlayerWalking);

        cameraToBack = new EveHandToPlayer(cameraSEWalk.StartWalkingSE);

        btnCtrl = true;
        ctrlF = false;
        ctrlB = false;
        ctrlL = false;
        ctrlR = false;
        ctrlFL = false;
        ctrlFR = false;
        ctrlBL = false;
        ctrlBR = false;
        anyBtnPush = false;
    }

    void Update() {
        if (btnCtrl == true)
        {
            if (anyBtnPush == true)
            {
                if (ctrlF == true)
                {
                    MoveF();
                }
                else if (ctrlB == true)
                {
                    MoveB();
                }
                else if (ctrlL == true)
                {
                    RotateL();
                }
                else if (ctrlR == true)
                {
                    RotateR();
                }
                else if (ctrlFL == true)
                {
                    MoveRotFL();
                }
                else if (ctrlFR == true)
                {
                    MoveRotFR();
                }
                else if (ctrlBL == true)
                {
                    MoveRotBL();
                }
                else if (ctrlBR == true)
                {
                    MoveRotBR();
                }

                if (playerSpeed == maxFSpeed)
                {
                    if (walkFwdSEInterval < count)
                    {
                        this.cameraToWalk(this, EventArgs.Empty);
                        count = 0;
                    }
                }

                if (playerSpeed == -maxBSpeed)
                {
                    if (walkBackSEInterval < count)
                    {
                        this.cameraToBack(this, EventArgs.Empty);
                        count = 0;
                    }
                }

                count += 1 * Time.deltaTime;
            }
            else
            {
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

    public void CtrlChangeToKey(object o, EventArgs e) {
        playerSpeed = 0;
        playerRotSpeed = 0;
        btnCtrl = false;
    }

    public void CtrlChangeToBtn(object o, EventArgs e) {
        btnCtrl = true;
    }

    public void PlayerMaxFSpeedChange(object o, float i) {
        maxFSpeed += i;
    }

    public void PlayerMaxBSpeedChange(object o, float i) {
        maxBSpeed += i;
    }

    public void PlayerMaxRotSpeedChange(object o, float i) {
        maxRotSpeed += i;
    }

    public void PlayerBtnIntervalChange(object o, float i) {
        walkFwdSEInterval += i;
    }
}