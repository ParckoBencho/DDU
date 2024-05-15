using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int Health = 0;
    public string Name = "Name";
    public int MaxDamage = 0;
    public int MinDamage = 0;
    public int MaxShield = 0;
    public int MinShield = 0;
    public int XPosition = 0;
    public int YPosition = 0;
    public int XScale = 0;
    public int YScale = 0;
    public EnemyData enemyData;
    public int currentshield;
}
