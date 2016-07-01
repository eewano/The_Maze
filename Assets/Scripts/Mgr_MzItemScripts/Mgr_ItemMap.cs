using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_ItemMap : MonoBehaviour {

    private Manager_MzButton managerMzButton;
    private Mgr_MzBtnMap mgrMzBtnMap;
    private Mgr_MzLabelMapGet mgrMzLabelMapGet;
    private Mgr_GameSE01 mgrMzSE01;

    private event EveHandFlagItem flagGetMap;

    void Awake() {
        managerMzButton = GameObject.Find("Mgr_MzButton").GetComponent<Manager_MzButton>();
        mgrMzBtnMap = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnMap>();
        mgrMzLabelMapGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelMapGet>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        flagGetMap += new EveHandFlagItem(mgrMzBtnMap.AppearBtnEvent);
        flagGetMap += new EveHandFlagItem(managerMzButton.GetItemMap);
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