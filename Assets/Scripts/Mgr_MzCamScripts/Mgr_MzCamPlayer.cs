using System;
using UnityEngine;

public class Mgr_MzCamPlayer : MonoBehaviour {

    [SerializeField]
    private Camera mzCamPlayer;

    void Start() {
        mzCamPlayer.enabled = true;
    }

    public void AppearCamEvent(object o, EventArgs e) {
        mzCamPlayer.enabled = true;
    }

    public void HideCamEvent(object o, EventArgs e) {
        mzCamPlayer.enabled = false;
    }
}