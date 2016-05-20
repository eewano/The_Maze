using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    [SerializeField]
    private Text gameOverLabel;
    [SerializeField]
    private Text returnToTitleLabel;
    [SerializeField]
    private Image fadeBlack;

    void Start() {
        Time.timeScale = 1.0f;
        GameManager.Fade = false;
        gameOverLabel.enabled = true;
        returnToTitleLabel.enabled = true;
        fadeBlack.enabled = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            fadeBlack.enabled = true;
            GameManager.Fade = true;
            Invoke("ReturnToTitle", 4.0f);
        }
    }

    void ReturnToTitle() {
        SceneManager.LoadScene("Title");
    }
}