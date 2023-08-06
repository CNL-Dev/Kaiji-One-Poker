using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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

    public event EventHandler OnPlayerDraw;
    public event EventHandler OnOpponentDraw;
    public event EventHandler OnPlayerTurn;
    public event EventHandler OnOpponentTurn;

    // This state will determine the flow of
    // the game. Certain actions and events
    // will occur during these states.
    private enum State
    {
        Inactive,
        PlayerDraw,
        OpponentDraw,
        PlayerTurn,
        OpponentTurn,
        Comparison,
        ResetTurn,
    }

    [SerializeField] private List<PlayingCardSO> playingCardSOList;
    private PlayingCardSO playerPlayingCard;
    private PlayingCardSO opponentPlayingCard;
    private State state;

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

        // Selects either the first or second card.
        int randomNum = UnityEngine.Random.Range(0, playingCardSOList.Count);

        return playingCardSOList[randomNum];
    }

    // Spawn a card in the appropiate spot within a scene.
    public void SpawnCard(PlayingCardSO playingCardSO, Transform parent)
    {
        Transform playingCardTransform = Instantiate(playingCardSO.cardTransform, parent);
        PlayingCardObject playingCardObject = playingCardTransform.GetComponent<PlayingCardObject>();
    }

    // Compares the cards that the two actors have played and determines a winner
    // and loser or if its a draw.
    private PlayingCardSO CompareCards(PlayingCardSO playerCard, PlayingCardSO opponentCard)
    {
        // Check if player has played a higher rank card
        if (playerCard.cardRank > opponentCard.cardRank)
        {
            // A 2 beats an Ace, the only instance of a down card
            // beating an up card
            if (playerCard.cardRank == PlayingCardSO.Rank.Ace &&
                opponentCard.cardRank == PlayingCardSO.Rank.Two)
            {
                return opponentCard;
            }

            // Player wins
            return playerCard;
        }
        // Check if opponent has played a higher rank card
        else if (playerCard.cardRank < opponentCard.cardRank)
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

    private void Update()
    {
        // Determines state of the current game.
        // TODO: Implement appropiate logic for each case.
        switch (state)
        {
            // Game has not started, so wait.
            case State.Inactive:
                break;
            case State.PlayerDraw:
                // Stuff goes here!
                OnPlayerDraw?.Invoke(this, EventArgs.Empty);
                state = State.OpponentDraw;
                break;
            case State.OpponentDraw:
                // Stuff goes here!
                OnOpponentDraw?.Invoke(this, EventArgs.Empty);  
                state = State.PlayerTurn;    
                break;
            case State.PlayerTurn:
                // Stuff goes here!
                OnPlayerTurn?.Invoke(this, EventArgs.Empty);
                state = State.OpponentTurn;
                break;
            case State.OpponentTurn:
                // Stuff goes here!
                OnOpponentTurn?.Invoke(this, EventArgs.Empty);
                state = State.Comparison;
                break;
            case State.Comparison:
                // Stuff goes here!
                // CompareCards();
                state = State.ResetTurn;
                break;
            case State.ResetTurn:
                // Stuff goes here!
                state = State.PlayerDraw;
                break;
        }
    }

    // Starts the game proper.
    private void StartCardGame()
    {
        if(state == State.Inactive)
            state = State.PlayerDraw;
    }

    // Setters for the player and opponent playingCardSO.
    private void SetPlayerPlayingCard(PlayingCardSO playingCardSO)
    {
        playerPlayingCard = playingCardSO;
    }

    private void SetOpponentPlayingCard(PlayingCardSO playingCardSO)
    {
        opponentPlayingCard = playingCardSO;
    }
}
