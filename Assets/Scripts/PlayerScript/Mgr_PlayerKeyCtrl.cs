using System;
using UnityEngine;

public class Mgr_PlayerKeyCtrl : MonoBehaviour {

    public float
    keySpeed, keyRotSpeed;

    private bool keyCtrl;

    void Start() {
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
}