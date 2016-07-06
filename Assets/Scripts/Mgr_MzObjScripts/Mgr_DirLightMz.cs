using UnityEngine;

public class Mgr_DirLightMz : MonoBehaviour {

    [SerializeField]
    private Light dirLightMz;

    void Start() {
        dirLightMz.intensity = 0;
    }

    public void ChangeIntensityOfMz(object o, float i) {
        dirLightMz.intensity = i;
    }
}