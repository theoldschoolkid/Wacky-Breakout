using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Redirects to respective menus
/// </summary>
public class PauseMenuManager : MonoBehaviour {


	public static void GoToMenu( MenuName menuNames )
	{

		switch (menuNames) {

		case MenuName.Pause:
			AudioManager.Play (AudioClipName.PauseGame);
			Object.Instantiate(Resources.Load("PauseMenu"));  // Activates pause menu
			break;

		case MenuName.Return:
			AudioManager.Play (AudioClipName.PauseGame); 
			SceneManager.LoadScene ("MainMenu");    // loads mainmenu
			break;

		}
	}


}
