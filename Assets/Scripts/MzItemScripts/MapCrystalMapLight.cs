using System;
using UnityEngine;

public class MapCrystalMapLight : MonoBehaviour {

    private Light mapCrystalMap;

    void Start() {
        mapCrystalMap = GetComponent<Light>();
    }

    public void MapFigureLightOn(object o, EventArgs e) {
        mapCrystalMap.range = 5;
        mapCrystalMap.intensity = 5;
        mapCrystalMap.color = new Color32(0, 255, 0, 128);
    }

    public void MapFigureLightOff(object o, EventArgs e) {
        mapCrystalMap.range = 0;
        mapCrystalMap.intensity = 0;
        mapCrystalMap.color = new Color32(0, 0, 0, 0);
    }
}