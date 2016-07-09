using System;
using UnityEngine;

public class Mgr_ItemLightMz00 : MonoBehaviour {

    private Manager_DirLight managerDirLight;
    private Mgr_MzLabelLightGet mgrMzLabelLightGet;
    private Mgr_Mz00ItemGet mgrMz00ItemGet;
    private Mgr_BtnDeleteMz00 mgrBtnDeleteMz00;
    private Mgr_GameSE01 mgrGameSE01;

    private event EveHandFlagItem flagGetLightMz00;

    void Awake() {
        mgrMzLabelLightGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelLightGet>();
        mgrMz00ItemGet = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_Mz00ItemGet>();
        mgrBtnDeleteMz00 = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_BtnDeleteMz00>();
        mgrGameSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
        managerDirLight = GameObject.Find("Mgr_DirLight").GetComponent<Manager_DirLight>();
    }

    void Start() {
        flagGetLightMz00 += new EveHandFlagItem(mgrMzLabelLightGet.AppearLabelEvent);
        flagGetLightMz00 += new EveHandFlagItem(mgrGameSE01.SEGetLightEvent);
        flagGetLightMz00 += new EveHandFlagItem(mgrMz00ItemGet.Mz00LightGet);
        flagGetLightMz00 += new EveHandFlagItem(mgrBtnDeleteMz00.AppearObject);
        flagGetLightMz00 += new EveHandFlagItem(managerDirLight.GetLightItem);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagGetLightMz00(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }

    //----------デバッグ用----------
    public void DebugGetLight() {
        this.flagGetLightMz00(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
    //--------------------
}