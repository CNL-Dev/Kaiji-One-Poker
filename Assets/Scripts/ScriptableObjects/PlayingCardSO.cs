using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayingCardSO : ScriptableObject
{
    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Jack,
        Queen,
        King,
    }

    /// <summary>
    /// Scriptable object for a card in One Poker
    /// The only relevant information required in One Poker is the card rank,
    /// so the card suit, and color will be omitted since it is not relevant to the game.
    /// </summary>
    public Transform cardTransform;   
    public Rank cardRank;
    public string cardName;
    public bool isUpCard;
}
