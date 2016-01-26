using UnityEngine;
using System.Collections;

public class FootSound : MonoBehaviour {

	public static float SoundInterval = 0.4f;	
	[SerializeField] AudioClip MzWalkSE = null;
	private AudioSource audio_source;

	private float count = 0;
	private Vector3 last_pos;	//プレイヤーが前にいたPosition

	void Start () {
		audio_source = gameObject.GetComponent<AudioSource>();
		audio_source.clip = MzWalkSE;
	}


	void Update ()
	{
		if (GameController.Fall || GameController.GameIsOver || GameController.Dead) {
			return;
		}

		if (last_pos != transform.position) {
			if (SoundInterval < count) {
				audio_source.Play();
				count = 0;
			}
		}

		last_pos = transform.position;
		count += 1 * Time.deltaTime;
	}
}