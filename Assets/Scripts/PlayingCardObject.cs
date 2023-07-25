using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingCardObject : MonoBehaviour
{
    [SerializeField] private PlayingCardSO playingCardSO;

    // Returns the rank of the playing card
    public PlayingCardSO.Rank GetRank()
    {
        return playingCardSO.cardRank;
    }

    // Returns true if the card is an upcard (e.g: rank 8 - King).
    public bool GetIsUpCard()
    {
        return playingCardSO.isUpCard;
    }

    // Destroy the playing card object when it is no longer needed
    // E.G: Played in a hand.
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
