using System;
using UnityEngine;

public class Mgr_WallGimmick01 : MonoBehaviour {

    [SerializeField]
    private WallGimmick01 wallGimmick01;
    private Mgr_GameSE02 mgrGameSE02;
    private ClashCamera clashCamera;

    private bool clashCameraON = false;

    private event EveHandWallGimmick01 gimmick01ONEvent;

    private event EveHandWallGimmick01 gimmick01OFFEvent;

    private event EveHandPLAYSE cameraCrashEffect;

    void Awake() {
        mgrGameSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Mgr_GameSE02>();
        clashCamera = GameObject.Find("MzCamPlayer").GetComponent<ClashCamera>();
    }

    void Start() {
        gimmick01ONEvent += new EveHandWallGimmick01(wallGimmick01.AppearWallEvent);
        gimmick01ONEvent += new EveHandWallGimmick01(clashCamera.ClashCameraOn);
        cameraCrashEffect += new EveHandPLAYSE(mgrGameSE02.SEShutter01Event);

        gimmick01OFFEvent += new EveHandWallGimmick01(wallGimmick01.HideWallEvent);
    }

    public void WallAppearMode(object o, EventArgs e) {
        if (clashCameraON == true)
        {
            this.gimmick01ONEvent(this, EventArgs.Empty);
            this.cameraCrashEffect(this, EventArgs.Empty);
            clashCameraON = false;
        }
    }

    public void WallHideMode(object o, EventArgs e) {
        if (clashCameraON == false)
        {
            this.gimmick01OFFEvent(this, EventArgs.Empty);
            clashCameraON = true;
        }
    }
}