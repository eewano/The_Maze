using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzItem01 : MonoBehaviour {

    [SerializeField]
    private LightBallMapLight lightBallMapLight;
    [SerializeField]
    private CroquetteMapLight croquetteMapLight;

    private event EveHandMgrState mzItem01MapPLAYING;

    private event EveHandMgrState mzItem01MapMAP;

    private event EveHandMgrState mzItem01MapEMPTY;

    void Awake() {
        lightBallMapLight = GameObject.Find("LightBall").GetComponent<LightBallMapLight>();
        croquetteMapLight = GameObject.Find("Dish").GetComponent<CroquetteMapLight>();
    }

    void Start() {
        //PLAYINGステート
        mzItem01MapPLAYING += new EveHandMgrState(lightBallMapLight.MapFigureLightOff);
        mzItem01MapPLAYING += new EveHandMgrState(croquetteMapLight.MapFigureLightOff);
        //MAPステート
        mzItem01MapMAP += new EveHandMgrState(lightBallMapLight.MapFigureLightOn);
        mzItem01MapMAP += new EveHandMgrState(croquetteMapLight.MapFigureLightOn);
        //EMPTYステート
        mzItem01MapEMPTY += new EveHandMgrState(lightBallMapLight.MapFigureLightOff);
        mzItem01MapEMPTY += new EveHandMgrState(croquetteMapLight.MapFigureLightOff);
    }

    public void EventPLAYING(object o, EventArgs e) {
        this.mzItem01MapPLAYING(this, EventArgs.Empty);
    }

    public void EventMAP(object o, EventArgs e) {
        this.mzItem01MapMAP(this, EventArgs.Empty);
    }

    public void EventEMPTY(object o, EventArgs e) {
        this.mzItem01MapEMPTY(this, EventArgs.Empty);
    }
}