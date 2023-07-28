using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor, IPlaying
{
    // Singleton
    public static Player Instance {  get; private set; }

    public void Awake()
    {
        Instance = this;

        playingCardSOList = new List<PlayingCardSO>();
        lives = 5;
    }

    // Draws a card and adds it to the playingCardSOList.
    public void DrawCard()
    {
        if(!(playingCardSOList.Count >= playingCardsMax))
        {
            playingCardSOList.Add(DealerManager.Instance.GetCard());
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
