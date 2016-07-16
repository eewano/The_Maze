using System;
using UnityEngine;

public class DeleteLock : MonoBehaviour {

    public void ObjectUnLock(object o, EventArgs e) {
        this.gameObject.SetActive(false);
    }
}