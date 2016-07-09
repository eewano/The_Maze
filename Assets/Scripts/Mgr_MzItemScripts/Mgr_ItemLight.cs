using System;
using UnityEngine;

public class Mgr_ItemLight : MonoBehaviour {

    private Manager_DirLight managerDirLight;
    private Mgr_MzLabelLightGet mgrMzLabelLightGet;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandFlagItem flagGetLight;

    void Awake() {
        mgrMzLabelLightGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelLightGet>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
        managerDirLight = GameObject.Find("Mgr_DirLight").GetComponent<Manager_DirLight>();
    }

    void Start() {
        flagGetLight += new EveHandFlagItem(mgrMzLabelLightGet.AppearLabelEvent);
        flagGetLight += new EveHandFlagItem(mgrMzSE01.SEGetLightEvent);
        flagGetLight += new EveHandFlagItem(managerDirLight.GetLightItem);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagGetLight(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }

    //----------デバッグ用----------
    public void DebugGetLight() {
        this.flagGetLight(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
    //--------------------
}