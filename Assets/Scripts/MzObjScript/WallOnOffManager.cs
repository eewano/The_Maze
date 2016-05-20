using UnityEngine;
using System.Collections;

public class WallOnOffManager : MonoBehaviour {

    public static bool WallOn = false;
    public static bool WallOff = false;

    [SerializeField]
    private GameObject OnOffWall;

    void Start() {
        WallOn = false;
        WallOff = false;
        OnOffWall.gameObject.SetActive(true);
    }

    void Update() {
        if (WallOn) {
            OnOffWall.gameObject.SetActive(true);
        } else if (WallOff) {
            OnOffWall.gameObject.SetActive(false);
        }
    }
}