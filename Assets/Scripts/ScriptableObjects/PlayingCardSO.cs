using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object for a card in One Poker
/// The only relevant information required in One Poker is the card rank,
/// so the card suit, and color will be omitted since it is not relevant to the game.
/// </summary>
[CreateAssetMenu()]
public class PlayingCardSO : ScriptableObject
{
    // Ranks of cards represented by an enum
    public enum Rank
    {        
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    }

    public Transform cardTransform;   
    public Rank cardRank;
    public string cardName;
    public bool isUpCard;
}
