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

    public void setDuration(float _Duration) {
        this.durationTime = _Duration;
    }

    public void hide() {
        LeanTween.cancel(this.rectTransform.gameObject);
        LeanTween.alpha(this.rectTransform, 2.5f, this.durationTime).setEase(LeanTweenType.easeOutSine);
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

    public void blink(Color _Color, float _Duration = 1f) {
        if (this.isBlinking) {
            return;
        }

        this.gameObject.transform.localScale = Vector3.one;
        this.gameObject.SetActive(true);

        this.image.color = new Color(_Color.r, _Color.g, _Color.b, this.image.color.a);

        this.isBlinking = true;
        LeanTween.alpha(this.rectTransform, 0.65f, _Duration)
        .setEase(LeanTweenType.easeInOutSine).setOnComplete(() => {
            LeanTween.alpha(this.rectTransform, 0.0f, _Duration)
            .setEase(LeanTweenType.easeInOutSine).setOnComplete(() => {
                this.isBlinking = false;
                this.blink(_Color, _Duration);
            });
        });
    }
}