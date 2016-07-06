using System;
using UnityEngine;

public class WallONOFFCtrl : MonoBehaviour {

    private Mgr_WallGimmick01 mgrWallGimmick01;
    [SerializeField]
    private bool wallONType = true;

    private event EveHandWallGimmick01 wallAppearMode;

    private event EveHandWallGimmick01 wallHideMode;

    void Awake() {
        mgrWallGimmick01 = GameObject.Find("Mgr_WallGimmick01").GetComponent<Mgr_WallGimmick01>();
    }

    void Start() {
        wallAppearMode += new EveHandWallGimmick01(mgrWallGimmick01.WallAppearMode);
        wallHideMode += new EveHandWallGimmick01(mgrWallGimmick01.WallHideMode);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            if (wallONType == true)
            {
                Debug.Log("WallOn");
                this.wallAppearMode(this, EventArgs.Empty);
            }
            else if (wallONType == false)
            {
                Debug.Log("WallOff");
                this.wallHideMode(this, EventArgs.Empty);
            }
        }
    }
}
