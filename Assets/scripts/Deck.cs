using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardData> cardTypes; // List of card types

    public List<CardData> DrawCards(int count)
    {
        List<CardData> drawnCards = new List<CardData>();
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, cardTypes.Count);
            drawnCards.Add(cardTypes[randomIndex]);
        }
        return drawnCards;
    }
}