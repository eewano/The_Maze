using UnityEngine;
using System.Collections;

public class WallOn : MonoBehaviour {

    MzSoundEffect mzSoundEffect;

    void Start() {
        mzSoundEffect = GameObject.Find("MzSoundEffect").GetComponent<MzSoundEffect>();
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            if (WallOnOffManager.WallOn == false && WallOnOffManager.WallOff == true) {
                mzSoundEffect.ShutterSound();
                Camera.main.SendMessage("Clash");
            }
            WallOnOffManager.WallOn = true;
            WallOnOffManager.WallOff = false;
        }
    }
}