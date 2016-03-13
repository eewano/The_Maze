using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour {
	
	[SerializeField] private Camera playerCamera;
	[SerializeField] private Camera mapCamera;
	[SerializeField] private Camera goalCamera;
	[SerializeField] private GameObject ceiling;
	[SerializeField] private GameObject mapLight;
	[SerializeField] private GameObject goalLight;

	void CameraAllSet()
	{
		playerCamera.enabled = false;
		mapCamera.enabled = false;
		goalCamera.enabled = false;
		ceiling.gameObject.SetActive (true);
		mapLight.gameObject.SetActive (false);
		goalLight.gameObject.SetActive (false);
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
		mapLight.gameObject.SetActive (true);
	}

	public void ShowGoalCamera()
	{
		CameraAllSet ();

		goalCamera.enabled = true;
		goalLight.gameObject.SetActive (true);
	}
}