using System;
using UnityEngine;

public class Mgr_ItemKeyToWood : MonoBehaviour {

    private Mgr_DoorObject mgrDoorObject;
    private Mgr_GameSE02 mgrMzSE02;

    private event EveHandFlagItem flagKeyToWoodGet;

    private event EveHandItemKeyValue keyToWoodCountUp;

    void Awake() {
        mgrDoorObject = GameObject.Find("Mgr_DoorObject").GetComponent<Mgr_DoorObject>();
        mgrMzSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Mgr_GameSE02>();
    }

    void Start() {
        flagKeyToWoodGet += new EveHandFlagItem(mgrMzSE02.SEGetKeyToWoodEvent);
        keyToWoodCountUp += new EveHandItemKeyValue(mgrDoorObject.ChangeItemKeyCount);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.flagKeyToWoodGet(this, EventArgs.Empty);
            this.keyToWoodCountUp(this, 1);
            Destroy(this.gameObject);
        }
    }
}