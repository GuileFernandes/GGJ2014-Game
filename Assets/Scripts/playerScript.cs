using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	public Vector2 speed = new Vector2(5,0);
	private Vector2 movement;
	public float forcaPulo = 900f;
//	private bool duploPulo = false;

	/* utilizada para virar o personagem*/
	private bool facingRight = true;

	private Animator anim;

	/* utilizada para saber se personagem esta no chao */
	GroundDetector groundDetector_script;
	public GameObject groundDetector;

	/* utilizada para saber o limite do cenario */
	CameraScript camera_script;
	public GameObject cameraObject;

	void Start () {
		anim = GetComponent<Animator>();
		groundDetector_script = groundDetector.GetComponent<GroundDetector> ();
		camera_script = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript> ();
	}
	

	void Update () {
		/* Pulo */
		if ( ( groundDetector_script.isGrounded /*|| !duploPulo */ ) && Input.GetKeyDown (KeyCode.Space) ) {
			anim.SetBool("noChao", false);
			anim.SetBool("Pulou", true);
			GameObject.FindGameObjectWithTag("SoundJump").audio.Play();
			rigidbody2D.AddForce ( new Vector2 (0, forcaPulo));

/*			if( !duploPulo && !groundDetector_script.isGrounded ){
				anim.SetBool("PuloDuplo", true);
				duploPulo = true;				
			}
*/
		}

	}

	void FixedUpdate(){

		float inputX = Input.GetAxis("Horizontal");
/*		float inputY = Input.GetAxis("Vertical");
		if( groundDetector_script.isGrounded || duploPulo )
			anim.SetBool("PuloDuplo", false);
			duploPulo = false;
 */
		
		if( (inputX < 0 && transform.position.x > (camera_script.limiteCenarioEsquerda)) ||
		   (inputX > 0 && transform.position.x < camera_script.limiteCenarioDireita) ){
			if( Input.GetKey( KeyCode.LeftShift ) && inputX != 0 ){
				speed.x = 11;
			} else {
				if(inputX != 0){
					speed.x = 5;
				}
			}
		} else {
			speed.x = 0;
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
		if (coll.gameObject.tag == "chao") {
			anim.SetBool("noChao", true);
			anim.SetBool("Pulou", false);
		}
		if ( (coll.gameObject.tag == "bigBoss" || coll.gameObject.tag == "inimigo") && !GameObject.FindGameObjectWithTag("SoundHit").audio.isPlaying) {
			GameObject.FindGameObjectWithTag("SoundHit").audio.Play();
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

	void dentroLimiteCenario(){


	}
}
