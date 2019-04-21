using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	// Use this for initialization
	public static int score;

	[SerializeField]
	Text scoreText;    // Text field that displays the Score in the UI


	void Start () {
		
		EventManager.AddHUDListner (UpdateScore); // Add "UpdateScore" function as a listner
        score = 0;
		scoreText.text = "Score: " + score;

	}
	
	void UpdateScore(int sc)
	{
		
		score += sc;
		scoreText.text = "Score: " + score;
	
	}

}
