using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

	public void loadStage(){
	
		Application.LoadLevel ("Screen");
	
	}

	public void loadMenu(){
		Application.LoadLevel (0);
	}

	public void quit(){
		Application.Quit ();
	}
}
