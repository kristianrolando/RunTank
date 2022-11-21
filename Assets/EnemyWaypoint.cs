using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoint : MonoBehaviour
{

    private EnemyMove move;
    private void Start()
    {
        move = transform.parent.gameObject.GetComponent<EnemyMove>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == move.target.gameObject)
        {
            move.RandomizeTarget();
            //checkIndex(other.gameObject);
        }
    }
    
}
