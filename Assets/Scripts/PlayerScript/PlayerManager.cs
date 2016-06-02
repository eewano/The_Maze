using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    private Light playerSpotlight;
    private FootSound playerFootSound;
    private PlayerController playerController;
    private EnemyMove enemyMove01;
    private EnemyMove enemyMove02;
    private MzSoundEffect mzSoundEffect;
    private MzTimer mzTimer;
    private FadeImage fadeWhite;

    public static bool EnemyCatchPlayer;

    void Start() {
        mzSoundEffect = GameObject.Find("MzSoundEffect").GetComponent<MzSoundEffect>();
        mzTimer = GameObject.Find("MzTimerLabel").GetComponent<MzTimer>();
        playerFootSound = GameObject.Find("Player").GetComponent<FootSound>();
        playerSpotlight = GameObject.Find("PlayerSpotlight").GetComponent<Light>();
        playerController = GetComponent<PlayerController>();
        enemyMove01 = GameObject.Find("Enemy (1)").GetComponent<EnemyMove>();
        enemyMove02 = GameObject.Find("Enemy (2)").GetComponent<EnemyMove>();
        fadeWhite = GameObject.Find("FadeWhite").GetComponent<FadeImage>();
        gameObject.SetActive(true);

        EnemyCatchPlayer = false;
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
        if (Input.GetKeyDown("l") && GameManager.Light == false) {
            GameManager.Light = true;
        }
        else if (Input.GetKeyDown("l") && GameManager.Light == true) {
            GameManager.Light = false;
        }

        if (Input.GetKeyDown("c") && GameManager.Croquette == false) {
            GameManager.Croquette = true;
        }

        if (Input.GetKeyDown("m") && GameManager.MapCrystal == false) {
            GameManager.MapCrystal = true;
        }
        else if (Input.GetKeyDown("m") && GameManager.MapCrystal == true) {
            GameManager.MapCrystal = false;
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
            enemyMove01.EnemySEStop();
            enemyMove02.EnemySEStop();
            mzSoundEffect.EnemyTouchSound();
            mzTimer.StopTimer();
            StartCoroutine("WarpToStart");
        }
    }

    private IEnumerator WarpToStart() {
        EnemyCatchPlayer = true;
        fadeWhite.show();
        yield return new WaitForSeconds(3.0f);
        transform.position = new Vector3(-1.0f, 0.5f, -15.0f);
        mzTimer.EnemyTouchTimer();
        fadeWhite.hide();
        yield return new WaitForSeconds(2.0f);
        mzTimer.StartTimer();
        EnemyCatchPlayer = false;
        enemyMove01.EnemySEPlay();
        enemyMove02.EnemySEPlay();
        yield return null;
    }
}