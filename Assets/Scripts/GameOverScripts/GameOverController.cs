using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

	[SerializeField] Text GameOverLabel;
	[SerializeField] Text ReturnToTitleLabel;

	[SerializeField] Image FadeBlack;
	float Alpha;
	bool FadeOut;

	void Start()
	{
		GameOverLabel.enabled = true;
		ReturnToTitleLabel.enabled = true;

		Time.timeScale = 1.0f;

		FadeOut = false;
		Alpha = 0;
		FadeBlack.gameObject.SetActive(false);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			if(FadeBlack.gameObject.activeSelf == false)
			{
				FadeBlack.gameObject.SetActive(true);
				FadeOut = true;
			}
		}

		if(FadeOut == true)
		{
			FadeBlack.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, Alpha);
			Alpha += 0.5f * Time.deltaTime;
			if(Alpha >= 1)
			{
				Invoke ("ReturnToTitle", 1.0f);
			}
		}
	}

	void ReturnToTitle()
	{
		Application.LoadLevel("Title");
	}
}