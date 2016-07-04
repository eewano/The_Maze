using UnityEngine;

public class Mgr_DirLightMap : MonoBehaviour {

    [SerializeField]
    private Light dirLightMap;

    void Start() {
        dirLightMap.intensity = 0.0f;
    }

    public void ChangeIntensityOfMap(object o, float i) {
        dirLightMap.intensity = i;
    }
}