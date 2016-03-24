using UnityEngine;
using System.Collections;

public class Mz01CeilingCreator : MonoBehaviour {

    public GameObject prefab = null;

    void Awake()
    {
        for(int i = 0; i < 22; i++)
        {
            for(int j = 0; j < 44; j += 2)
            {
                GameObject mzCeiling = Instantiate(prefab) as GameObject;
                mzCeiling.transform.position = new Vector3(
                        -21.0f + j,
                        2.25f,
                        21.0f - (2 * i));
            }
        }
    }
}
