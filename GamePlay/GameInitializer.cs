using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game, the static classes
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
		
        ScreenUtils.Initialize();
		ConfigurationUtils.Initialize ();
    }
}
