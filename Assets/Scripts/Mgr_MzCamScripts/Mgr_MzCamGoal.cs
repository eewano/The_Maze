using System;
using UnityEngine;

public class Mgr_MzCamGoal : MonoBehaviour {

    [SerializeField]
    private Camera mzCamGoal;

    void Start() {
        mzCamGoal.enabled = true;
    }

    public void AppearCamEvent(object o, EventArgs e) {
        mzCamGoal.enabled = true;
    }

    public void HideCamEvent(object o, EventArgs e) {
        mzCamGoal.enabled = false;
    }
}