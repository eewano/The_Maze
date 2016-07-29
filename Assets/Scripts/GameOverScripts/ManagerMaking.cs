using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerMaking : MonoBehaviour {

    [SerializeField]
    private Text toTitleText;
    private ImageFade imageFadeBlack;
    private Mgr_MzBGM mgrMzBGM;

    private event EveHandPLAYSE bgmFadeOut;

    private enum State {
        EMPTY,
        STANDBYOK
    }

    private State state;

    void Awake() {
        imageFadeBlack = GameObject.Find("FadeBlack").GetComponent<ImageFade>();
        mgrMzBGM = GameObject.Find("MzBGM").GetComponent<Mgr_MzBGM>();
    }

    void Start() {
        bgmFadeOut = new EveHandPLAYSE(mgrMzBGM.BGMFadeOutEvent);
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
        Invoke("StandByOK", 4.0f);
    }

    void StandByOK() {
        state = State.STANDBYOK;
        toTitleText.text = "画面をクリックすると\nタイトル画面に戻ります。";
    }

    IEnumerator ToTitle() {
        this.bgmFadeOut(this, EventArgs.Empty);
        imageFadeBlack.show();
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Title");
    }
}