using System;
using UnityEngine;

public class WallGimmick01 : MonoBehaviour {

    [SerializeField]
    private bool startAppear = true;

    void Start() {
        if (startAppear == true)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void AppearWallEvent(object o, EventArgs e) {
        this.gameObject.SetActive(true);
    }

    public void HideWallEvent(object o, EventArgs e) {
        this.gameObject.SetActive(false);
    }
}