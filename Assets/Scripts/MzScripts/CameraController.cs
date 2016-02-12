using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	[SerializeField] private Camera readyCamera;
	[SerializeField] private Camera playerCamera;
	[SerializeField] private Camera mapCamera;
	[SerializeField] private Camera goalCamera;
	[SerializeField] private GameObject ceiling;
	[SerializeField] private GameObject mzLight;
	[SerializeField] private GameObject mapLight;
	[SerializeField] private GameObject goalLight;


	void CameraAllSet()
	{
		readyCamera.enabled = false;
		playerCamera.enabled = false;
		mapCamera.enabled = false;
		goalCamera.enabled = false;
		ceiling.gameObject.SetActive (true);
		mzLight.gameObject.SetActive (false);
		mapLight.gameObject.SetActive (false);
		goalLight.gameObject.SetActive (false);

		if (SceneManager.GetActiveScene().name == "Maze00") {
			ceiling.gameObject.SetActive (false);
			mzLight.gameObject.SetActive (true);
			mapLight.gameObject.SetActive (false);
		}
	}

	public void ShowReadyCamera()
	{
		CameraAllSet ();
		readyCamera.enabled = true;
	}

	public void ShowPlayerCamera()
	{
		CameraAllSet ();
		playerCamera.enabled = true;
	}

	public void ShowMapCamera()
	{
		CameraAllSet ();

		mapCamera.enabled = true;
		ceiling.gameObject.SetActive (false);
		mzLight.gameObject.SetActive (false);
		mapLight.gameObject.SetActive (true);
	}

	public void ShowGoalCamera()
	{
		CameraAllSet ();

		goalCamera.enabled = true;
		mzLight.gameObject.SetActive (false);
		goalLight.gameObject.SetActive (true);
	}
}