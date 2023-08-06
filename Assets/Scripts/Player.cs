using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor, IPlaying
{
    // Singleton
    public static Player Instance {  get; private set; }

    public event EventHandler OnCardPicked;
    public event EventHandler OnCardRemoved;

    public void Awake()
    {
        Instance = this;

        playingCardSOList = new List<PlayingCardSO>();
        lives = 5;
    }

    void Start()
    {
        DealerManager.Instance.OnPlayerDraw += DealerManager_OnPlayerDraw;
        DealerManager.Instance.OnPlayerTurn += DealerManager_OnPlayerTurn;
    }

    private void DealerManager_OnPlayerTurn(object sender, EventArgs e)
    {
        //PlayCard();
    }

    private void DealerManager_OnPlayerDraw(object sender, EventArgs e)
    {
        DrawCard();
    }

    // Draws a card and adds it to the playingCardSOList.
    public void DrawCard()
    {
        if(!(playingCardSOList.Count >= playingCardsMax))
        {
            playingCardSOList.Add(DealerManager.Instance.GetCard());
            OnCardPicked?.Invoke(this, EventArgs.Empty);
        }

        // Spawns a card in the appropiate player hand.
        if (playingCardSOList[0] is PlayingCardSO && actorLeftHandPoint.childCount < 1)
        {
            DealerManager.Instance.SpawnCard(playingCardSOList[0], actorLeftHandPoint);
        }
        else if (playingCardSOList[1] is PlayingCardSO && actorRightHandPoint.childCount < 1)
        {
            DealerManager.Instance.SpawnCard(playingCardSOList[1], actorRightHandPoint);
        }
    }

    // This should take input from a player action.
    // I think all actions should be handled by mouse clicks.
    public PlayingCardSO PlayCard()
    {
        throw new NotImplementedException();
    }

    // Removes the card at the provided index.
    public void RemoveCard(int index)
    {
        playingCardSOList.RemoveAt(index);
        OnCardRemoved?.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        // This is purely for testing purposes 
        // Will be deleted later.
        if(playingCardSOList.Count < 3)
        {
            DrawCard();
        }       
    }
}
