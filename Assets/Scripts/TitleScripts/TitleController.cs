using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	enum TitleState
	{
		TITLE,
		DESCRIPTION,
		START
	}

	TitleState state;

	TitleSoundEffect titlesoundEffect;
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
	float Alpha;
	bool FadeOut;

	void Start()
	{
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
					SceneManager.LoadScene ("Maze01");
				}
			}
			break;
		}
	}

	void Title()
	{
		state = TitleState.TITLE;
			
		titleLabel.enabled = true;
		subtitleLabel.enabled = true;
		descriptiontitleLabel.enabled = false;
		descriptionLabel.enabled = false;

		descriptionButton.gameObject.SetActive (true);
		mazePanel01.gameObject.SetActive (true);
		mazePanel02.gameObject.SetActive (true);
		mazePanel03.gameObject.SetActive (true);
		titleButton.gameObject.SetActive (false);
	}

	void Description()
	{
		state = TitleState.DESCRIPTION;

		titleLabel.enabled = false;
		subtitleLabel.enabled = false;
		descriptiontitleLabel.enabled = true;
		descriptionLabel.enabled = true;
		
		descriptionButton.gameObject.SetActive (false);
		mazePanel01.gameObject.SetActive (false);
		mazePanel02.gameObject.SetActive (false);
		mazePanel03.gameObject.SetActive (false);
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



	public void Maze01Start()
	{
		titlesoundEffect.GameEnter();
		Invoke ("GameStart", 2.0f);
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