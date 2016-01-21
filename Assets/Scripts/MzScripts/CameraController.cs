using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	[SerializeField] Camera ReadyCamera = null;
	[SerializeField] Camera PlayerCamera = null;
	[SerializeField] Camera MapCamera = null;
	[SerializeField] Camera GoalCamera = null;
	[SerializeField] GameObject Ceiling = null;
	[SerializeField] GameObject MzLight = null;
	[SerializeField] GameObject MapLight = null;
	[SerializeField] GameObject GoalLight = null;


	void CameraAllSet()
	{
		ReadyCamera.enabled = false;
		PlayerCamera.enabled = false;
		MapCamera.enabled = false;
		GoalCamera.enabled = false;
		Ceiling.gameObject.SetActive (true);
		MzLight.gameObject.SetActive (false);
		MapLight.gameObject.SetActive (false);
		GoalLight.gameObject.SetActive (false);

		if (SceneManager.GetActiveScene().name == "Maze00") {
			Ceiling.gameObject.SetActive (false);
			MzLight.gameObject.SetActive (true);
			MapLight.gameObject.SetActive (false);
		}
	}

	public void ShowReadyCamera()
	{
		CameraAllSet ();
		ReadyCamera.enabled = true;
	}

	public void ShowPlayerCamera()
	{
		CameraAllSet ();
		PlayerCamera.enabled = true;
	}

	public void ShowMapCamera()
	{
		CameraAllSet ();

		MapCamera.enabled = true;
		Ceiling.gameObject.SetActive (false);
		MzLight.gameObject.SetActive (false);
		MapLight.gameObject.SetActive (true);
	}

	public void ShowGoalCamera()
	{
		CameraAllSet ();

		GoalCamera.enabled = true;
		MzLight.gameObject.SetActive (false);
		GoalLight.gameObject.SetActive (true);
	}
}