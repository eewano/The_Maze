using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private Light playerSpotlight;
    private FootSound playerFootSound;
    private PlayerController playerController;
    private MzSoundEffect mzSoundEffect;
    private MzTimer mzTimer;

    void Start() {
        mzSoundEffect = GameObject.Find("MzSoundEffect").GetComponent<MzSoundEffect>();
        mzTimer = GameObject.Find("MzTimerLabel").GetComponent<MzTimer>();
        playerFootSound = GameObject.Find("Player").GetComponent<FootSound>();
        playerSpotlight = GameObject.Find("PlayerSpotlight").GetComponent<Light>();
        playerController = GetComponent<PlayerController>();
        gameObject.SetActive(true);
    }

    void Update() {
        if (GameManager.GoalAndClear) {
            gameObject.SetActive(false);
        }

        if (GameManager.Fall == true || GameManager.GameIsOver == true) {
            enabled = false;
            return;
        }

        if (GameManager.MapModeON == true && GameManager.MapModeOFF == false) {
            playerSpotlight.intensity = 8;
        } else if (GameManager.MapModeON == false && GameManager.MapModeOFF == true) {
            playerSpotlight.intensity = 4;
        }

        //-----デバッグ用のショートカットキー-----
        if (Input.GetKeyDown("l")) {
            GameManager.Light = true;
        } else if (Input.GetKeyDown("c")) {
            GameManager.Croquette = true;
        } else if (Input.GetKeyDown("m")) {
            GameManager.MapCrystal = true;
        }
        //----------

        if (GameManager.Croquette) {
            playerController.maxForwardSpeed = 4.0f;
            playerController.maxBackwardSpeed = 2.5f;
            playerController.maxRotSpeed = 1.2f;
            playerController.keyboardSpeed = 4.0f;
            playerFootSound.soundInterval = 0.37f;
        }
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Light") {
            GameManager.Light = true;
            mzSoundEffect.LightBallSound();
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Croquette") {
            GameManager.Croquette = true;
            mzSoundEffect.CroquetteSound();
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Map") {
            GameManager.MapCrystal = true;
            mzSoundEffect.MapCrystalSound();
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Enemy") {
            mzSoundEffect.EnemyTouchSound();
            StartCoroutine("WarpToStart");
        }
    }

    private IEnumerator WarpToStart() {
        Debug.Log("1");
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(-1.0f, 0.5f, -15.0f);
        mzTimer.EnemyTouchTimer();
        Debug.Log("2");
        yield return null;
    }
}