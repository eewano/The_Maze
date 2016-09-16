using System;
using UnityEngine;

public class Mgr_DebugItemGetMz00 : MonoBehaviour {

    [SerializeField]
    private Mgr_ItemLightMz00 mgrItemLightMz00;
    [SerializeField]
    private Mgr_ItemCroquetteMz00 mgrItemCroquetteMz00;
    [SerializeField]
    private Mgr_ItemMapMz00 mgrItemMapMz00;

    private bool debugItemON = false;

    void OnGUI() {
        float guiPosX = 10.0f;
        float guiPosY = 10.0f;
        float guiPosYAdjust = 0.0f;
        float width = 120.0f;

        if (debugItemON == true)
        {
            if (GUI.Button(new Rect(guiPosX, guiPosY + guiPosYAdjust, width, 16), "ライトゲット"))
            {
                if (mgrItemLightMz00 != null)
                {
                    mgrItemLightMz00.DebugGetLight();
                }
            }

            guiPosYAdjust += 16.0f;
            if (GUI.Button(new Rect(guiPosX, guiPosY + guiPosYAdjust, width, 16), "コロッケゲット"))
            {
                if (mgrItemCroquetteMz00 != null)
                {
                    mgrItemCroquetteMz00.DebugGetCroquette();
                }
            }

            guiPosYAdjust += 16.0f;
            if (GUI.Button(new Rect(guiPosX, guiPosY + guiPosYAdjust, width, 16), "マップゲット"))
            {
                if (mgrItemMapMz00 != null)
                {
                    mgrItemMapMz00.DebugGetMap();
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