using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	/** 追従するオブジェクト */
	public Transform target;

	/** Z方向の距離 */
	[SerializeField] float distance = 0;

	/** Y方向の高さ */
	[SerializeField] float height = 0;

	/** 上下高さのスムーズ移動速度 */
	[SerializeField] float heightDamping = 0;

	/** 左右回転のスムーズ移動速度 */
	[SerializeField] float rotationDamping = 0;

	void LateUpdate() {
		//if (target == null) {
		//	return;
		//}

		//追従先位置
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;

		//現在位置
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		//追従先へのスムーズ移動距離(方向)
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, 
			rotationDamping * Time.deltaTime);
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		//カメラの移動
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
		Vector3 pos = target.position - currentRotation * Vector3.forward * distance;
//		pos.y = currentHeight;
		pos.y = height;
		transform.position = pos;

		//Y軸への追跡を無効にする。
		var lookatTarget = target.position;
		lookatTarget.y = height;
		transform.LookAt(lookatTarget);
	}
}