using System;
using System.Collections;
using UnityEngine;

public class Mgr_PlayerKeyCtrl : MonoBehaviour {

    [SerializeField]
    private float keySpeed;
    [SerializeField]
    private float keyRotSpeed;
    [SerializeField]
    private float walkSEInterval;
    private float count = 0;
    private CameraSEWalk cameraWalking;

    private bool keyCtrl;

    private event EveHandToPlayer cameraToWalk;

    void Awake() {
        cameraWalking = GameObject.Find("MzCamPlayer").GetComponent<CameraSEWalk>();
    }

    void Start() {
        cameraToWalk = new EveHandToPlayer(cameraWalking.StartWalking);
        keyCtrl = true;
    }

    void Update() {
        if (keyCtrl == true)
        {
            float translation = Input.GetAxis("Vertical") * keySpeed;
            if (translation < 0)
            {
                translation *= 0.5f;
            }
            else if(translation > 0)
            {
                if(translation == keySpeed)
                {
                    if(walkSEInterval < count)
                    {
                        this.cameraToWalk(this, EventArgs.Empty);
                        count = 0;
                    }
                }
                count += 1 * Time.deltaTime;
            }

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
        walkSEInterval += i;
    }
}