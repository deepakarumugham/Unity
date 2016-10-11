using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string level){
		Application.LoadLevel (level);
	}

	public void quitGame(){
		Application.Quit (); 
	}
}
