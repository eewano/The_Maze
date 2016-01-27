using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	public static bool Mz00 = false;
	public static bool Mz01 = false;
	private bool FadeOut;

	float Alpha;

	enum TitleState
	{
		TITLE,
		DESCRIPTION,
		START
	}
	private TitleState state;

	[SerializeField] Text titleLabel = null;
	[SerializeField] Text subtitleLabel = null;
	[SerializeField] Text descriptiontitleLabel = null;
	[SerializeField] Text descriptionLabel = null;

	[SerializeField] GameObject descriptionButton = null;
	[SerializeField] GameObject mazePanel01 = null;
	[SerializeField] GameObject mazePanel02 = null;
	[SerializeField] GameObject mazePanel03 = null;
	[SerializeField] GameObject titleButton = null;

	[SerializeField] Image FadeBlack = null;

	TitleSoundEffect titlesoundEffect;

	void Start()
	{
		Mz00 = false;
		Mz01 = false;

		titlesoundEffect = GameObject.Find("TitleSoundController").GetComponent<TitleSoundEffect>();
		Title ();

		FadeOut = false;
		Alpha = 0;
		FadeBlack.gameObject.SetActive(false);
	}

	void Update()
	{
		switch (state) {

		case TitleState.TITLE:
			break;

		case TitleState.DESCRIPTION:
			break;

		case TitleState.START:
			if(FadeOut == true)
			{
				FadeBlack.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, Alpha);
				Alpha += Time.deltaTime;
				if(Alpha >= 1)
				{
					if (Mz00) {
						SceneManager.LoadScene ("Maze00");
					} else if (Mz01) {
						SceneManager.LoadScene ("Maze01");
					}
				}
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
			FadeOut = true;
		}
	}


	public void Mz00Start()
	{
		Mz00 = true;
		titlesoundEffect.GameEnter();
		Invoke ("GameStart", 1.0f);
	}

	public void Mz01Start()
	{
		Mz01 = true;
		titlesoundEffect.GameEnter();
		Invoke ("GameStart", 1.0f);
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