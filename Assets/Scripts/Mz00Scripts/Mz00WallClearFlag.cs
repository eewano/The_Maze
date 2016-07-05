using System;
using UnityEngine;

public class Mz00WallClearFlag : MonoBehaviour {

    public void DeleteWall(object o, EventArgs e) {
        Destroy(this.gameObject);
    }
}