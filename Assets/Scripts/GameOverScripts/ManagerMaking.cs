using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerMaking : MonoBehaviour {

    [SerializeField]
    private Text toTitleText;
    private ImageFade imageFadeBlack;

    private enum State {
        EMPTY,
        STANDBYOK
    }

    private State state;

    void Awake() {
        imageFadeBlack = GameObject.Find("FadeBlack").GetComponent<ImageFade>();
    }

    void Start() {
        toTitleText.text = "";
        Empty();
    }

    void Update() {
        switch (state) {
            case State.EMPTY:
                break;

            case State.STANDBYOK:
                if (Input.GetMouseButtonUp(0)) {
                    StartCoroutine(ToTitle());
                }
                break;
        }
    }

    void Empty() {
        state = State.EMPTY;
        Invoke("StandByOK", 3.0f);
    }

    void StandByOK() {
        state = State.STANDBYOK;
        toTitleText.text = "画面をクリックすると\nタイトル画面に戻ります。";
    }

    IEnumerator ToTitle() {
        imageFadeBlack.show();
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Title");
    }
}