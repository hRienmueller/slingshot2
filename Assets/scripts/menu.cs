using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {



	public void changeScenes (string NameOfScene) {
		
		Application.LoadLevel(NameOfScene);
	}

	public void ExitGame(){

		Application.Quit(); 
	}

	public void changeProjectiles(){


	}
}
