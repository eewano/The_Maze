using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mz00Controller : MonoBehaviour {

	public static bool Mz00Goal = false;
	private bool FirstMapFlag;
	private bool FirstCroqFlag;
	private bool FirstLightFlag;
	private bool AllItemGet;

	[SerializeField] Image MapCrystalLabel = null;
	[SerializeField] Image CroquetteLabel = null;
	[SerializeField] Image LightLabel = null;
	[SerializeField] Image ToGoalLabel = null;

	void Start()
	{
		MapCrystalLabel.gameObject.SetActive (false);
		CroquetteLabel.gameObject.SetActive (false);
		LightLabel.gameObject.SetActive (false);
		ToGoalLabel.gameObject.SetActive (false);

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
			ToGoalLabel.gameObject.SetActive (true);
			Debug.Log ("Readydb");
			Time.timeScale = 0.0f;
			Debug.Log ("Stop");
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				ToGoalLabel.gameObject.SetActive (false);
				Mz00Goal = true;
				AllItemGet = false;
			}
		}

		if (GameController.MapCrystal == true && FirstMapFlag == false) {
			MapCrystalLabel.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				MapCrystalLabel.gameObject.SetActive (false);
				FirstMapFlag = true;
				AllItemGet = true;
			}
		}

		if (GameController.Croquette == true && FirstCroqFlag == false) {
			CroquetteLabel.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				CroquetteLabel.gameObject.SetActive (false);
				FirstCroqFlag = true;
				AllItemGet = true;
			}
		}

		if (GameController.Light == true && FirstLightFlag == false) {
			LightLabel.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				LightLabel.gameObject.SetActive (false);
				FirstLightFlag = true;
				AllItemGet = true;
			}
		}
	}
}