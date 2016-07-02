using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_ItemMapMz00 : MonoBehaviour {

    private Manager_MzButton managerMzButton;
    private Mgr_MzBtnMap mgrMzBtnMap;
    private Mgr_MzLabelMapGet mgrMzLabelMapGet;
    private Mgr_Mz00ItemGet mgrMz00ItemGet;
    private Mgr_BtnDeleteMz00 mgrBtnDeleteMz00;
    private Mgr_GameSE01 mgrGameSE01;

    private event EveHandFlagItem flagGetMapMz00;

    void Awake() {
        managerMzButton = GameObject.Find("Mgr_MzButton").GetComponent<Manager_MzButton>();
        mgrMzBtnMap = GameObject.Find("Mgr_MzButton").GetComponent<Mgr_MzBtnMap>();
        mgrMzLabelMapGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelMapGet>();
        mgrMz00ItemGet = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_Mz00ItemGet>();
        mgrBtnDeleteMz00 = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_BtnDeleteMz00>();
        mgrGameSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        flagGetMapMz00 += new EveHandFlagItem(mgrMzBtnMap.AppearBtnEvent);
        flagGetMapMz00 += new EveHandFlagItem(managerMzButton.GetItemMap);
        flagGetMapMz00 += new EveHandFlagItem(mgrMzLabelMapGet.AppearLabelEvent);
        flagGetMapMz00 += new EveHandFlagItem(mgrGameSE01.SEGetMapEvent);
        flagGetMapMz00 += new EveHandFlagItem(mgrMz00ItemGet.Mz00MapGet);
        flagGetMapMz00 += new EveHandFlagItem(mgrBtnDeleteMz00.AppearObject);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagGetMapMz00(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }

    //----------デバッグ用----------
    public void DebugGetMap() {
        this.flagGetMapMz00(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
    //--------------------
}