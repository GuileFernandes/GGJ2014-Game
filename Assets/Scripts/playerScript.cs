using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	public Vector2 speed = new Vector2(5,0);
	public bool noChao;
	private Vector2 movement;


	void Start () {
		noChao = true;
	}
	

	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2 (speed.x * inputX,0);


		if (Input.GetKeyDown (KeyCode.Space) && noChao == true) {
			rigidbody2D.AddForce (new Vector2 (0, 1000));
			noChao = false;
		}
	}

	void FixedUpdate(){
		rigidbody2D.velocity = movement;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "chao") {
			noChao = true;
		}
	}
}
