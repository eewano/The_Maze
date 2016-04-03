using UnityEngine;
using System.Collections;

public class Mz03FloorCreator : MonoBehaviour {

    public GameObject prefab = null;

    void Awake()
    {
        for(int i = 0; i < 28; i++)
        {
            for(int j = 0; j < 56; j += 2)
            {
                GameObject mzFloor = Instantiate(prefab) as GameObject;
                mzFloor.transform.position = new Vector3(
                        -27.0f + j,
                        -0.25f,
                        27.0f - (2 * i));
            }
        }
    }
}
