using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_MzItem01 : MonoBehaviour {

//    private LightBallMapLight lightBallMapLight;
//    private CroquetteMapLight croquetteMapLight;
//
//    private event EveHandMgrState mzItem01MapPLAYING;
//
//    private event EveHandMgrState mzItem01MapMAP;
//
//    private event EveHandMgrState mzItem01MapEMPTY;
//
//    void Awake() {
//    }
//
//    void Start() {
//        lightBallMapLight = GameObject.FindWithTag("Light").GetComponent<LightBallMapLight>();
//        croquetteMapLight = GameObject.FindWithTag("Dish").GetComponent<CroquetteMapLight>();
//        //PLAYINGステート
//        mzItem01MapPLAYING += new EveHandMgrState(lightBallMapLight.MapFigureLightOff);
//        mzItem01MapPLAYING += new EveHandMgrState(croquetteMapLight.MapFigureLightOff);
//        //MAPステート
//        mzItem01MapMAP += new EveHandMgrState(lightBallMapLight.MapFigureLightOn);
//        mzItem01MapMAP += new EveHandMgrState(croquetteMapLight.MapFigureLightOn);
//        //EMPTYステート
//        mzItem01MapEMPTY += new EveHandMgrState(lightBallMapLight.MapFigureLightOff);
//        mzItem01MapEMPTY += new EveHandMgrState(croquetteMapLight.MapFigureLightOff);
//    }
//
//    public void EventPLAYING(object o, EventArgs e) {
//        this.mzItem01MapPLAYING(this, EventArgs.Empty);
//    }
//
//    public void EventMAP(object o, EventArgs e) {
//        this.mzItem01MapMAP(this, EventArgs.Empty);
//    }
//
//    public void EventEMPTY(object o, EventArgs e) {
//        this.mzItem01MapEMPTY(this, EventArgs.Empty);
//    }
}