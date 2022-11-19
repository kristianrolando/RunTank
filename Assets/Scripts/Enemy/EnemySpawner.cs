using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPref;
    [SerializeField] int enemyAmount = 4;
    public PosSpawn[] posSpawn;

    [HideInInspector] public int enemyActive;

    private void Update()
    {
        if(enemyActive < enemyAmount)
        {
            enemyActive += 1;
            Spawn();
        }
    }

    void Spawn()
    {
        int i = Random.Range(0, posSpawn.Length);
        if (!posSpawn[i].isFull)
        {
            GameObject obj = Instantiate(enemyPref, posSpawn[i].pointSpawn.position, Quaternion.identity);
            obj.GetComponent<EnemyHealth>().id = i;
            posSpawn[i].isFull = true;
        }
        else
        {
            Spawn();
        }
    }
}
[System.Serializable]
public class PosSpawn
{
    public Transform pointSpawn;
    [HideInInspector] public bool isFull;
}
