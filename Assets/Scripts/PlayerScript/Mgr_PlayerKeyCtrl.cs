using System;
using System.Collections;
using UnityEngine;

public class Mgr_PlayerKeyCtrl : MonoBehaviour {

    [SerializeField]
    private float keySpeed;
    [SerializeField]
    private float keyRotSpeed;
    [SerializeField]
    private float walkSEFwdInterval;
    [SerializeField]
    private float walkSEBackInterval;
    private float count = 0;
    private CameraWalking cameraWalking;
    private CameraSEWalk cameraSEWalk;

    private bool keyCtrl;

    private event EveHandToPlayer cameraToWalk;

    private event EveHandToPlayer cameraToBack;

    void Awake() {
        cameraWalking = GameObject.Find("CameraPosition").GetComponent<CameraWalking>();
        cameraSEWalk = GameObject.Find("MzCamPlayer").GetComponent<CameraSEWalk>();
    }

    void Start() {
        cameraToWalk = new EveHandToPlayer(cameraWalking.PlayerWalking);

        cameraToBack = new EveHandToPlayer(cameraSEWalk.StartWalkingSE);

        keyCtrl = false;
    }

    void Update() {
        if (keyCtrl == true)
        {
            float translation = Input.GetAxis("Vertical") * keySpeed;
            if (translation < 0)
            {
                translation *= 0.6f;
                if (translation == -keySpeed * 0.6f)
                {
                    if (walkSEBackInterval < count)
                    {
                        this.cameraToBack(this, EventArgs.Empty);
                        count = 0;
                    }
                }
            }
            else if (translation > 0)
            {
                if (translation == keySpeed)
                {
                    if (walkSEFwdInterval < count)
                    {
                        this.cameraToWalk(this, EventArgs.Empty);
                        count = 0;
                    }
                }
            }
            count += 1 * Time.deltaTime;

            float rotation = Input.GetAxis("Horizontal") * keyRotSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
    }

    public void CtrlChangeToKey(object o, EventArgs e) {
        keyCtrl = true;
    }

    public void CtrlChangeToBtn(object o, EventArgs e) {
        keyCtrl = false;
    }

    public void PlayerKeySpeedChange(object o, float i) {
        keySpeed += i;
    }

    public void PlayerKeyRotSpeedChange(object o, float i) {
        keyRotSpeed += i;
    }

    public void PlayerKeyIntervalChange(object o, float i) {
        walkSEFwdInterval += i;
    }
}