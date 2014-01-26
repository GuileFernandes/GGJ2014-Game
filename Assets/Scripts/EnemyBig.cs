using UnityEngine;
using System.Collections;

public class EnemyBig : MonoBehaviour {
	
	private float movementSpeed = 3.0f;
	private float positionIni;
	private bool VaiParaDireita;

	private float nextWalk = 5;
	private float walkRate = 5;

	private int vidas = 20;

	// Use this for initialization
	void Start () {
		positionIni = transform.position.x;
		VaiParaDireita = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextWalk){
			if( VaiParaDireita ){
				if ( transform.position.x - positionIni <= 5 ){
					atirar();
					direita ();
				}
				else{
					VaiParaDireita = false;
					nextWalk = Time.time + walkRate;
				}
			}
			else{
				if( transform.position.x > positionIni )
					esquerda ();
				else{
					VaiParaDireita = true;
					nextWalk = Time.time + walkRate;
				}
			}
		}
	}
	
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "projetilPlayer"){
			vidas--;
		}
	}
	
	void atirar(){
		//FireBall bala = Instantiate (fireBall, transform.position, transform.rotation);
	}

	void direita(){
		transform.position += Vector3.right * movementSpeed * Time.deltaTime;
	}
	
	void esquerda(){
		transform.position += Vector3.left * movementSpeed * Time.deltaTime;
	}
}
