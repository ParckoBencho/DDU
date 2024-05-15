using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card Data")]
public class CardData : ScriptableObject
{
    public int cost = 0;
    public string description = "Sample Description";
    public string cardName = "Name";
    public Sprite imageRef;
    public string CardType;
    public int CardEffect;
    public Kort cardPrefab;
}
