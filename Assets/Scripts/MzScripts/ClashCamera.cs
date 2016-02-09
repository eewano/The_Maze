using UnityEngine;
using System.Collections;

public class ClashCamera : MonoBehaviour
{
	public void Clash ()
	{
		GetComponent<Animator>().SetTrigger("Shake");
	}
}