using System;
using UnityEngine;

public class Mgr_DoorObject : MonoBehaviour {

    public int keyDoor01Count;

    void Start() {
        keyDoor01Count = 0;
    }

    void Update() {
        if (Input.GetKeyUp("z"))
        {
            DebugGetItemKey();
        }
    }

    public void ChangeItemKeyCount(object o, int i) {
        keyDoor01Count += i;
    }

    void DebugGetItemKey() {
        keyDoor01Count += 1;
    }
}