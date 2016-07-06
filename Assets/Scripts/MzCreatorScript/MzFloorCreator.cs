using UnityEngine;

public class MzFloorCreator : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int xNumber;
    [SerializeField]
    private int zNumber;
    [SerializeField]
    private GameObject mzFloorContainer;

    [SerializeField]
    private bool isFloor = true;

    void Awake() {
        float floorWidth = this.prefab.transform.localScale.x;
        float floorDepth = this.prefab.transform.localScale.z;

        float floorLeftEdge = -1 * this.xNumber / 2 * floorWidth + (floorWidth / 2);
        float floorDepthEdge = -1 * this.zNumber / 2 * floorDepth + (floorDepth / 2);

        for (int x = 0; x < this.xNumber; x++) {
            for (int z = 0; z < this.zNumber; z++) {
                GameObject mzFloor = (GameObject)Instantiate(prefab);

                float y;

                if (this.isFloor)
                {
                    y = -0.25f;
                }
                else
                {
                    y = 2.25f;
                }
                mzFloor.transform.position = new Vector3(
                        floorLeftEdge + (x * floorWidth),
                        y,
                        floorDepthEdge + (z * floorDepth)
                );

                mzFloor.gameObject.transform.SetParent(this.mzFloorContainer.transform);
            }
        }
    }
}

/*
void Awake()
    {
        float floorWidth = this.prefab.transform.localScale.x;
        float floorDepth = this.prefab.transform.localScale.z;

        float floorLeftEdge = -1 * this.xNumber / 2 * floorWidth + (floorWidth / 2);
        float floorDepthEdge =  this.zNumber / 2 * floorDepth - (floorDepth / 2);

        for(int x = 0; x < this.xNumber; x++)
        {
            for(int z = 0; z < this.zNumber; z++)
            {
                GameObject mzFloor = (GameObject)Instantiate(prefab);

                float y;
                if(this.isFloor){
                    y = -0.25f;
                }else{
                    y = 2.25f;
                }
                mzFloor.transform.position = new Vector3(
                        floorLeftEdge + (x * floorWidth),
                        y,
                        floorDepthEdge - (z * floorDepth)
                );

                mzFloor.gameObject.transform.SetParent(this.mzFloorContainer.transform);
            }
        }
    }
 */
