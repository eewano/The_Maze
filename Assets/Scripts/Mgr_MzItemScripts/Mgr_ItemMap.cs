using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_ItemMap : MonoBehaviour {

    private Mgr_MzLabelMapGet mgrMzLabelMapGet;
    private Mgr_MzSE01 mgrMzSE01;

    private event EveHandFlagItem flagGetMap;

    void Awake() {
        mgrMzLabelMapGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelMapGet>();
        mgrMzSE01 = GameObject.Find("Mgr_MzSE01").GetComponent<Mgr_MzSE01>();
    }

    void Start() {
        flagGetMap += new EveHandFlagItem(mgrMzLabelMapGet.AppearLabelEvent);
        flagGetMap += new EveHandFlagItem(mgrMzSE01.SEGetMapEvent);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagGetMap(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }

    //----------デバッグ用----------
    public void DebugGetMap() {
        this.flagGetMap(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
    //--------------------
}