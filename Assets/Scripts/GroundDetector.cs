﻿using UnityEngine;
using System.Collections;

public class GroundDetector : MonoBehaviour {

	public bool isGrounded;

	void OnTriggerEnter2D(Collider2D c){

		if (c.tag == "chao")
			isGrounded = true;
		if (c.tag == "inimigo"){
			GameObject.FindGameObjectWithTag("SoundKillJump").audio.Play();
			Destroy(c.gameObject);
		}

	}

	void OnTriggerExit2D(Collider2D c){
		
		if (c.tag == "chao")
			isGrounded = false;
		
	}

}
