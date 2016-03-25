using UnityEngine;
using System.Collections;

public class Mz00WallCreator : MonoBehaviour {

    public GameObject prefab = null;

    void Awake()
    {
        Instantiate(this.prefab, new Vector3(-11, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 11), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 9), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 7), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, 5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 5), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 3), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, 1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 1), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -1), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -3), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -5), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -7), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -9), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-11, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -11), Quaternion.identity);
    }
}
