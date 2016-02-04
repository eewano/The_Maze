using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	[SerializeField] private Text GameOverLabel;
	[SerializeField] private Text ReturnToTitleLabel;
	[SerializeField] private Image FadeBlack;

	void Start()
	{
		GameController.Fade = false;
		Time.timeScale = 1.0f;
		GameOverLabel.enabled = true;
		ReturnToTitleLabel.enabled = true;
		FadeBlack.enabled = false;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			FadeBlack.enabled = true;
			GameController.Fade = true;
			Invoke ("ReturnToTitle", 4.0f);
		}
	}

	void ReturnToTitle()
	{
		SceneManager.LoadScene("Title");
	}
}