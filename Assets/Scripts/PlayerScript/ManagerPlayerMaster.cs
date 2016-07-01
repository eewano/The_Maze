using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerPlayerMaster : MonoBehaviour {

    private Light playerSpotlight;
    private FootSound playerFootSound;
    private Mgr_PlayerBtnCtrl mgrPlayerBtnCtrl;
    private Mgr_GameSE01 mgrMzSE01;
    private FadeImage fadeWhite;

    private event EveHandDebug changeToCtrlBtn;
    private event EveHandDebug changeToCtrlKey;

    void Awake() {
        mgrPlayerBtnCtrl = GameObject.Find("Player").GetComponent<Mgr_PlayerBtnCtrl>();
        playerFootSound = GameObject.Find("Player").GetComponent<FootSound>();
        playerSpotlight = GameObject.Find("PlayerSpotlight").GetComponent<Light>();
        mgrMzSE01 = GameObject.Find("Mgr_GameSE01").GetComponent<Mgr_GameSE01>();
        fadeWhite = GameObject.Find("FadeWhite").GetComponent<FadeImage>();
    }

    void Start() {
    }

    void Update() {
        UpdateControl();
    }

    void UpdateControl() {
//        if (GameManager.MapModeON == true && GameManager.MapModeOFF == false) {
//            playerSpotlight.intensity = 8;
//        } else if (GameManager.MapModeON == false && GameManager.MapModeOFF == true) {
//            playerSpotlight.intensity = 4;
//        }
//
//        if (GameManager.Croquette) {
//            mgrPlayerBtnCtrl.maxFSpeed = 4.0f;
//            mgrPlayerBtnCtrl.maxBSpeed = 2.5f;
//            mgrPlayerBtnCtrl.maxRotSpeed = 1.2f;
//            playerController.keyboardSpeed = 4.0f;
//            playerFootSound.soundInterval = 0.37f;
//        }
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Light") {
//            GameManager.Light = true;
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Croquette") {
//            GameManager.Croquette = true;
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Map") {
//            GameManager.MapCrystal = true;
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Enemy") {
            StartCoroutine("WarpToStart");
        }
    }

    private IEnumerator WarpToStart() {
        fadeWhite.show();
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(-1.0f, 0.5f, -15.0f);
        fadeWhite.hide();
        yield return new WaitForSeconds(2.0f);
        yield return null;
    }
}