using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DealerManager will handle logic that relates to cards and their functionality.
/// This singleton class will draw cards when appropiate, compare cards played, and deleted 
/// cards played in a hand. 
/// </summary>
public class DealerManager : MonoBehaviour
{
    // Singleton
    public static DealerManager Instance { get; private set; }

    private List<PlayingCardSO> playingCardSOList;

    public void Awake()
    {
        Instance = this;
    }

    // Draws a card and returns it to the appropaite actor (either the player or the opponent).
    // TODO: Implement the appropiate parameter to handle the actor to return the card to.
    public PlayingCardSO DrawCard()
    {
        // Check to see if the playingCardSOList is empty.
        if( playingCardSOList == null)
        {
            Debug.LogError("PlayingCardsList is null! Please make sure that the " +
                "PlayingCardSOList has playingCardSO's in the unity editor!");
        }

        // This is temporary and is only here so that we can run the scene in the unity editor with this script
        // This will be deleted when we get around to proper implementation.
        PlayingCardSO tempPlayingCardSO =  new PlayingCardSO();
        return tempPlayingCardSO;
    }
}
