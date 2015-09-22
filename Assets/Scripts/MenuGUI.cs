using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	void OnGUI() {
		// Stage01ボタン表示
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Stage 01")) {
			//クリックされたらStage01シーンをロードする
			Application.LoadLevel ("Maze01");
		}
		// Stage02ボタン表示
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 110, 100, 50), "Stage 02")) {
			//クリックされたらStage02シーンをロードする
			Application.LoadLevel ("Maze02");
		}
	}
}