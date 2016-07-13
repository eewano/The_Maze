using UnityEngine;

public class Door01Open : MonoBehaviour {

    private Animator animator;

    private bool doorOpen;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Start() {
        doorOpen = false;
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player" && doorOpen == false)
        {
            DoorOpen("DoorOpen");
        }
    }

    void DoorOpen(string direction) {
        animator.SetTrigger(direction);
        doorOpen = true;
    }
}
