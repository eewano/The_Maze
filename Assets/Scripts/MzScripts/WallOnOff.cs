﻿using UnityEngine;
using System.Collections;

public class WallOnOff : MonoBehaviour {

	public static bool WallOn = false;
	public static bool WallOff = false;

	[SerializeField] GameObject OnOffWall = null; 

	void Start()
	{
		WallOn = true;
		WallOff = false;
		OnOffWall.gameObject.SetActive(true);
	}

	void Update ()
	{
		if (WallOn) {
			OnOffWall.gameObject.SetActive(true);
		} else if (WallOff) {
			OnOffWall.gameObject.SetActive(false);
		}
	}
}