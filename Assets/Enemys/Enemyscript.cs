using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    public EnemyData EnemyData;
    public string assetName;

    int health;

    [SerializeField]
    TMP_Text healthText;

    //Character character;

    private void Start()
    {
        health = EnemyData.Health;
        healthText = GameObject.Find("HealthText").GetComponent<TMP_Text>();
        healthText.text = "Health: " + health;
        
    }

    public void Damage(int amount)
    {
        if(EnemyData.currentshield <= 0)
        {
            EnemyData.currentshield = 0;
        }
        health -= amount-EnemyData.currentshield;
        EnemyData.currentshield -= amount;
        Debug.Log(health);
        healthText.text = "Health: " + health.ToString();
    }


}
