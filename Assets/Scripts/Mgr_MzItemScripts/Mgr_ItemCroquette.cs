using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_ItemCroquette : MonoBehaviour {

    private ManagerPlayerMaster managerPlayerMaster;
    private Mgr_MzLabelCroquetteGet mgrMzLabelCroquetteGet;
    private Mgr_GameSE01 mgrGameSE01;

    private event EveHandFlagItem flagGetCroquette;

    private event EveHandToPlayer playerGetCroquette;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        mgrMzLabelCroquetteGet = GameObject.Find("Mgr_MzLabel").GetComponent<Mgr_MzLabelCroquetteGet>();
        mgrGameSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
    }

    void Start() {
        flagGetCroquette += new EveHandFlagItem(mgrMzLabelCroquetteGet.AppearLabelEvent);
        flagGetCroquette += new EveHandFlagItem(mgrGameSE01.SEGetCroquetteEvent);
        playerGetCroquette += new EveHandToPlayer(managerPlayerMaster.PlayerGetCroquette);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagGetCroquette(this, EventArgs.Empty);
            this.playerGetCroquette(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }

    //----------デバッグ用----------
    public void DebugGetCroquette() {
        this.flagGetCroquette(this, EventArgs.Empty);
        this.playerGetCroquette(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
    //--------------------
}