using System;
using UnityEngine;

public class Mgr_GameSE02 : MonoBehaviour {

    private AudioSource
    sEEnemyTouch01, sEGoal01, sEShutter01, sEDoor01Open, sEGetKeyToWood, sEDoor01Unlock, sEWarp;

    void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sEEnemyTouch01 = audioSources[0];
        sEGoal01 = audioSources[1];
        sEShutter01 = audioSources[2];
        sEDoor01Open = audioSources[3];
        sEGetKeyToWood = audioSources[4];
        sEDoor01Unlock = audioSources[5];
        sEWarp = audioSources[6];
    }

    public void SEEnemyTouch01Event(object o, EventArgs e) {
        sEEnemyTouch01.PlayOneShot(sEEnemyTouch01.clip);
    }

    public void SEGoal01Event(object o, EventArgs e) {
        sEGoal01.PlayOneShot(sEGoal01.clip);
    }

    public void SEShutter01Event(object o, EventArgs e) {
        sEShutter01.PlayOneShot(sEShutter01.clip);
    }

    public void SEDoor01OpenEvent(object o, EventArgs e) {
        sEDoor01Open.PlayOneShot(sEDoor01Open.clip);
    }

    public void SEGetKeyToWoodEvent(object o, EventArgs e) {
        sEGetKeyToWood.PlayOneShot(sEGetKeyToWood.clip);
    }

    public void SEDoor01UnlockEvent(object o, EventArgs e) {
        sEDoor01Unlock.PlayOneShot(sEDoor01Unlock.clip);
    }

    public void SEWarpEvent(object o, EventArgs e) {
        sEWarp.PlayOneShot(sEWarp.clip);
    }
}