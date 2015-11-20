﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

	enum TitleState
	{
		TITLE,
		DESCRIPTION,
		START
	}

	TitleState state;

	TitleSoundEffect titlesoundEffect;
	public Text titleLabel;
	public Text subtitleLabel;
	public Text descriptiontitleLabel;
	public Text descriptionLabel;
	public GameObject descriptionButton;
	public GameObject mazePanel01;
	public GameObject mazePanel02;
	public GameObject mazePanel03;
	public GameObject titleButton;

	void Start()
	{
		titlesoundEffect = GameObject.Find("TitleSoundController").GetComponent<TitleSoundEffect>();
		Title ();
	}

	void Update()
	{
		switch (state) {

		case TitleState.TITLE:
			break;

		case TitleState.DESCRIPTION:
			break;

		case TitleState.START:
			Application.LoadLevel ("Maze01");
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
	}



	public void Maze01Start()
	{
		titlesoundEffect.GameEnter();
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