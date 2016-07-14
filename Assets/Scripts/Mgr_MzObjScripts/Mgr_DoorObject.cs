using System;
using UnityEngine;

public class Mgr_DoorObject : MonoBehaviour {

    private Door01Open door01Open;

    private event EveHandItemKeyValue upKeyItemValue;

    private event EveHandItemKeyValue downKeyItemValue;

    void Awake() {
        door01Open = GameObject.Find("OpenPoint").GetComponent<Door01Open>();
    }

    void Start() {
        upKeyItemValue = new EveHandItemKeyValue(door01Open.ChangeKeyItemValue01);
        downKeyItemValue = new EveHandItemKeyValue(door01Open.ChangeKeyItemValue01);
    }

    void Update() {
        if (Input.GetKeyUp("z"))
        {
            DebugGetItemKey();
        }
    }

    public void GetItemKey(object o, EventArgs e) {
        this.upKeyItemValue(this, 1);
    }

    public void LostItemKey(object o, EventArgs e) {
        this.downKeyItemValue(this, -1);
    }

    void DebugGetItemKey() {
        this.upKeyItemValue(this, 1);
    }
}