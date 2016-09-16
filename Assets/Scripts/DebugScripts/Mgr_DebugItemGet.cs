using System;
using UnityEngine;

public class Mgr_DebugItemGet : MonoBehaviour {

    private Mgr_ItemLight mgrItemLight;
    private Mgr_ItemCroquette mgrItemCroquette;
    private Mgr_ItemMap mgrItemMap;

    private bool debugItemON = false;

    void Start() {
        mgrItemLight = GameObject.FindWithTag("Light").GetComponent<Mgr_ItemLight>();
        mgrItemCroquette = GameObject.FindWithTag("Croquette").GetComponent<Mgr_ItemCroquette>();
        mgrItemMap = GameObject.FindWithTag("Map").GetComponent<Mgr_ItemMap>();
    }

    void OnGUI() {
        float guiPosX = 10.0f;
        float guiPosY = 10.0f;
        float guiPosYAdjust = 0.0f;
        float width = 120.0f;

        if (debugItemON == true)
        {
            if (GUI.Button(new Rect(guiPosX, guiPosY + guiPosYAdjust, width, 16), "ライトゲット"))
            {
                if (mgrItemLight != null)
                {
                    mgrItemLight.DebugGetLight();
                }
            }

            guiPosYAdjust += 16.0f;
            if (GUI.Button(new Rect(guiPosX, guiPosY + guiPosYAdjust, width, 16), "コロッケゲット"))
            {
                if (mgrItemCroquette != null)
                {
                    mgrItemCroquette.DebugGetCroquette();
                }
            }

            guiPosYAdjust += 16.0f;
            if (GUI.Button(new Rect(guiPosX, guiPosY + guiPosYAdjust, width, 16), "マップゲット"))
            {
                if (mgrItemMap != null)
                {
                    mgrItemMap.DebugGetMap();
                }
            }
        }
    }

    public void DebugModeON(object o, EventArgs e) {
        debugItemON = true;
    }

    public void DebugModeOFF(object o, EventArgs e) {
        debugItemON = false;
    }
}