using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager, add audio clips from the Resource folder to a variable
    /// </summary>
    
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
		audioClips.Add(AudioClipName.BallHitPaddle, 
			Resources.Load<AudioClip>("BallHitPaddle"));
		audioClips.Add(AudioClipName.MenuButtonClick,
			Resources.Load<AudioClip>("MenuButtonClick"));
		audioClips.Add(AudioClipName.PauseGame,
			Resources.Load<AudioClip>("PauseGame"));
		audioClips.Add(AudioClipName.BrickBreak,
			Resources.Load<AudioClip>("BrickBreak"));
	}  

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
