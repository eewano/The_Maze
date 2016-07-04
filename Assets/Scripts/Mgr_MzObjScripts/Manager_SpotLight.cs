﻿using System;
using UnityEngine;

public class Manager_SpotLight : MonoBehaviour {

    private Mgr_SpotLightLight mgrSpotLightLight;
    private Mgr_SpotCroquette mgrSpotCroquette;

    private event EveHandSpotLight changeSpotLight;

    private event EveHandSpotLight changeSpotCroquette;

    void Awake() {
        mgrSpotLightLight = GameObject.Find("Mgr_SpotLight").GetComponent<Mgr_SpotLightLight>();
        mgrSpotCroquette = GameObject.Find("Mgr_SpotLight").GetComponent<Mgr_SpotCroquette>();
    }

    void Start() {
        changeSpotLight += new EveHandSpotLight(mgrSpotLightLight.ChangeSpotLight);
        changeSpotCroquette += new EveHandSpotLight(mgrSpotCroquette.ChangeSpotLight);
    }

    public void EventPLAYINGSpotLight(object o, EventArgs e) {
        this.changeSpotLight(this, 0.0f);
    }

    public void EventPLAYINGSpotCroq(object o, EventArgs e) {
        this.changeSpotCroquette(this, 0.0f);
    }

    public void EventMAPSpotLight(object o, EventArgs e) {
        this.changeSpotLight(this, 5.0f);
    }

    public void EventMAPSpotCroq(object o, EventArgs e) {
        this.changeSpotCroquette(this, 5.0f);
    }
}