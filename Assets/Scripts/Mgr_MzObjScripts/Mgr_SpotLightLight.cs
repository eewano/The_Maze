using UnityEngine;

public class Mgr_SpotLightLight : MonoBehaviour {

    [SerializeField]
    private Light spotLight;

    void Start() {
        spotLight.range = 0.0f;
        spotLight.intensity = 0.0f;
    }

    public void ChangeSpotLight(object o, float i) {
        spotLight.range = i;
        spotLight.intensity = i;
    }
}
