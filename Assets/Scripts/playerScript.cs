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


	public float forcaPulo = 700f;
	private bool duploPulo = false;

	private bool facingRight = true;

	private Animator anim;

	GroundDetector groundDetector_script;
	public GameObject groundDetector;

	void Start () {

		anim = GetComponent<Animator>();

		groundDetector_script = groundDetector.GetComponent<GroundDetector> ();

		tempoLimitePulo = 0.3;
		velocidadePulo = 5 * Time.deltaTime;
	}
	

	void Update () {

		if ( groundDetector_script.isGrounded && Input.GetKeyDown (KeyCode.Space) ) {
			Debug.Log("Pulou");
			anim.SetBool("noChao", false);
			anim.SetBool("Pulou", true);
			rigidbody2D.AddForce ( new Vector2 (0, forcaPulo));

			if( !duploPulo && !groundDetector_script.isGrounded )
				duploPulo = true;
		}

	}

	void FixedUpdate(){

		float inputX = Input.GetAxis("Horizontal");
		//		float inputY = Input.GetAxis("Vertical");

		if( groundDetector_script.isGrounded )
			duploPulo = false;
		
		if( Input.GetKeyDown( KeyCode.LeftShift ) && inputX != 0 ){
			speed.x = 11;
		}
		if( Input.GetKeyUp( KeyCode.LeftShift ) ){
			speed.x = 5;
		}
		
		if (inputX > 0 && !facingRight){
			Flip();
		}

		if (inputX < 0 && facingRight){
			Flip();
		}

		movement = new Vector2 (speed.x * inputX,0);
		anim.SetFloat("Velocidade", Mathf.Abs(speed.x * inputX) );

		anim.SetFloat( "VelocidadeV", rigidbody2D.velocity.y );
		rigidbody2D.velocity = new Vector2 (movement.x, rigidbody2D.velocity.y);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("Entrou");
		if (coll.gameObject.tag == "chao") {
			anim.SetBool("noChao", true);
			anim.SetBool("Pulou", false);
		}
	}

	/*
	void OnCollisionExit2D(Collision2D coll) {
		Debug.Log("Saiu");
		if (coll.gameObject.tag == "chao") {
			tempoPulo = tempoLimitePulo;
			podePulo = false;
		}
	}
	*/

	void Flip(){
		facingRight = !facingRight;
		Vector3  theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
