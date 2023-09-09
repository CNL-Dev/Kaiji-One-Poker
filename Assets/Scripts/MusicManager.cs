using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // const string for the playerprefs volume
    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    // Singleton
    public static MusicManager Instance { get; private set; }

    private float volume = 1f;

    private void Awake()
    {
        Instance = this; 
    }

    // Adjust the volume by either increasing or decreasing it.
    public void ChangeVolume(bool increased)
    {
        // If volume is being increased, raise it by 0.1f, if not then lower it
        // by the same amount. Ignore the request if the volume is either muted
        // (at 0.0f) or maxed out (at 1f).
        if (increased && volume < 1f)
        {
            volume += 0.1f;
        }
        else if (volume > 0f)
        {
            volume -= 0.1f;
        }

        // Save the player prefs for volume
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
        PlayerPrefs.Save();
    }
}
