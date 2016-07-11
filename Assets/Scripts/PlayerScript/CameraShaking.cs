using System;
using UnityEngine;

public class CameraShaking : MonoBehaviour {

    public void CameraShakeOn(object o, EventArgs e) {
        GetComponent<Animator>().SetTrigger("Shake");
    }

    //-----デバッグモード-----
    void Update() {
        if (Input.GetKeyDown("h")) {
            GetComponent<Animator>().SetTrigger("Shake");
        }
    }
    //----------
}