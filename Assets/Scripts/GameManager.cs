using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance {  get; private set; }

    // Dictates current status of the game
    // e.g playing, paused, etc.
    private enum State
    {
        WaitingToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private bool isGamePaused = false;

    public void Awake()
    {
        Instance = this;

        // We will wait for player input before starting the game.
        // A UI screen with the controls and game instructions will
        // be displayed for the player upon starting.
        state = State.WaitingToStart;
    }
}
