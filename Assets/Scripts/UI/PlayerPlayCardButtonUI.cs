using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// handles the selection of a player card when prompted.
public class PlayerPlayCardButtonUI : MonoBehaviour
{
    [SerializeField] private Button playerPlayCardButton;
    [SerializeField] private TextMeshProUGUI playerPlayCardButtonText;
    [SerializeField] private int buttonIndex; // 0 for left button, 1 for right button.

    private void Awake()
    {
        playerPlayCardButton.onClick.AddListener(() =>
        {
            // Player.Instance.PlayCard();
            Player.Instance.RemoveCard(buttonIndex);
        });
    }

    private void Update()
    {
        UpdateButtonText();
    }

    // Updates the button text to display the name of the current card.
    private void UpdateButtonText()
    {
        playerPlayCardButtonText.text = Player.Instance.GetPlayingCardSO(buttonIndex).cardName;
    }
}
