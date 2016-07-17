using UnityEngine;

public class KeyToWoodMove : MonoBehaviour {

    Vector3 startPosition;

    private float amplitude = 0.05f;
    private float speed = 5.0f;

    void Start() {
        startPosition = transform.localPosition;
    }

    void Update() {
        //変位を計算する。
        float y = amplitude * Mathf.Sin(Time.time * speed);

        //xを変位させたポジションに再設定する。
        transform.localPosition = startPosition + new Vector3(0, y, 0);

        transform.Rotate(0, 1, 0);
    }
}