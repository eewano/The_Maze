using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

	public Text GameOverLabel;
	public Text ReturnToTitleLabel;

	void Start()
	{
		GameOverLabel.enabled = true;
		ReturnToTitleLabel.enabled = true;

		Time.timeScale = 1.0f;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			Invoke ("ReturnToTitle", 2);
		}
	}

	void ReturnToTitle()
	{
		Application.LoadLevel("Title");
	}
}