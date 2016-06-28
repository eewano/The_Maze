using System;
using UnityEngine;

public class Mgr_MzCamMap : MonoBehaviour {

    [SerializeField]
    private Camera mzCamMap;

    void Start() {
        mzCamMap.enabled = false;
    }

    public void AppearCamEvent(object o, EventArgs e) {
        mzCamMap.enabled = true;
    }

    public void HideCamEvent(object o, EventArgs e) {
        mzCamMap.enabled = false;
    }
}