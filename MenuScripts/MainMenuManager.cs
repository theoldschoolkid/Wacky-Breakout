using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Buttons on the main maenu and its respective functions
/// </summary>

public class MainMenuManager: MonoBehaviour {


	public  void Play ()   {
		AudioManager.Play (AudioClipName.MenuButtonClick);
		SceneManager.LoadScene ("Gameplay");

	}

	public  void Quit ()   {
		AudioManager.Play (AudioClipName.MenuButtonClick);
		Application.Quit ();

	}

	public  void Help() {
		AudioManager.Play (AudioClipName.MenuButtonClick);
		SceneManager.LoadScene ("HelpMenu");
	} 

	public  void Back() {
		AudioManager.Play (AudioClipName.MenuButtonClick);
		SceneManager.LoadScene ("MainMenu");
	} 
}
