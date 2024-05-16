using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Character
{
    public int Health;
    public string Name;
    public int Energy;
    public int MaxEnergy;
    public Turns turns;
    public int currentshield;
    public TMP_Text healthText;
    public TMP_Text shieldText;
    public TMP_Text energyText;

    public Character(int startingHealth,int startingEnergy, string name)
    {
        Health = startingHealth;
        Name = name;
        currentshield = 0;
        MaxEnergy = startingEnergy;
        Energy = startingEnergy;
    }

    public void TakeDamage(int Damage)
    {
        if (Damage - currentshield >= 0)
        {
            Health -= Damage - currentshield;
        } else
        {
            currentshield -= Damage;
        }
        if(currentshield < 0)
        {
            currentshield = 0;
        }
        


        if(Name == "Player")
        {
            healthText.text = "Health: " + Health.ToString();
            shieldText.text = "Shield: " + currentshield.ToString();
        }

        if(Health <= 0)
        {
            Debug.Log(Name + " has perished.");
            if(Name == "Player")
            {
                turns.Death();
            }
        }
    }
}
public class Player: Character
{

    public Player(int startingHealth, int startingEnergy, string name) : base(startingHealth, startingEnergy,name) 
    {

        healthText = GameObject.Find("PlayerHealthText").GetComponent<TMP_Text>();
        healthText.text = "Health: " + Health;
        
        shieldText = GameObject.Find("PlayerShieldText").GetComponent<TMP_Text>();
        shieldText.text = "Shield: " + currentshield;

        energyText = GameObject.Find("PlayerEnergyText").GetComponent<TMP_Text>();
        energyText.text = "Energy: " + Energy;
    }


}


