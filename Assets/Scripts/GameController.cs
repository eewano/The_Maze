using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject Player;
	// クリアー時のテクスチャ
	public GUIText texClear;
	// ステージ終了フラグ
	private bool isStageEnd;
	// クリア時のサウンド
	SoundEffect soundEffect;

	void Start () {
		texClear.enabled = false;
		isStageEnd = false;
		soundEffect = GameObject.Find ("SoundController").GetComponent<SoundEffect> ();
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
		soundEffect.PlayClear ();		
		texClear.enabled = true;
		isStageEnd = true;
	}
}
