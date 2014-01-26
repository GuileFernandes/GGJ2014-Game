using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	private float movementSpeed = 5.0f;
	private float positionIni;
	private bool VaiParaDireita;

	// Use this for initialization
	void Start () {
		positionIni = transform.position.x;
		VaiParaDireita = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(VaiParaDireita)
			direita ();
		else
			esquerda();
	}

	void direita(){
		this.transform.rotation = new Quaternion (0, 180, 0, 0);
		transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		if( ( transform.position.x - positionIni ) >= 10){
			VaiParaDireita = false;
		}
	}

	void esquerda(){
		this.transform.rotation = new Quaternion (0, 0, 0, 0);
		transform.position -= Vector3.right * movementSpeed * Time.deltaTime;
		if( transform.position.x < positionIni )
			VaiParaDireita = true;
	}
}
