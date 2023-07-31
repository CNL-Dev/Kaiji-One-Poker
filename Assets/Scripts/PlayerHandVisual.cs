using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shows and hides the players's hand when a card is 
/// obtained or removed.
/// </summary>
public class PlayerHandVisual : MonoBehaviour
{
    [SerializeField] private Transform actorHandVisual;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player.OnCardPicked += Player_OnCardPicked;
        player.OnCardRemoved += Player_OnCardRemoved;
    }

    private void Player_OnCardRemoved(object sender, EventArgs e)
    {
        Hide();
    }

    private void Player_OnCardPicked(object sender, EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(true);
    }
}
