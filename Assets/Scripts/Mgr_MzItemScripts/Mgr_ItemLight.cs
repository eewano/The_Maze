using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_ItemLight : MonoBehaviour {

    private Mgr_MzLabelLightGet mgrMzLabelLightGet;
    private Mgr_MzSE01 mgrMzSE01;

    private event EveHandFlagItem flagGetLight;

    void Awake() {
        mgrMzLabelLightGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelLightGet>();
        mgrMzSE01 = GameObject.Find("Mgr_MzSE01").GetComponent<Mgr_MzSE01>();
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