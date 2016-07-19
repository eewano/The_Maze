using System;
using UnityEngine;

public class MzWarpPoint : MonoBehaviour {

    [SerializeField]
    private float posX;
    [SerializeField]
    private float posZ;
    private float posY = 0.5f;
    private Mgr_PlayerWarp mgrPlayerWarp;
    private Mgr_GameSE02 mgrGameSE02;

    private event EveHandPLAYSE playWarpSE;

    void Awake() {
        mgrPlayerWarp = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerWarp>();
        mgrGameSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Mgr_GameSE02>();
    }

    void Start() {
        playWarpSE = new EveHandPLAYSE(mgrGameSE02.SEWarpEvent);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            this.playWarpSE(this, EventArgs.Empty);
            mgrPlayerWarp.WarpStartTo(posX, posY, posZ);
        }
    }
}