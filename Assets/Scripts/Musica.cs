using UnityEngine;
using System.Collections;

public class Musica : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		Debug.Log ("passou");
		if (c.tag == "Player" && !gameObject.audio.isPlaying){
			gameObject.audio.Play();
			GameObject.FindGameObjectWithTag("MusicaFundo").audio.Stop();
		}
	}

}
