using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour//Statemachine
{
    // Start is called before the first frame update

    public Character Player;
    public EnemyData EnemyData;
    private bool gameWon = false;



    public enum TurnState
    {
        PlayerTurn,
        EnemyTurn,
        GameOver
    }

    private TurnState currentState = TurnState.PlayerTurn;
    private bool canSwitchState = true;

    void Update()
    {
        if (canSwitchState && !gameWon)
        {
            // Check for input to switch between states
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchState();
                canSwitchState = false;
            }
        }
        else
        {
            // Check if the "E" key is released to enable state switching again
            if (Input.GetKeyUp(KeyCode.Space))
            {
                canSwitchState = true;
            }
        }
    }

    private void SwitchState()
    {
        switch (currentState)
        {
            case TurnState.PlayerTurn:
                currentState = TurnState.EnemyTurn;
                Debug.Log("Enemy's Turn");
                if (EnemyData.currentshield != 0)
                {
                    EnemyData.currentshield = 0;

                }
                int EnemyAction = Random.Range(0, 2);
                if (EnemyAction == 0)
                {  //Attack
                    int Damage = Random.Range(EnemyData.MinDamage, EnemyData.MaxDamage + 1);
                    print(EnemyData.name + " Attacks for " + Damage + " Damage");
                    Player.TakeDamage(Damage);
                }
                else //Shield
                {
                    int shield = Random.Range(EnemyData.MinShield, EnemyData.MaxShield);
                    print(EnemyData.name + " shields itself for " + shield + " Damage");
                    EnemyData.currentshield = shield;
                }
                break;
            case TurnState.EnemyTurn:
                currentState = TurnState.PlayerTurn;
                Debug.Log("Player's Turn");
                if (Player.currentshield != 0)
                {
                    Player.currentshield = 0;
                    Player.shieldText.text = "Shield: " + Player.currentshield;
                }
                Player.Energy = Player.MaxEnergy;
                Player.energyText.text = "Energy: " + Player.Energy;
                break;
            case TurnState.GameOver:
                break;
        }
    }

    public void StartCombat(Character player)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            // Access the Enemyscript component of the first enemy GameObject
            Enemyscript enemyScript = enemies[0].GetComponent<Enemyscript>();

            if (enemyScript != null)
            {
                // Assign the EnemyData from the Enemyscript component
                EnemyData = enemyScript.EnemyData;
            }
            else
            {
                Debug.LogError("Enemyscript component not found on the enemy GameObject.");
            }
        }
        else
        {
            Debug.LogError("No enemy GameObjects found with the specified tag.");
        }
        Player = player;

        currentState = TurnState.PlayerTurn;
        Debug.Log("Combat started: Player's Turn");
    }
    public void CombatWin()
    {
        gameWon = true;
        currentState = TurnState.GameOver;
        Debug.Log("You Win");
    }

    public bool IsGameWon()
    {
        return gameWon;
    }

    public void Death()
    {
        currentState = TurnState.GameOver;
        Debug.Log("Game Over");
    }
}
