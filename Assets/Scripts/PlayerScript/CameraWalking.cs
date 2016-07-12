using System;
using System.Collections;
using UnityEngine;

public class CameraWalking : MonoBehaviour {

    [SerializeField]
    private float stepHeight;
    private float minHeight = 0.0f;
    private CameraSEWalk cameraSEWalk;

    private event EveHandToPlayer cameraToWalk;

    void Awake() {
        cameraSEWalk = GameObject.Find("MzCamPlayer").GetComponent<CameraSEWalk>();
    }

    void Start() {
        cameraToWalk = new EveHandToPlayer(cameraSEWalk.StartWalkingSE);
    }

    void Update() {
        if (transform.position.y <= minHeight)
        {
            transform.Translate(0, minHeight, 0);
        }
    }

    public void PlayerWalking(object o, EventArgs e) {
        StartCoroutine(CameraUp());
    }

    IEnumerator CameraUp() {
        this.cameraToWalk(this, EventArgs.Empty);
        transform.Translate(0, -stepHeight, 0);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(0, stepHeight, 0);
    }
}