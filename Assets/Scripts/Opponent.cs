using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour, IPlaying
{
    public static Opponent Instance { get; private set; }

    [SerializeField] private List<PlayingCardSO> playingCardSOList = new List<PlayingCardSO>();
    // Opponent can have no more than 2 cards at a time.
    private int maxPlayingCards = 2;

    public void Awake()
    {
        Instance = this;
    }

    // Draws a card and adds it to the playingCardSOList.
    public void DrawCard()
    {
        if (!(playingCardSOList.Count >= maxPlayingCards))
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
