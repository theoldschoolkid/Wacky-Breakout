using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Runs on gameplay scene checks if escape key is pressed
/// </summary>
public class CheckForPauseAndGameOver : MonoBehaviour {

	bool gameOver = false;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {            
			PauseMenuManager.GoToMenu (MenuName.Pause);     // Activate pause menu when escape key is pressed
		}


		if (EventManager.NumberOfBlocks == 0 && gameOver == false) {  // Display gameover screen when all blocks are destroyed
			Time.timeScale = 0;
			gameOver = true;
			Instantiate(Resources.Load("GameOver"));
		}
	}

}
