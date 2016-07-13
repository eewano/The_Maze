using UnityEngine;

public class Mgr_PlayerWarp : MonoBehaviour {

    public void WarpStartTo(float x, float y, float z) {
        transform.position = new Vector3(x, y, z);
    }
}