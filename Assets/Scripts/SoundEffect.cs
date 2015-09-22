using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {

	public AudioClip seClear;

	public void PlayClear() {
		GetComponent<AudioSource>().PlayOneShot (seClear);
	}
}
