using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerPlayer : MonoBehaviour {

    private Light playerSpotlight;
    private FootSound playerFootSound;
    private EnemyMove enemyMove01;
    private EnemyMove enemyMove02;
//    private MzSoundEffect mzSoundEffect;
    private MzTimer mzTimer;
    private FadeImage fadeWhite;

    public static bool EnemyCatchPlayer;

    [SerializeField]
    private GameObject buttonForward;
    [SerializeField]
    private GameObject buttonBack;
    [SerializeField]
    private GameObject buttonLeft;
    [SerializeField]
    private GameObject buttonRight;
    [SerializeField]
    private GameObject buttonFL;
    [SerializeField]
    private GameObject buttonFR;
    [SerializeField]
    private GameObject buttonBL;
    [SerializeField]
    private GameObject buttonBR;

    void Start() {
//        mzSoundEffect = GameObject.Find("MzSoundEffect").GetComponent<MzSoundEffect>();
        mzTimer = GameObject.Find("MzTimerLabel").GetComponent<MzTimer>();
        playerFootSound = GameObject.Find("Player").GetComponent<FootSound>();
        playerSpotlight = GameObject.Find("PlayerSpotlight").GetComponent<Light>();
        enemyMove01 = GameObject.Find("Enemy (1)").GetComponent<EnemyMove>();
        enemyMove02 = GameObject.Find("Enemy (2)").GetComponent<EnemyMove>();
        fadeWhite = GameObject.Find("FadeWhite").GetComponent<FadeImage>();
        gameObject.SetActive(true);

        EnemyCatchPlayer = false;
    }

    public void ControllerAllFalse() {
        buttonForward.gameObject.SetActive(false);
        buttonBack.gameObject.SetActive(false);
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
        buttonFL.gameObject.SetActive(false);
        buttonFR.gameObject.SetActive(false);
        buttonBL.gameObject.SetActive(false);
        buttonBR.gameObject.SetActive(false);
    }

    public void ControllerAllTrue() {
        buttonForward.gameObject.SetActive(true);
        buttonBack.gameObject.SetActive(true);
        buttonLeft.gameObject.SetActive(true);
        buttonRight.gameObject.SetActive(true);
        buttonFL.gameObject.SetActive(true);
        buttonFR.gameObject.SetActive(true);
        buttonBL.gameObject.SetActive(true);
        buttonBR.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Light") {
            GameManager.Light = true;
//            mzSoundEffect.LightBallSound();
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Croquette") {
            GameManager.Croquette = true;
//            mzSoundEffect.CroquetteSound();
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Map") {
            GameManager.MapCrystal = true;
//            mzSoundEffect.MapCrystalSound();
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Enemy") {
            enemyMove01.EnemySEStop();
            enemyMove02.EnemySEStop();
//            mzSoundEffect.EnemyTouchSound();
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