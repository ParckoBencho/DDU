using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Character
{
    public int Health;
    public string Name;
    public Turns turns;

    public Character(int startingHealth, string name)
    {
        Health = startingHealth;
        Name = name;
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        Debug.Log(Health);
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
    public int Energy;
    public int currentshield;
    public Player(int startingHealth, int startingEnergy, string name) : base(startingHealth, name) 
    {
        Energy = startingEnergy;
        currentshield = 0;
    }

    public void UseEnergy(int Used)
    {
        Energy -= Used;
    }
}

public class Enemy: Character
{
    public int MinDamage;
    public int MaxDamage;
    public int MinShield;
    public int MaxShield;
    public Enemy(int startingHealth, int minDamage, int maxDamage, string name, int minShield, int maxShield) : base(startingHealth, name)
    {
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        MinShield = minShield;
        MaxShield = maxShield;
    }
}
