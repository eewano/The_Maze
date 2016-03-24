using UnityEngine;
using System.Collections;

public class Mz01WallCreator : MonoBehaviour {

    public GameObject prefab = null;

    void Awake()
    {
        GameObject mzWall = Instantiate(prefab) as GameObject;
        mzWall.transform.position = new Vector3(-21.0f, 1.0f, 21.0f);
    }
}
