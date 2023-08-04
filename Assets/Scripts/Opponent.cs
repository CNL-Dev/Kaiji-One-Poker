using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : Actor, IPlaying
{
    public static Opponent Instance { get; private set; }

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
        DealerManager.Instance.OnOpponentDraw += DealerManager_OnOpponentDraw;
        DealerManager.Instance.OnOpponentTurn += DealerManager_OnOpponentTurn;
    }

    private void DealerManager_OnOpponentTurn(object sender, EventArgs e)
    {
        //PlayCard();
    }

    private void DealerManager_OnOpponentDraw(object sender, EventArgs e)
    {
        DrawCard();
    }

    // Draws a card and adds it to the playingCardSOList.
    public void DrawCard()
    {
        if (!(playingCardSOList.Count >= playingCardsMax))
        {
            playingCardSOList.Add(DealerManager.Instance.GetCard());
            OnCardPicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public PlayingCardSO PlayCard()
    {
        throw new System.NotImplementedException();
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
        
    }
}
