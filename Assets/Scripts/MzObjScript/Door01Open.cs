using System;
using UnityEngine;

public class Door01Open : MonoBehaviour {

    private Animator animator;
    private Mgr_DoorObject mgrDoorObject;
    private Mgr_GameSE02 mgrGameSE02;
    private DeleteLock deleteLock;

    private bool doorOpen = false;

    private event EveHandPLAYSE playSE;

    private event EveHandItemKey unlockObj;

    private event EveHandItemKeyValue lostItemKey;

    void Awake() {
        animator = GetComponent<Animator>();
        mgrGameSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Mgr_GameSE02>();
        mgrDoorObject = GameObject.Find("Mgr_DoorObject").GetComponent<Mgr_DoorObject>();
        deleteLock = gameObject.transform.FindChild("LockObj").GetComponent<DeleteLock>();
    }

    void Start() {
        unlockObj += new EveHandItemKey(deleteLock.ObjectUnLock);
        unlockObj += new EveHandItemKey(mgrGameSE02.SEDoor01UnlockEvent);
        playSE += new EveHandPLAYSE(mgrGameSE02.SEDoor01OpenEvent);
        lostItemKey += new EveHandItemKeyValue(mgrDoorObject.ChangeItemKeyCount);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player" && doorOpen == false && mgrDoorObject.keyDoor01Count > 0)
        {
            this.unlockObj(this, EventArgs.Empty);
            DoorOpen("DoorOpen");
        }
    }

    void DoorOpen(string direction) {
        animator.SetTrigger(direction);
        animator.SetBool("DoorOpened", true);
        this.lostItemKey(this, -1);
        doorOpen = true;
    }

    void DoorOpenSE() {
        this.playSE(this, EventArgs.Empty);
    }
}