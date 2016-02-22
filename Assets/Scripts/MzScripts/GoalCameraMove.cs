using UnityEngine;
using System.Collections;

public class GoalCameraMove : MonoBehaviour {

	//public：地点AとB
	[SerializeField] Transform From,To = null;
	//public：秒数
	[SerializeField] float Sec= 3.0f;
	//
	float Bunshi= 0;
	//public：アニメーション再生
	//[SerializeField] static bool StartTween = false;
	//public：アニメーションリセット
	//[SerializeField] bool ResetTween = false;

	void Start () {
		//地点Aを初期位置へ
		transform.position = From.position;
		transform.rotation = From.rotation;
	}

	void Update () {
		if (GameManager.StartTween) {
			//A-B差分と分子にA地点の座標を足して現在位置を算出
			transform.position = From.position + Vector3.Scale (
				To.position - From.position, new Vector3 (Bunshi, Bunshi, Bunshi));
		}

		//StartTweenがONのとき･･･
		if(GameManager.StartTween){
			//分子に秒単位÷指定秒数を加算
			Bunshi += Time.deltaTime / Sec;
			//分子が１以上のとき･･･
			if(Bunshi >= 1f){
				//再生終了。
				Bunshi = 1f;
				return;
			}
		}
	}
}