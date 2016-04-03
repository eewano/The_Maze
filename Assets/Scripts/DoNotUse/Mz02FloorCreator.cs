using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mz02FloorCreator : MonoBehaviour {

	public GameObject prefab = null;

    [SerializeField]
    private GameObject stage2FloorContainer;

    void Awake()
    {
        for(int i = 0; i < 24; i++)
        {
            for(int j = 0; j < 48; j += 2)
            {
                GameObject mzFloor = (GameObject)Instantiate(prefab);

                // set parent
//                mzFloor.gameObject.transform.SetParent(this.stage2FloorContainer.transform);

                mzFloor.transform.position = new Vector3(
                        -23.0f + j,
                        -0.25f,
                        23.0f - (2 * i));
            }
        }
    }
}
