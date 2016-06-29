using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mgr_DebugItemGet : MonoBehaviour {

    [SerializeField]
    private Text debugItemGetText;
    [SerializeField]
    private Mgr_ItemLight mgrItemLight;
    [SerializeField]
    private Mgr_ItemCroquette mgrItemCroquette;
    [SerializeField]
    private Mgr_ItemMap mgrItemMap;

    private bool debugItemGet;

    void Awake() {
//        mgrItemLight = GameObject.Find("LightBall").GetComponent<Mgr_ItemLight>();
//        mgrItemCroquette = GameObject.Find("Dish").GetComponent<Mgr_ItemCroquette>();
//        mgrItemMap = GameObject.Find("MapCrystal").GetComponent<Mgr_ItemMap>();
    }

    void Start() {
        debugItemGet = false;
        debugItemGetText.text = "";
    }

    void Update() {
        DebugSwitch();
        DebugGetItem();
    }

    void DebugSwitch() {
        if (Input.GetKeyUp("i") && debugItemGet == false) {
            debugItemGet = true;
            debugItemGetText.text = "デバッグアイテム取得";
        }
        else if (Input.GetKeyUp("i") && debugItemGet == true) {
            debugItemGet = false;
            debugItemGetText.text = "";
        }
    }

    void DebugGetItem() {
        if (Input.GetKeyUp("l") && debugItemGet == true) {
            mgrItemLight.DebugGetLight();
        }
        else if (Input.GetKeyUp("c") && debugItemGet == true) {
            mgrItemCroquette.DebugGetCroquette();
        }
        else if (Input.GetKeyUp("m") && debugItemGet == true) {
            mgrItemMap.DebugGetMap();
        }
    }
}