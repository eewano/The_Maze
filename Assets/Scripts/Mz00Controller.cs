using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mz00Controller : MonoBehaviour {

	public static bool Mz00Goal = false;
	private bool FirstMapFlag;
	private bool FirstCroqFlag;
	private bool FirstLightFlag;
	private bool AllItemGet;

	[SerializeField] Text MapCrystalLabel = null;
	[SerializeField] Text CroquetteLabel = null;
	[SerializeField] Text LightLabel = null;
	[SerializeField] Text ToGoalLabel = null;

	void Start()
	{
		MapCrystalLabel.enabled = false;
		CroquetteLabel.enabled = false;
		LightLabel.enabled = false;
		ToGoalLabel.enabled = false;

		FirstMapFlag = false;
	}

	void Update()
	{
		if (FirstMapFlag == true && 
			FirstCroqFlag == true && 
			FirstLightFlag == true && 
			AllItemGet == true)
		{
			Debug.Log ("ClearOK");
			ToGoalLabel.enabled = true;
			Debug.Log ("Readydb");
			Time.timeScale = 0.0f;
			Debug.Log ("Stop");
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				ToGoalLabel.enabled = false;
				Mz00Goal = true;
				AllItemGet = false;
			}
		}

		if (GameController.MapCrystal == true && FirstMapFlag == false) {
			MapCrystalLabel.enabled = true;
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonUp (0)) {
				Time.timeScale = 1.0f;
				MapCrystalLabel.enabled = false;
				FirstMapFlag = true;
				AllItemGet = true;
			}
		}

		if (GameController.Croquette == true && FirstCroqFlag == false) {
			CroquetteLabel.enabled = true;
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonUp (0)) {
				Time.timeScale = 1.0f;
				CroquetteLabel.enabled = false;
				FirstCroqFlag = true;
				AllItemGet = true;
			}
		}

		if (GameController.Light == true && FirstLightFlag == false) {
			LightLabel.enabled = true;
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonUp (0)) {
				Time.timeScale = 1.0f;
				LightLabel.enabled = false;
				FirstLightFlag = true;
				AllItemGet = true;
			}
		}
	}
}