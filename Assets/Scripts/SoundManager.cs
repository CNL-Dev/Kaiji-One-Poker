using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton
    public static SoundManager Instance { get; private set; }

    private float volume = 1f;

    private void Awake()
    {
        Instance = this; 
    }

    // Plays a audio clip within the world space.
    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }
}
