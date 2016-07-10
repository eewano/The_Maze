using System;
using UnityEngine;

public class Mgr_FadeImage : MonoBehaviour {

    [SerializeField]
    private ImageFade imageFadeBlack;
    [SerializeField]
    private ImageFade imageFadeWhite;

    public void StartFadeBlack(object o, EventArgs e) {
        imageFadeBlack.show();
    }

    public void ReturnFadeBlack(object o, EventArgs e) {
        imageFadeBlack.hide();
    }

    public void StartFadeWhite(object o, EventArgs e) {
        imageFadeWhite.show();
    }

    public void ReturnFadeWhite(object o, EventArgs e) {
        imageFadeWhite.hide();
    }
}