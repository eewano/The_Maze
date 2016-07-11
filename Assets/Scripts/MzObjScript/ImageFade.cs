using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour {

    [SerializeField]
    private float delayTime = 0.5f;
    [SerializeField]
    private float durationTime = 1.0f;

    private RectTransform rectTransform;
    private Image image;

    private bool isBlinking = false;

    void Awake() {
        this.rectTransform = this.GetComponent<RectTransform>();
        this.image = this.GetComponent<Image>();
    }

    public void init() {
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 0);
    }

    public void show() {
        this.gameObject.transform.localScale = Vector3.one;
        this.gameObject.SetActive(true);
        this.image.color = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 0);

        this.activate();
    }

    public void setDelay(float _Delay) {
        this.delayTime = _Delay;
    }

    public void setDuration(float __duration) {
        this.durationTime = __duration;
    }

    public void hide() {
        LeanTween.cancel(this.rectTransform.gameObject);
        LeanTween.alpha(this.rectTransform, 0.0f, this.durationTime).setEase(LeanTweenType.easeOutSine);
    }

    public void activate() {
        LeanTween.cancel(this.rectTransform.gameObject);
        LeanTween.alpha(this.rectTransform, 1f, this.durationTime)
        .setDelay(this.delayTime)
        .setEase(LeanTweenType.easeOutSine);
    }

    public void inactivate() {
        LeanTween.cancel(this.rectTransform.gameObject);
        LeanTween.alpha(this.rectTransform, 0.4f, 0.2f).setEase(LeanTweenType.easeOutSine);
    }

    public void blink(Color __color, float __duration = 1f) {
        if (this.isBlinking) {
            return;
        }

        this.gameObject.transform.localScale = Vector3.one;
        this.gameObject.SetActive(true);

        this.image.color = new Color(__color.r, __color.g, __color.b, this.image.color.a);

        this.isBlinking = true;
        LeanTween.alpha(this.rectTransform, 0.65f, __duration)
        .setEase(LeanTweenType.easeInOutSine).setOnComplete(() => {
            LeanTween.alpha(this.rectTransform, 0.0f, __duration)
            .setEase(LeanTweenType.easeInOutSine).setOnComplete(() => {
                this.isBlinking = false;
                this.blink(__color, __duration);
            });
        });
    }
}