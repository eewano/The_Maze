using UnityEngine;
using System.Collections;

public class FootSound : MonoBehaviour {

	public float sound_interval = 0.5f;	
	public AudioClip foot_se01;
	private AudioSource audio_source;

	private float count = 0;
	private Vector3 last_pos;	//プレイヤーが前にいたPosition

	void Start () {
		audio_source = gameObject.GetComponent<AudioSource>();
		audio_source.clip = foot_se01;
	}


	void Update () {


		if (last_pos != transform.position) {
			if (sound_interval < count) {
				audio_source.Play();
				count = 0;
			}
		}
		last_pos = transform.position;
		count += 1 * Time.deltaTime;
	}
}