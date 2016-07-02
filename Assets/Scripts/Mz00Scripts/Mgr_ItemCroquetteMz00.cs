using System;
using UnityEngine;

public class Mgr_ItemCroquetteMz00 : MonoBehaviour {

    private ManagerPlayerMaster managerPlayerMaster;
    private Mgr_MzLabelCroquetteGet mgrMzLabelCroquetteGet;
    private Mgr_Mz00ItemGet mgrMz00ItemGet;
    private Mgr_BtnDeleteMz00 mgrBtnDeleteMz00;
    private Mgr_GameSE01 mgrGameSE01;

    private event EveHandFlagItem flagGetCroquetteMz00;

    private event EveHandToPlayer mz00PlayerGetCroquette;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        mgrMzLabelCroquetteGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelCroquetteGet>();
        mgrMz00ItemGet = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_Mz00ItemGet>();
        mgrBtnDeleteMz00 = GameObject.Find("Mgr_Mz00").GetComponent<Mgr_BtnDeleteMz00>();
        mgrGameSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        flagGetCroquetteMz00 += new EveHandFlagItem(mgrMzLabelCroquetteGet.AppearLabelEvent);
        flagGetCroquetteMz00 += new EveHandFlagItem(mgrGameSE01.SEGetCroquetteEvent);
        flagGetCroquetteMz00 += new EveHandFlagItem(mgrMz00ItemGet.Mz00CroquetteGet);
        flagGetCroquetteMz00 += new EveHandFlagItem(mgrBtnDeleteMz00.AppearObject);
        mz00PlayerGetCroquette += new EveHandToPlayer(managerPlayerMaster.PlayerGetCroquette);

    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagGetCroquetteMz00(this, EventArgs.Empty);
            this.mz00PlayerGetCroquette(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }

    //----------デバッグ用----------
    public void DebugGetCroquette() {
        this.flagGetCroquetteMz00(this, EventArgs.Empty);
        this.mz00PlayerGetCroquette(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
    //--------------------
}