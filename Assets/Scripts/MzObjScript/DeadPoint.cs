using UnityEngine;
using System.Collections;

public class DeadPoint : MonoBehaviour {

    GameObject gameManager;

    void Start() {
        gameManager = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            gameManager.SendMessage("Failure");
        }
    }
}