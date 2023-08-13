using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Singleton
    public static MusicManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }
}
