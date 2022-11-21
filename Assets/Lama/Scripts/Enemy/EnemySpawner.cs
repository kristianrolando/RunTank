using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPref;
    [SerializeField] int enemyAmount = 4;
    public PosSpawn[] posSpawn;


    public List<Waypoint> waypoint;

    [HideInInspector] public int enemyActive;

    public List<GameObject> enemyList;

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
            EnemyMove move = obj.GetComponent<EnemyMove>();
            move.target = waypoint[i];
            enemyList.Add(obj);
            EnemyHealth health = obj.GetComponent<EnemyHealth>();
            health.spawner = this;
            //posSpawn[i].isFull = true;
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
