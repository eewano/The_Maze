using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// クリアー時のテクスチャ
	public GUITexture texClear;
	//失敗時のテクスチャ
	public GUITexture texFailed;

	// ステージ終了フラグ
	private bool isStageEnd;

	void Start () {
		texClear.enabled = false;
		texFailed.enabled = false;
		isStageEnd = false;
	}

	void Update () {
		// ステージが終了していてマウスの左クリックかタッチパネルが押されたら
		if (isStageEnd
			&& (Input.GetKey (KeyCode.Mouse0) || Input.touchCount > 0)) {
			// シーンStartMenuをロードする
			Application.LoadLevel ("StartMenu");
		}
	}

	void StageClear() {
		texClear.enabled = true;
		isStageEnd = true;
	}

	void StageFailed() {
		texFailed.enabled = true;
		isStageEnd = true;
	}
}
