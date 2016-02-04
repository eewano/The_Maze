using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	public static bool Mz00 = false;
	public static bool Mz01 = false;

	enum TitleState
	{
		TITLE,
		DESCRIPTION,
		START
	}
	private TitleState state;

	[SerializeField] private Text titleLabel;
	[SerializeField] private Text subtitleLabel;
	[SerializeField] private Text descriptiontitleLabel;
	[SerializeField] private Text descriptionLabel;

	[SerializeField] private GameObject descriptionButton;
	[SerializeField] private GameObject mazePanel01;
	[SerializeField] private GameObject mazePanel02;
	[SerializeField] private GameObject mazePanel03;
	[SerializeField] private GameObject titleButton;

	[SerializeField] private Image FadeBlack;

	TitleSoundEffect titlesoundEffect;

	void Start()
	{
		Mz00 = false;
		Mz01 = false;
		GameController.Fade = false;

		titlesoundEffect = GameObject.Find("TitleSoundController").GetComponent<TitleSoundEffect>();
		Title ();

		FadeBlack.enabled = false;
	}

	void Update()
	{
		switch (state) {

		case TitleState.TITLE:
			break;

		case TitleState.DESCRIPTION:
			break;

		case TitleState.START:
					if (Mz00) {
						SceneManager.LoadScene ("Maze00");
					} else if (Mz01) {
						SceneManager.LoadScene ("Maze01");
					}
			break;
		}
	}

	void AllFalse()
	{
		titleLabel.enabled = false;
		subtitleLabel.enabled = false;
		descriptiontitleLabel.enabled = false;
		descriptionLabel.enabled = false;

		descriptionButton.gameObject.SetActive (false);
		mazePanel01.gameObject.SetActive (false);
		mazePanel02.gameObject.SetActive (false);
		mazePanel03.gameObject.SetActive (false);
		titleButton.gameObject.SetActive (false);
	}


	void Title()
	{
		state = TitleState.TITLE;

		AllFalse ();
		titleLabel.enabled = true;
		subtitleLabel.enabled = true;

		descriptionButton.gameObject.SetActive (true);
		mazePanel01.gameObject.SetActive (true);
		mazePanel02.gameObject.SetActive (true);
		mazePanel03.gameObject.SetActive (true);
	}

	void Description()
	{
		state = TitleState.DESCRIPTION;

		AllFalse ();
		descriptiontitleLabel.enabled = true;
		descriptionLabel.enabled = true;

		titleButton.gameObject.SetActive (true);
	}

	void GameStart()
	{
		state = TitleState.START;
		if(FadeBlack.gameObject.activeSelf == false)
		{
			FadeBlack.gameObject.SetActive(true);
		}
	}


	public void Mz00Start()
	{
		Mz00 = true;
		titlesoundEffect.GameEnter();
		FadeBlack.enabled = true;
		GameController.Fade = true;
		Invoke ("GameStart", 3.0f);
	}

	public void Mz01Start()
	{
		Mz01 = true;
		titlesoundEffect.GameEnter();
		FadeBlack.enabled = true;
		GameController.Fade = true;
		Invoke ("GameStart", 3.0f);
	}

	public void OnTitleButtonClicked()
	{
		titlesoundEffect.Exit();
		Title();
	}

	public void OnDescriptionClicked()
	{
		titlesoundEffect.Enter();
		Description();
	}
}