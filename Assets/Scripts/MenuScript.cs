using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void OnGUI(){
		const int buttonWidth = 84;
		const int buttonHeight = 40;
		
		// Draw a button to start the game
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2) -20,
			buttonWidth,
			buttonHeight
			),
			"Start!"
			)
			)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("teste_robson");
		}

		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2) + buttonHeight,
			buttonWidth,
			buttonHeight
			),
			"Instruçoes"
			)
			)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("tela_instructions");
		}
	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
