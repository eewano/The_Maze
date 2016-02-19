using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	private Image image;
	private float time;
	[SerializeField] private float fadeTime;

	void Start () {
		time = 0;
		image = GetComponent<Image>();	//Imageコンポネントを取得
	}

	void Update()
	{
		if (GameController.Fade) {
			time += Time.deltaTime;	//時間更新.今度は増えていく
			float a = time / fadeTime;
			var color = image.color;
			color.a = a;
			image.color = color;
		}
	}
}