using UnityEngine;
using UnityEngine.UI;

public class CatchedFadeIn : MonoBehaviour {

    private Image image;
    private float time;
    [SerializeField]
    private float fadeTime;

    private bool onFade;
    private bool offFade;

    void Start() {
        time = 0;
        image = GetComponent<Image>();    //Imageコンポネントを取得
    }

    public void Update() {
        if(onFade) {
            time += Time.deltaTime;    //時間更新.今度は増えていく
            float a = time / fadeTime;
            var color = image.color;
            color.a += 5;
            image.color = color;
            if(a >= 255) {

                OnFade(false);
            }
        }

        if(offFade) {
            time += Time.deltaTime;    //時間更新.今度は増えていく
            float a = (time / fadeTime) * -5;
            var color = image.color;
            color.a -= 10;
            image.color = color;
            Debug.Log(color.a);
            if(a <= 0) {
                OffFade(false);
            }
        }

    }

    public void OnFade(bool flag) {
        onFade = flag;
    }

    public void OffFade(bool flag) {
        offFade = flag;
    }
}