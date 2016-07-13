using UnityEngine;

public class MzWarpPoint : MonoBehaviour {

    [SerializeField]
    private float posX;
    [SerializeField]
    private float posZ;
    private float posY = 0.5f;
    private Mgr_PlayerWarp mgrPlayerWarp;

    void Awake() {
        mgrPlayerWarp = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerWarp>();
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            mgrPlayerWarp.WarpStartTo(posX, posY, posZ);
        }
    }
}