using System;
using UnityEngine;

public class ClashCamera : MonoBehaviour {

    public void ClashCameraOn(object o, EventArgs e) {
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