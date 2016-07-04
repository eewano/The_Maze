using UnityEngine;

public class Mgr_SpotCroquette : MonoBehaviour {

    [SerializeField]
    private Light spotCroquette;

    void Start() {
        spotCroquette.range = 0.0f;
        spotCroquette.intensity = 0.0f;
    }

    public void ChangeSpotLight(object o, float i) {
        spotCroquette.range = i;
        spotCroquette.intensity = i;
    }
}
