using System;
using UnityEngine;

public class Mgr_GameSE01 : MonoBehaviour {

    private AudioSource
    sEEnter, sECancel, sEReadyGo, sETimeUp, sElightGet, sECroquetteGet, sEMapGet, sECountDown;

    void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sEEnter = audioSources[0];
        sECancel = audioSources[1];
        sEReadyGo = audioSources[2];
        sETimeUp = audioSources[3];
        sElightGet = audioSources[4];
        sECroquetteGet = audioSources[5];
        sEMapGet = audioSources[6];
        sECountDown = audioSources[7];
    }

    public void SEReadyGoEvent(object o, EventArgs e) {
        sEReadyGo.PlayOneShot(sEReadyGo.clip);
    }

    public void SEEnterEvent(object o, EventArgs e) {
        sEEnter.PlayOneShot(sEEnter.clip);
    }

    public void SECancelEvent(object o, EventArgs e) {
        sECancel.PlayOneShot(sECancel.clip);
    }

    public void SEGetLightEvent(object o, EventArgs e) {
        sElightGet.PlayOneShot(sElightGet.clip);
    }

    public void SEGetCroquetteEvent(object o, EventArgs e) {
        sECroquetteGet.PlayOneShot(sECroquetteGet.clip);
    }

    public void SEGetMapEvent(object o, EventArgs e) {
        sEMapGet.PlayOneShot(sEMapGet.clip);
    }

    public void SETimeUpEvent(object o, EventArgs e) {
        sETimeUp.PlayOneShot(sETimeUp.clip);
    }

    public void SECountDownEvent(object o, EventArgs e) {
        sECountDown.PlayOneShot(sECountDown.clip);
    }
}