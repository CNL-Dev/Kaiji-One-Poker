using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlaying
{
    // Singleton
    public static Player Instance {  get; private set; }
    
    [SerializeField] private List<PlayingCardSO> playingCardSOList = new List<PlayingCardSO>();
    // Players can have no more than 2 cards at a time.
    private int maxPlayingCards = 2;

    public void Awake()
    {
        Instance = this;
    }

    // Draws a card and adds it to the playingCardSOList.
    public void DrawCard()
    {
        if(!(playingCardSOList.Count >= maxPlayingCards))
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
        // Test to see if cards are added to the playingCardSOList.
        for(int i = 0; i < 3 ; i++)
        {
            DrawCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
