using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_ItemCroquette : MonoBehaviour {

    private Mgr_MzLabelCroquetteGet mgrMzLabelCroquetteGet;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandFlagItem flagGetCroquette;

    void Awake() {
        mgrMzLabelCroquetteGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelCroquetteGet>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        flagGetCroquette += new EveHandFlagItem(mgrMzLabelCroquetteGet.AppearLabelEvent);
        flagGetCroquette += new EveHandFlagItem(mgrMzSE01.SEGetCroquetteEvent);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagGetCroquette(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }

    //----------デバッグ用----------
    public void DebugGetCroquette() {
        this.flagGetCroquette(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
    //--------------------
}