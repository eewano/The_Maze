using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject item;

    void Start() {
        Instantiate(item, transform.position, transform.rotation);
    }
}