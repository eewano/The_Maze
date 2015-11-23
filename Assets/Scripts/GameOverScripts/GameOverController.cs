using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

	GameOverSoundEffect gameoversoundEffect;
	public Text GameOverLabel;
	public Text ReturnToTitleLabel;

	void Start()
	{
		gameoversoundEffect = GameObject.Find("GameOverSoundController").GetComponent<GameOverSoundEffect>();
		GameOverLabel.enabled = true;
		ReturnToTitleLabel.enabled = true;
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