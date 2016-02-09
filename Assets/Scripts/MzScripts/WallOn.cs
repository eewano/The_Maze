using UnityEngine;
using System.Collections;

public class WallOn : MonoBehaviour {

	MzSoundEffect mzSoundEffect;

	void Start()
	{
		mzSoundEffect = GameObject.Find("MzSoundController").GetComponent<MzSoundEffect>();
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			if (WallOnOff.WallOn == false && WallOnOff.WallOff == true) {
				mzSoundEffect.ShutterSound ();
				Camera.main.SendMessage ("Clash");
			}
			WallOnOff.WallOn = true;
			WallOnOff.WallOff = false;
		}
	}
}