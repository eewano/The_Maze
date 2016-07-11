﻿using System;
using UnityEngine;

public class Mgr_GameSEFoot : MonoBehaviour {

    private AudioSource
    sEMz00Walk, sEMz01Walk, sEMz02Walk;

    void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sEMz00Walk = audioSources[0];
        sEMz01Walk = audioSources[1];
        sEMz02Walk = audioSources[2];
    }

    public void SEMz00WalkEvent(object o, EventArgs e) {
        sEMz00Walk.PlayOneShot(sEMz00Walk.clip);
    }

    public void SEMz01WalkEvent(object o, EventArgs e) {
        sEMz01Walk.PlayOneShot(sEMz01Walk.clip);
    }

    public void SEMz02WalkEvent(object o, EventArgs e) {
        sEMz02Walk.PlayOneShot(sEMz02Walk.clip);
    }
}