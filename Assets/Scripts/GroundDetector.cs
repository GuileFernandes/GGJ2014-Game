using UnityEngine;
using System.Collections;

public class GroundDetector : MonoBehaviour {

	public bool isGrounded;

	void OnTriggerEnter2D(Collider2D c){

		if (c.tag == "chao")
			isGrounded = true;

	}

	void OnTriggerExit2D(Collider2D c){
		
		if (c.tag == "chao")
			isGrounded = false;
		
	}

}
