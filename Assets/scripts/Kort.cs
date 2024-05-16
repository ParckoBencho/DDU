using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Kort : MonoBehaviour
{
    [Header("Setup variables")]
    public TMP_Text costText;
    public TMP_Text descriptionText;
    public TMP_Text nameText;
    public Image imageObj; // reference to gameobject in the scene
    public Sprite imageRef; // image reference i your project folder

    public CardData cardData;

    Enemyscript enemy;

    private void Start()
    {
        enemy = GameObject.FindFirstObjectByType<Enemyscript>();

    }

    // Default Values
    public int cost = 0;
	public string description = "Sample Description";
	public string cardName = "Ma,e"; // my id

    public void Attack(int damage,int cost,Player player){
        if(player.Energy >= cost)
        {
            player.Energy -= cost;
            enemy.Damage(damage);
            player.energyText.text = "Energy: " + player.Energy.ToString();
        }
    }

    public void Shield(int shield,Player player,int cost)
    {
        if (player.Energy >= cost)
        {
            player.Energy -= cost;
            player.currentshield += shield;
            player.shieldText.text = "Shield: " + player.currentshield.ToString();
            player.energyText.text = "Energy: " + player.Energy.ToString();
        }
    }
}
