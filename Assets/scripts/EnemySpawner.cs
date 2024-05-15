using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void SpawnEnemy(GameObject[] enemyPrefabs)
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogWarning("Enemy prefabs list is empty.");
            return;
        }

        // Choose a random enemy prefab
        int chosenEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[chosenEnemyIndex];

        // Get the Enemyscript component attached to the chosen enemy prefab
        Enemyscript enemyScript = enemyPrefab.GetComponent<Enemyscript>();

        if (enemyScript == null || enemyScript.EnemyData == null)
        {
            Debug.LogWarning("Enemyscript or EnemyData reference not found on the chosen enemy prefab.");
            return;
        }

        // Get the position from the Enemyscript component
        Vector3 enemyPosition = new Vector3(enemyScript.EnemyData.XPosition, enemyScript.EnemyData.YPosition, 0f);
        Vector3 enemyScale = new Vector3(enemyScript.EnemyData.XScale, enemyScript.EnemyData.YScale, 1f);

        // Instantiate the chosen enemy prefab at the specified position
        GameObject enemyObject = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        enemyObject.transform.localScale = enemyScale;
    }
}