using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	Transform playerTransform;
	GameObject chao;
	public float limiteCenarioEsquerda;
	public float limiteCenarioDireita;

	Vector3 cameraOrientationVector = new Vector3 (5, 9, -10f);
	
	
	void Start (){
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		chao = GameObject.FindGameObjectWithTag("chao");
		limiteCenarioEsquerda = chao.transform.position.x - (chao.transform.localScale.x / 2) + 4;
		limiteCenarioDireita = chao.transform.position.x + (chao.transform.localScale.x / 2) - 4;
	}
	
	void LateUpdate (){
		float positionX = playerTransform.position.x + cameraOrientationVector.x;

		if( ( playerTransform.position.x > limiteCenarioEsquerda + 15 ) &&
		   ( playerTransform.position.x < limiteCenarioDireita - 32 ) )
			transform.position = new Vector3 (positionX, cameraOrientationVector.y, cameraOrientationVector.z);
	}
}