using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mz00Controller : MonoBehaviour {

	public static bool Mz00Goal = false;
	private bool FirstMapFlag;
	private bool FirstCroqFlag;
	private bool FirstLightFlag;
	private bool AllItemGet;

	[SerializeField] private Image mapCrystalImage;
	[SerializeField] private Image croquetteImage;
	[SerializeField] private Image lightBallImage;
	[SerializeField] private Image toGoalImage;

	void Start()
	{
		mapCrystalImage.gameObject.SetActive (false);
		croquetteImage.gameObject.SetActive (false);
		lightBallImage.gameObject.SetActive (false);
		toGoalImage.gameObject.SetActive (false);

		FirstMapFlag = false;
		FirstCroqFlag = false;
		FirstLightFlag = false;
		AllItemGet = false;
	}

	void Update()
	{
		if (FirstMapFlag == true && 
			FirstCroqFlag == true && 
			FirstLightFlag == true && 
			AllItemGet == true)
		{
			Debug.Log ("ClearOK");
			toGoalImage.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
			Debug.Log ("Stop");
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				toGoalImage.gameObject.SetActive (false);
				Mz00Goal = true;
				AllItemGet = false;
			}
		}

		if (GameController.MapCrystal == true && FirstMapFlag == false) {
			mapCrystalImage.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				mapCrystalImage.gameObject.SetActive (false);
				FirstMapFlag = true;
				AllItemGet = true;
			}
		}

		if (GameController.Croquette == true && FirstCroqFlag == false) {
			croquetteImage.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				croquetteImage.gameObject.SetActive (false);
				FirstCroqFlag = true;
				AllItemGet = true;
			}
		}

		if (GameController.Light == true && FirstLightFlag == false) {
			lightBallImage.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
			if (Input.GetMouseButtonDown (0)) {
				Time.timeScale = 1.0f;
				lightBallImage.gameObject.SetActive (false);
				FirstLightFlag = true;
				AllItemGet = true;
			}
		}
	}
}