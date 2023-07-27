using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface that will be implemented by any 
/// actor that is playing the game.
/// </summary>
public interface IPlaying
{
    // Actor will draw a card
    public void DrawCard();

    // Actor will play a card in their inventory
    public PlayingCardSO PlayCard();

    // Removes a card from the actor inventory
    public void RemoveCard(int index);
}
