using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	public Vector2 speed = new Vector2(1,0);
	private Vector2 movement;

	void Start () {
	
	}
	

	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2 (speed.x * inputX,0);

		if(Input.GetKey(KeyCode.Space)){
			transform.position += transform.up * +speed.y * Time.deltaTime;
		}
	}

	void FixedUpdate(){
		rigidbody2D.velocity = movement;
	}
}
