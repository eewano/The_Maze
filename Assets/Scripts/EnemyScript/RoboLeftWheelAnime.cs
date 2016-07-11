using UnityEngine;

public class RoboLeftWheelAnime : MonoBehaviour {

    void Update() {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}