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

    public void Attack(int damage){
        if(true)
        {
            enemy.Damage(damage);
        }
    }

    public void Shield(int shield,Player player)
    {
        if (true)
        {
            player.currentshield += shield;
            print("Shields: " + player.currentshield);
        }
    }
}
