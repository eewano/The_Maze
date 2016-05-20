using UnityEngine;
using System.Collections;

public class WallOff : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            WallOnOffManager.WallOn = false;
            WallOnOffManager.WallOff = true;
        }
    }
}