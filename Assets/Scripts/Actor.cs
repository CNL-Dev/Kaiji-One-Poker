using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Any actor will inherit from this abstract class
/// </summary>
public abstract class Actor : MonoBehaviour
{
    [SerializeField] protected Transform actorLeftHandPoint;
    [SerializeField] protected Transform actorRightHandPoint;
    [SerializeField] protected List<PlayingCardSO> playingCardSOList;
    [SerializeField] protected int lives;

    // Actors can have no more than two cards at any
    // given time.
    protected int playingCardsMax = 2;
}
