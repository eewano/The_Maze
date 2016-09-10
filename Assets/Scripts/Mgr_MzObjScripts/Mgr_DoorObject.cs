using System;
using UnityEngine;

public class Mgr_DoorObject : MonoBehaviour {

    public int keyDoor01Count;
    [SerializeField]
    private Mgr_KeyIcon mgrKeyIcon;

    void Start() {
        keyDoor01Count = 0;
    }

    void Update() {
        if (Input.GetKeyUp("z"))
        {
            DebugGetItemKey();
        }
        mgrKeyIcon.UpdateKeyValue(keyDoor01Count);
    }

    public void ChangeItemKeyCount(object o, int i) {
        keyDoor01Count += i;
    }

    void DebugGetItemKey() {
        keyDoor01Count += 1;
    }
}