using UnityEngine;

public class RoboRightWheelAnime : MonoBehaviour {

    void Update() {
        transform.Rotate(0, -90 * Time.deltaTime, 0);
    }
}