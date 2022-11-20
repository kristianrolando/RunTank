using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public EnemySpawner spawner;
    public EnemyHealth health;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyMove move = health.gameObject.GetComponent<EnemyMove>();
          //  move.GoBack();
            checkIndex(other.gameObject);
        }
    }

    private void checkIndex(GameObject obj)
    {
        int myIdx= spawner.enemyList.IndexOf(health.gameObject);
        int otherIdx = spawner.enemyList.IndexOf(obj);

        if(myIdx < otherIdx)
        {
            EnemyMove move = health.gameObject.GetComponent<EnemyMove>();
            move.GoBack();
        }
    }
}
