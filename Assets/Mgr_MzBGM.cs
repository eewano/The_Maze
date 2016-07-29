using System;
using System.Collections;
using UnityEngine;

public class Mgr_MzBGM : MonoBehaviour {

    [SerializeField]
    private float fadeOutTime = 3.0f;
    private AudioSource mzBGM;

    void Awake() {
        mzBGM = GetComponent<AudioSource>();
    }

    public void BGMStopEvent(object o, EventArgs e) {
        mzBGM.Stop();
    }

    public void BGMFadeOutEvent(object o, EventArgs e) {
        StartCoroutine(FadeOut(fadeOutTime));
    }

    IEnumerator FadeOut(float duration) {
        float currentTime = 0.0f;
        float waitTime = 0.0f;
        float firstVol = mzBGM.volume;

        while (duration > currentTime) {
            currentTime += Time.fixedDeltaTime;
            mzBGM.volume = Mathf.Clamp01(firstVol * (duration - currentTime) / duration);
            yield return new WaitForSeconds(waitTime);
        }
    }
}