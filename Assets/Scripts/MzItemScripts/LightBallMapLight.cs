using System;
using UnityEngine;

public class LightBallMapLight : MonoBehaviour {

    private Light lightBallMap;

    void Start() {
        lightBallMap = GetComponent<Light>();
    }

    public void MapFigureLightOn(object o, EventArgs e) {
        lightBallMap.range = 5;
        lightBallMap.intensity = 5;
        lightBallMap.color = new Color32(255, 255, 0, 128);
    }

    public void MapFigureLightOff(object o, EventArgs e) {
        lightBallMap.range = 0;
        lightBallMap.intensity = 0;
        lightBallMap.color = new Color32(0, 0, 0, 0);
    }
}