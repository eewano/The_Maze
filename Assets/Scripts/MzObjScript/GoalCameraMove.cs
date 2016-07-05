using System;
using UnityEngine;

public class GoalCameraMove : MonoBehaviour {

    //public：地点AとB
    [SerializeField]
    private Transform From, To = null;
    //public：秒数
    [SerializeField]
    private float Sec = 3.0f;
    private float Bunshi = 0;

    private bool startTween;

    void Start() {
        startTween = false;
        //地点Aを初期位置へ
        transform.position = From.position;
        transform.rotation = From.rotation;
    }

    void Update() {
        if (startTween == true)
        {
            //A-B差分と分子にA地点の座標を足して現在位置を算出
            transform.position = From.position + Vector3.Scale(
                    To.position - From.position, new Vector3(Bunshi, Bunshi, Bunshi));
            //分子に秒単位÷指定秒数を加算
            Bunshi += Time.deltaTime / Sec;
            //分子が１以上のとき･･･
            if (Bunshi >= 1f)
            {
                //再生終了。
                Bunshi = 1f;
                return;
            }
        }
    }

    public void ToGOALState(object o, EventArgs e) {
        startTween = true;
    }
}