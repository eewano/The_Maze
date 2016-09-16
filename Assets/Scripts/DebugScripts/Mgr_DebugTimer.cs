using System;
using UnityEngine;

public class Mgr_DebugTimer : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    private Mgr_MzTextTimer mgrMzTextTimer;
    private bool debugTimerON = false;

    private event EventHandler timerReset;

    private event EventHandler timerTo10Second;

    void Awake() {
        mgrMzTextTimer = GameObject.Find("Mgr_MzTimer").GetComponent<Mgr_MzTextTimer>();
    }

    void Start() {
        timerReset += new EventHandler(mgrMzTextTimer.DebugTimerReset);
        timerTo10Second += new EventHandler(mgrMzTextTimer.DebugTimerTo10);
    }

    void OnGUI() {
        float guiPosX = 10.0f;
        float guiPosYAdjust = 0.0f;
        float width = 120.0f;

        if (debugTimerON == true)
        {
            if (GUI.Button(new Rect(guiPosX, 58 + guiPosYAdjust, width, 16), "タイマーリセット"))
            {
                this.timerReset(this, EventArgs.Empty);
            }

            guiPosYAdjust += 16.0f;
            if (GUI.Button(new Rect(guiPosX, 58 + guiPosYAdjust, width, 16), "10秒セット"))
            {
                this.timerTo10Second(this, EventArgs.Empty);
            }
        }
    }

    public void DebugModeON(object o, EventArgs e) {
        debugTimerON = true;
    }

    public void DebugModeOFF(object o, EventArgs e) {
        debugTimerON = false;
    }
}