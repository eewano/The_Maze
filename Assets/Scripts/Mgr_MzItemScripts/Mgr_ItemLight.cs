using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_ItemLight : MonoBehaviour {

    private Mgr_MzLabelLightGet mgrMzLabelLightGet;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandFlagItem flagGetLight;

    private event EveHandFlagItem flagGetLightMz00;

    void Awake() {
        mgrMzLabelLightGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelLightGet>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        flagGetLight += new EveHandFlagItem(mgrMzLabelLightGet.AppearLabelEvent);
        flagGetLight += new EveHandFlagItem(mgrMzSE01.SEGetLightEvent);
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