using System;
using UnityEngine;

public class Mgr_MzSE02 : MonoBehaviour {

    private AudioSource
    sEEnemyTouch01, sEGoal01, sEShutter01;

    void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sEEnemyTouch01 = audioSources[0];
        sEGoal01 = audioSources[1];
        sEShutter01 = audioSources[2];
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
}