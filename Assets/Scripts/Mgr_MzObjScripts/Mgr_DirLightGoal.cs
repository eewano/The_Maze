using UnityEngine;

public class Mgr_DirLightGoal : MonoBehaviour {

    [SerializeField]
    private Light dirLightGoal;

    void Start() {
        dirLightGoal.intensity = 0.0f;
    }

    public void ChangeIntensityOfGoal(object o, float i) {
        dirLightGoal.intensity = i;
    }
}
