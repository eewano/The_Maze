using System;
using UnityEngine;

public class CroquetteMapLight : MonoBehaviour {

    private Light croquetteMap;

    void Start() {
        croquetteMap = GetComponent<Light>();
    }

    public void MapFigureLightOn(object o, EventArgs e) {
        croquetteMap.range = 5;
        croquetteMap.intensity = 5;
        croquetteMap.color = new Color32(0, 255, 0, 128);
    }

    public void MapFigureLightOff(object o, EventArgs e) {
        croquetteMap.range = 0;
        croquetteMap.intensity = 0;
        croquetteMap.color = new Color32(0, 0, 0, 0);
    }
}