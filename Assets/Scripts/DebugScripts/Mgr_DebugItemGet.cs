using UnityEngine;
using UnityEngine.UI;

public class Mgr_DebugItemGet : MonoBehaviour {

    [SerializeField]
    private Text debugItemGetText;
    private Mgr_ItemLight mgrItemLight;
    private Mgr_ItemCroquette mgrItemCroquette;
    private Mgr_ItemMap mgrItemMap;

    private bool debugItemGet;

    void Start() {
        mgrItemLight = GameObject.FindWithTag("Light").GetComponent<Mgr_ItemLight>();
        mgrItemCroquette = GameObject.FindWithTag("Croquette").GetComponent<Mgr_ItemCroquette>();
        mgrItemMap = GameObject.FindWithTag("Map").GetComponent<Mgr_ItemMap>();
        debugItemGet = false;
        debugItemGetText.text = "";
    }

    void Update() {
        DebugSwitch();
        DebugGetItem();
    }

    void DebugSwitch() {
        if (Input.GetKeyUp("i") && debugItemGet == false) {
            Debug.Log("DebugItemGetON");
            debugItemGet = true;
            debugItemGetText.text = "デバッグアイテム";
        }
        else if (Input.GetKeyUp("i") && debugItemGet == true) {
            Debug.Log("DebugItemGetOFF");
            debugItemGet = false;
            debugItemGetText.text = "";
        }
    }

    void DebugGetItem() {
        if (Input.GetKeyUp("l") && debugItemGet == true && mgrItemLight != null) {
            Debug.Log("LightGet");
            mgrItemLight.DebugGetLight();
        }
        else if (Input.GetKeyUp("c") && debugItemGet == true && mgrItemCroquette != null) {
            Debug.Log("CroquetteGet");
            mgrItemCroquette.DebugGetCroquette();
        }
        else if (Input.GetKeyUp("m") && debugItemGet == true && mgrItemMap != null) {
            Debug.Log("MapGet");
            mgrItemMap.DebugGetMap();
        }
    }
}