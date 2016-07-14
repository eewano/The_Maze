using System;
using UnityEngine;

public class Door01Open : MonoBehaviour {

    private Animator animator;
    private Mgr_DoorObject mgrDoorObject;
    private Mgr_GameSE02 mgrGameSE02;
    private DeleteLock deleteLock;

    private event EveHandPLAYSE playSE;

    private event EveHandItemKey unLockObj;

    private event EveHandItemKeyValue lostItemKey;

    void Awake() {
        animator = GetComponent<Animator>();
        mgrGameSE02 = GameObject.Find("Mgr_GameSE02").GetComponent<Mgr_GameSE02>();
        mgrDoorObject = GameObject.Find("Mgr_DoorObject").GetComponent<Mgr_DoorObject>();
        deleteLock = gameObject.transform.FindChild("LockObj").GetComponent<DeleteLock>();
    }

    void Start() {
        unLockObj += new EveHandItemKey(deleteLock.ObjectUnLock);
        playSE += new EveHandPLAYSE(mgrGameSE02.SEDoor01OpenEvent);
        lostItemKey += new EveHandItemKeyValue(mgrDoorObject.ChangeItemKeyCount);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player" && mgrDoorObject.keyItemCount > 0)
        {
            this.unLockObj(this, EventArgs.Empty);
            this.playSE(this, EventArgs.Empty);
            DoorOpen("DoorOpen");
        }
    }

    void DoorOpen(string direction) {
        animator.SetTrigger(direction);
        animator.SetBool("DoorOpened", true);
        this.lostItemKey(this, -1);
    }
}