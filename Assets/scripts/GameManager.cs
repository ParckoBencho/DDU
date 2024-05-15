using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.TextCore.Text;
using System;

public class GameManager : MonoBehaviour
{
    public Deck deck;
    public int startingHandSize = 10;
    public Transform handPanel; // Parent panel for the drawn cards
    public GameObject cardPrefab; // Prefab of the UI card element
    public GameObject[] enemyPrefab;
    public float cardSpacing = 100f;
    public EnemySpawner enemySpawner;
    public Turns turns;
    public Kort kort;

    void Start()
    {
        Player player = new Player(100, 3,"Player");
        player.turns = turns;
        EncounterStart(player);
    }

    void DrawStartingHand(Player player)
    {

        if(startingHandSize > 10)
        {
            cardSpacing = 70;
        }
        if(startingHandSize > 15)
        {
            cardSpacing = 50;
        }
        // Determine the total width of the hand based on card count and spacing
        float totalWidth = (startingHandSize - 1) * cardSpacing;

        // Calculate the starting x-position to center the cards around the middle
        float startX = -totalWidth / 2f;

        List<CardData> startingHand = deck.DrawCards(startingHandSize);

        int i = 0;
        foreach (CardData cardData in startingHand)
        {
            // Instantiate the card prefab within the hand panel
            GameObject cardObject = Instantiate(cardPrefab, handPanel);
            cardObject.GetComponent<Kort>().cardData = cardData;

            // Set the position of the card relative to the center
            float cardXPosition = startX + cardSpacing * i;
            cardObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(cardXPosition, -175f);

            // Access the UI elements of the card prefab and update them with card data
            UpdateCardUI(cardObject, player);
            i++;
        }
    }

    void UpdateCardUI(GameObject cardObject,Player player)
    {
        kort = cardObject.GetComponent<Kort>();
        CardData cardData = kort.cardData;
        // Access UI elements of the card prefab and update them with card data
        TMP_Text[] variables = cardObject.GetComponentsInChildren<TMP_Text>(true);

        foreach (TMP_Text var in variables)
        {
            if (var.gameObject.name == "Cost") var.text = cardData.cost.ToString();
            if (var.gameObject.name == "Description") var.text = cardData.description;
            if (var.gameObject.name == "Name") var.text = cardData.name;
            
        }

        Button button = cardObject.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            if (cardData.CardType == "Attack")
            {
                kort.Attack(cardData.CardEffect);
            }
            if(cardData.CardType == "Shield")
            {
                kort.Shield(cardData.CardEffect, player);
            }

        });
        Image imageObj = cardObject.GetComponentsInChildren<Image>(true)
            .Skip(1) // Skip the first Image component
            .FirstOrDefault(); // Get the next one or null if none foun
        imageObj.sprite = cardData.imageRef;
    }

    void EncounterStart(Player player)
    {
        DrawStartingHand(player);

        enemySpawner.SpawnEnemy(enemyPrefab);

        turns.StartCombat(player);

    }

}

