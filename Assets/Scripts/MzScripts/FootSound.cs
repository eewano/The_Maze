using UnityEngine;
using System.Collections;

public class FootSound : MonoBehaviour {

	public float soundInterval;
	[SerializeField] private AudioClip mzWalkSE;
	private AudioSource audioSource;

	private float count = 0;
	private Vector3 last_pos;	//プレイヤーが前にいたPosition

	void Awake () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = mzWalkSE;
	}
		
	void Update ()
	{
		if (GameManager.Fall || GameManager.GameIsOver || GameManager.Dead) {
			return;
		}

		if (last_pos != transform.position) {
			if (soundInterval < count) {
				audioSource.Play();
				count = 0;
			}
		}

		last_pos = transform.position;
		count += 1 * Time.deltaTime;
	}
}