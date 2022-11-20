using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public EnemySpawner spawner;
    public EnemyHealth health;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Detector")
        {
            EnemyMove move = health.gameObject.GetComponent<EnemyMove>();
            move.GoBack();
           // checkIndex(other.gameObject);
        }
    }

    public void GotDamage(float dmg)
    {
        EnemyHealth hlth = transform.parent.gameObject.GetComponent<EnemyHealth>();
        hlth.GotDamage(dmg);
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
