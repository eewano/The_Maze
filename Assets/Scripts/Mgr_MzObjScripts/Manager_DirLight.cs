using System;
using UnityEngine;

public class Manager_DirLight : MonoBehaviour {

    private Mgr_DirLightMz mgrDirLightMz;
    private Mgr_DirLightMap mgrDirLightMap;
    private Mgr_DirLightGoal mgrDirLightGoal;
    [SerializeField]
    private float defaultMzValue = 0.3f;

    private bool getLight;

    private event EveHandDirLight changeDirLightItem;

    private event EveHandDirLight changeDirLightMap;

    private event EveHandDirLight changeDirLightGoal;

    void Awake() {
        mgrDirLightMz = GameObject.Find("Mgr_DirLight").GetComponent<Mgr_DirLightMz>();
        mgrDirLightMap = GameObject.Find("Mgr_DirLight").GetComponent<Mgr_DirLightMap>();
        mgrDirLightGoal = GameObject.Find("Mgr_DirLight").GetComponent<Mgr_DirLightGoal>();
    }

    void Start() {
        getLight = false;
        //DUMMYステート

        //ライトゲット
        changeDirLightItem += new EveHandDirLight(mgrDirLightMz.ChangeIntensityOfMz);
        //MAPステート
        changeDirLightMap += new EveHandDirLight(mgrDirLightMap.ChangeIntensityOfMap);
        //ゴールイン
        changeDirLightGoal += new EveHandDirLight(mgrDirLightGoal.ChangeIntensityOfGoal);
    }

    public void GetLightItem(object o, EventArgs e) {
        getLight = true;
        this.changeDirLightItem(this, 1.0f);
    }

    public void EventMAP(object o, EventArgs e) {
        this.changeDirLightItem(this, 0.0f);
        this.changeDirLightMap(this, 0.6f);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.changeDirLightMap(this, 0.0f);
        if (getLight == true)
        {
            this.changeDirLightItem(this, 1.0f);
        }
        else
        {
            this.changeDirLightItem(this, defaultMzValue);
        }
    }

    public void EventGOAL(object o, EventArgs e) {
        this.changeDirLightGoal(this, 1.0f);
        this.changeDirLightItem(this, 0.0f);
    }
}