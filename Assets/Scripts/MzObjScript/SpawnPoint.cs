using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject item;

    void Awake() {
        Instantiate(item, transform.position, transform.rotation);
    }
}