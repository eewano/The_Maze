using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private NavMeshAgent m_agent;
	private int SpeedId;
	// 歩行スピード
	public float speed = 3.0F;
	// 方向転換のスピード
	public float rotationSpeed = 50.0F;

	// Use this for initialization
	void Start () {
		m_agent = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);	
	}
}
