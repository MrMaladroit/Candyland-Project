using UnityEngine;
using System;

public class Deck : MonoBehaviour
{
    public static Action<TileType, bool> DrawnCard;

    [SerializeField] private Card[] cards;
    [SerializeField] private int startingCardCount = 10;

    private Card[] deck;
    private int index = 0;

    private void Start()
    {
        deck = new Card[startingCardCount];
        ConstructDeck();
        index = 0;
    }

    private void OnDisable()
    {
        Array.Clear(deck, 0, deck.Length);
    }

    public void DrawCard()
    {
        Debug.Log(deck[index]);
        DrawnCard(deck[index].TileType, deck[index].IsDouble);
        index++;
    }

    public void ConstructDeck()
    {
        for(int i = 0; i < startingCardCount; i++)
        {
            deck[i] = RandomCard();
        }
    }

    private Card RandomCard()
    {
        int randomIndex = UnityEngine.Random.Range(0, cards.Length);
        return cards[randomIndex];
    }
}