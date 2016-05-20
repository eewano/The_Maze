﻿using UnityEngine;
using System.Collections;

public class MapFigure : MonoBehaviour {

    Light itemLight;

    void Start() {
        itemLight = GetComponent<Light>();
    }

    void Update() {
        if (GameManager.MapModeON == true && GameManager.MapModeOFF == false) {
            itemLight.range = 5;
            itemLight.intensity = 5;
            if (gameObject.tag == "Light") {
                itemLight.color = Color.yellow;
            } else if (gameObject.tag == "Croquette") {
                itemLight.color = new Color(0f / 255f, 255f / 255f, 0f / 255f, 128f / 255f);
            }
        }
        else if (GameManager.MapModeON == false && GameManager.MapModeOFF == true) {
            itemLight.range = 0;
            itemLight.intensity = 0;
        }
    }
}