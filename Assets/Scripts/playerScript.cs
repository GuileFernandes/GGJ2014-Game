using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	public Vector2 speed = new Vector2(5,0);
	public bool SPulo;
	public float velocidadePulo;
	public double tempoPulo;
	public double tempoLimitePulo;
	public bool podePulo;
	private Vector2 movement;

	GroundDetector groundDetector_script;
	public GameObject groundDetector;

	void Start () {

		groundDetector_script = groundDetector.GetComponent<GroundDetector> ();

		tempoLimitePulo = 0.3;
		velocidadePulo = 5 * Time.deltaTime;
	}
	

	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2 (speed.x * inputX,0);

		if (inputX > 0)
			this.transform.rotation = new Quaternion (0, 0, 0, 0);

		if (inputX < 0)
			this.transform.rotation = new Quaternion (0, 180, 0, 0);
		
		//		this.transform.Translate (new Vector3(movement.x, 0, 0));

		if (Input.GetKeyDown (KeyCode.Space) && groundDetector_script.isGrounded) {
			rigidbody2D.AddForce(new Vector2(0, 600f));
//			SPulo = true;
//			transform.Translate (0, 5f, 0);
			//podePulo = true;
		}

/*		if (SPulo == true && tempoPulo <= tempoLimitePulo && podePulo == true) {
						transform.Translate (0, velocidadePulo, 0);
						tempoPulo += Time.deltaTime;
		}

/*		if (tempoPulo > tempoLimitePulo) {
			SPulo = false;
			podePulo = false;
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			SPulo = false;
		}
*/

	}

	void FixedUpdate(){
		rigidbody2D.velocity = new Vector2 (movement.x, rigidbody2D.velocity.y);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "chao") {
			tempoPulo = 0;
			podePulo = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "chao") {
			tempoPulo = tempoLimitePulo;
			podePulo = false;
		}
	}
}
