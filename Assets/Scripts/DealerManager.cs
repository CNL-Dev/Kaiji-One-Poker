using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DealerManager will handle logic that relates to cards and their functionality.
/// This singleton class will draw cards when appropiate, compare cards played, and delete
/// cards played in a hand. 
/// </summary>
public class DealerManager : MonoBehaviour
{
    // Singleton
    public static DealerManager Instance { get; private set; }

    [SerializeField] private List<PlayingCardSO> playingCardSOList;
    private PlayingCardSO playerPlayingCard;
    private PlayingCardSO opponentPlayingCard;

    public void Awake()
    {
        Instance = this;
    }

    // Gets a card and returns it to the actor.
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

    // Compares the cards that the two actors have played and determines a winner
    // and loser or if its a draw.
    private PlayingCardSO CompareCards(PlayingCardSO playerCard, PlayingCardSO opponentCard)
    {
        // 
        if(playerCard.cardRank > opponentCard.cardRank)
        {
            // A 2 beats an Ace, the only instance of a down card
            // beating an up card
            if(playerCard.cardRank == PlayingCardSO.Rank.Ace && 
                opponentCard.cardRank == PlayingCardSO.Rank.Two)
            {
                return opponentCard;
            }

            // Player wins
            return playerCard;
        }
        // 
        else if(playerCard.cardRank < opponentCard.cardRank)
        {
            if (opponentCard.cardRank == PlayingCardSO.Rank.Ace &&
                playerCard.cardRank == PlayingCardSO.Rank.Two)
            {
                return playerCard;
            }

            // Opponent wins
            return opponentCard;
        }

        // If neither side has won, then they have played cards of
        // equal value, which results in a draw 
        // which is represented by null.
        return null;
    }


}
