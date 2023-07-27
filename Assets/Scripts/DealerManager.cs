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

    [SerializeField] private List<PlayingCardSO> playingCardSOList;

    public void Awake()
    {
        Instance = this;
    }

    // Gets a card and returns it to the appropiate actor (either the player or the opponent).
    // TODO: Implement the appropiate parameter to handle the actor to return the card to.
    public PlayingCardSO GetCard()
    {
        // Check to see if the playingCardSOList is empty.
        if( playingCardSOList == null)
        {
            Debug.LogError("PlayingCardsList is null! Please make sure that the " +
                "PlayingCardSOList has playingCardSO's in the unity editor!");
        }

        int randomNum = UnityEngine.Random.Range(0, playingCardSOList.Count);

        return playingCardSOList[randomNum];
    }


}
