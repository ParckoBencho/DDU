using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour//Statemachine
{
    // Start is called before the first frame update

    public Character Player;
    public EnemyData EnemyData;



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
        if (canSwitchState)
        {
            // Check for input to switch between states
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchState();
                canSwitchState = false;
            }
        }
        else
        {
            // Check if the "E" key is released to enable state switching again
            if (Input.GetKeyUp(KeyCode.E))
            {
                canSwitchState = true;
            }
        }
    }

    private void SwitchState()
    {
        if(EnemyData.currentshield != 0)
        {
            EnemyData.currentshield = 0;
        }
        switch (currentState)
        {
            case TurnState.PlayerTurn:
                currentState = TurnState.EnemyTurn;
                Debug.Log("Enemy's Turn");
                int EnemyAction = Random.Range(0, 2);
                if (EnemyAction == 0) {  //Attack
                    int Damage = Random.Range(EnemyData.MinDamage, EnemyData.MaxDamage + 1);
                    print(EnemyData.name + " Attacks for " + Damage + " Damage");
                    Player.TakeDamage(Damage);
                }
                else //Shield
                {
                    int shield = Random.Range(EnemyData.MinShield,EnemyData.MaxShield);
                    print(EnemyData.name + " shields itself for " + shield + " Damage");
                    EnemyData.currentshield = shield;
                }
                break;
            case TurnState.EnemyTurn:
                currentState = TurnState.PlayerTurn;
                Debug.Log("Player's Turn");
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
        currentState = TurnState.GameOver;
        Debug.Log("You Win");
    }

    public void Death() 
    {
        currentState = TurnState.GameOver;
        Debug.Log("Game Over");
    }
}
