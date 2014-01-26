using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(1, 1), 1);
	}	
}
