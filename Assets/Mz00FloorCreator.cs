using UnityEngine;
using System.Collections;

public class Mz00FloorCreator : MonoBehaviour {

	public GameObject prefab = null;

    void Awake()
    {
        for(int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 24; j += 2)
            {
                GameObject mzFloor = Instantiate(prefab) as GameObject;
                mzFloor.transform.position = new Vector3(
                        -11.0f + j,
                        -0.25f,
                        11.0f - (2 * i));
            }
        }
    }
}
