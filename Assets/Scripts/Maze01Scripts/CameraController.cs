using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField] Camera ReadyCamera = null;
	[SerializeField] Camera PlayerCamera = null;
	[SerializeField] Camera MapCamera = null;
	[SerializeField] Camera GoalCamera = null;
	[SerializeField] GameObject Ceiling = null;
	[SerializeField] GameObject MapLight = null;
	[SerializeField] GameObject GoalLight = null;

	public void ShowReadyCamera()
	{
		ReadyCamera.enabled = true;
		PlayerCamera.enabled = false;
		MapCamera.enabled = false;
		GoalCamera.enabled = false;
		Ceiling.gameObject.SetActive (true);
		MapLight.gameObject.SetActive (false);
		GoalLight.gameObject.SetActive (false);
	}

	public void ShowPlayerCamera()
	{
		ReadyCamera.enabled = false;
		PlayerCamera.enabled = true;
		MapCamera.enabled = false;
		GoalCamera.enabled = false;
		Ceiling.gameObject.SetActive (true);
		MapLight.gameObject.SetActive (false);
		GoalLight.gameObject.SetActive (false);
	}

	public void ShowMapCamera()
	{
		ReadyCamera.enabled = false;
		PlayerCamera.enabled = false;
		MapCamera.enabled = true;
		GoalCamera.enabled = false;
		Ceiling.gameObject.SetActive (false);
		MapLight.gameObject.SetActive (true);
		GoalLight.gameObject.SetActive (false);

		Time.timeScale = 0.0f;
	}

	public void ShowGoalCamera()
	{
		ReadyCamera.enabled = false;
		PlayerCamera.enabled = false;
		MapCamera.enabled = false;
		GoalCamera.enabled = true;
		Ceiling.gameObject.SetActive (true);
		MapLight.gameObject.SetActive (false);
		GoalLight.gameObject.SetActive (true);
	}
}