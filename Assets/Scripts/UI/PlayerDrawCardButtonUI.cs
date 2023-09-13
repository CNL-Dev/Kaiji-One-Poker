using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Handles the player drawing a card when prompted.
public class PlayerDrawCardButtonUI : MonoBehaviour
{
    [SerializeField] private Button playerDrawCardButton;

    private void Awake()
    {
        playerDrawCardButton.onClick.AddListener(() =>
        {
            Player.Instance.DrawCard();
        });
    }
}
