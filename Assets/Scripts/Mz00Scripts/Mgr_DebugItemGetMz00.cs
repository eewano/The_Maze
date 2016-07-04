using UnityEngine;
using UnityEngine.UI;

public class Mgr_DebugItemGetMz00 : MonoBehaviour {

    [SerializeField]
    private Text debugItemGetText;
    [SerializeField]
    private Mgr_ItemLightMz00 mgrItemLightMz00;
    [SerializeField]
    private Mgr_ItemCroquetteMz00 mgrItemCroquetteMz00;
    [SerializeField]
    private Mgr_ItemMapMz00 mgrItemMapMz00;

    private bool debugItemGetMz00;

    void Start() {
        debugItemGetMz00 = false;
        debugItemGetText.text = "";
    }

    void Update() {
        DebugSwitch();
        DebugGetItem();
    }

    void DebugSwitch() {
        if (Input.GetKeyUp("i") && debugItemGetMz00 == false) {
            Debug.Log("DebugItemGetON");
            debugItemGetMz00 = true;
            debugItemGetText.text = "デバッグアイテム";
        }
        else if (Input.GetKeyUp("i") && debugItemGetMz00 == true) {
            Debug.Log("DebugItemGetOFF");
            debugItemGetMz00 = false;
            debugItemGetText.text = "";
        }
    }

    void DebugGetItem() {
        if (Input.GetKeyUp("l") && debugItemGetMz00 == true && mgrItemLightMz00 != null) {
            Debug.Log("LightGet");
            mgrItemLightMz00.DebugGetLight();
        }
        else if (Input.GetKeyUp("c") && debugItemGetMz00 == true && mgrItemCroquetteMz00 != null) {
            Debug.Log("CroquetteGet");
            mgrItemCroquetteMz00.DebugGetCroquette();
        }
        else if (Input.GetKeyUp("m") && debugItemGetMz00 == true && mgrItemMapMz00 != null) {
            Debug.Log("MapGet");
            mgrItemMapMz00.DebugGetMap();
        }
    }
}