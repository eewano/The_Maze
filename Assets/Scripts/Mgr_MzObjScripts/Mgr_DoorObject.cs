using System;
using UnityEngine;

public class Mgr_DoorObject : MonoBehaviour {

    public int keyItemCount;

    void Start() {
        keyItemCount = 0;
    }

    void Update() {
        if (Input.GetKeyUp("z"))
        {
            DebugGetItemKey();
        }
    }

    public void ChangeItemKeyCount(object o, int i) {
        keyItemCount += i;
    }

    void DebugGetItemKey() {
        keyItemCount += 1;
    }
}