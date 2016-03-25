using UnityEngine;
using System.Collections;

public class Mz02FloorCreator : MonoBehaviour {

	public GameObject prefab = null;

    void Awake()
    {
        for(int i = 0; i < 24; i++)
        {
            for(int j = 0; j < 48; j += 2)
            {
                GameObject mzFloor = Instantiate(prefab) as GameObject;
                mzFloor.transform.position = new Vector3(
                        -23.0f + j,
                        -0.25f,
                        23.0f - (2 * i));
            }
        }
    }
}
