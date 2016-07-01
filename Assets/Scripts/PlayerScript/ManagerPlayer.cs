using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerPlayer : MonoBehaviour {

    private Light playerSpotlight;
    private FootSound playerFootSound;
    private EnemyMove enemyMove01;
    private EnemyMove enemyMove02;
    private MzTimer mzTimer;
    private FadeImage fadeWhite;

    public static bool EnemyCatchPlayer;

    void Start() {
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
    }

    public void ControllerAllTrue() {
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