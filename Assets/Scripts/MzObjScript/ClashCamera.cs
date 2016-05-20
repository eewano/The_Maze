using UnityEngine;
using System.Collections;

public class ClashCamera : MonoBehaviour {

    public void Clash() {
        GetComponent<Animator>().SetTrigger("Shake");
    }

    void Update() {
        if (Input.GetKeyDown("h")) {
            GetComponent<Animator>().SetTrigger("Shake");
        }
    }
}