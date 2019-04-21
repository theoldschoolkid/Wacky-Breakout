using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pause menu activated by "PauseMenuManager"  script when Esc key is pressed
/// </summary>
public class PauseMenu : MonoBehaviour {


	void Start () {

        Time.timeScale = 0; // Freeze game
	}
	

	public void HandleResumeButtonOnClickEvent () { 
		Time.timeScale = 1;                             // Unfreeze game onclick of resume button
		Destroy (this.gameObject);

	}

	public void HandleQuitButtonOnClickEvent(){
		Time.timeScale = 1;                             // Go tomain menu on click of of quit button
        Destroy (this.gameObject);
		PauseMenuManager.GoToMenu (MenuName.Return);

	}


}	
