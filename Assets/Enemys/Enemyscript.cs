using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    public EnemyData EnemyData;
    public string assetName;
    public Turns turns;


    int health;
    int shield;

    [SerializeField]
    TMP_Text healthText;
    TMP_Text shieldText;


    private void Start()
    {
        health = EnemyData.Health;
        healthText = GameObject.Find("HealthText").GetComponent<TMP_Text>();
        healthText.text = "Health: " + health;

        shield = EnemyData.currentshield;
        shieldText = GameObject.Find("ShieldText").GetComponent<TMP_Text>();
        shieldText.text = "Shield: " + shield;

        turns = FindObjectOfType<Turns>();
    }

    private void Update()
    {
        shieldText.text = "Shield: " + EnemyData.currentshield;

        if (health <= 0 && !turns.IsGameWon())
        {
            turns.CombatWin();
            health = 0;
            healthText.text = "Health: " + health.ToString();
        }
    }

    public void Damage(int amount)
    {
        health -= amount-EnemyData.currentshield;
        EnemyData.currentshield -= amount;
        if (EnemyData.currentshield <= 0)
        {
            EnemyData.currentshield = 0;
        }
        if (!turns.IsGameWon())
        {
            healthText.text = "Health: " + health.ToString();
        }
    }
}
