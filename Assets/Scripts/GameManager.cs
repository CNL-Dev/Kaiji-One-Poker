using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance {  get; private set; }

    public void Awake()
    {
        Instance = this; 
    }
}
