using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Waypoint target;
    public Waypoint prevTarget;
    public float speed = 4f;

    public bool isAttacking;

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            return;
        }
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.gameObject.transform.position, step);

        transform.LookAt(target.transform);

        CheckTarget();
    }

    private void Start()
    {
        RandomizePrevTarget();
    }

    private void CheckTarget()
    {
        if(transform.position == target.gameObject.transform.position)
        {
            RandomizeTarget();
        }
    }

    private void RandomizeTarget()
    {
        int size = target.connectedPoint.Count;
        int random = Random.Range(0, size);
        prevTarget = target;
        target = target.connectedPoint[random];
    }

    private void RandomizePrevTarget()
    {
        int size = target.connectedPoint.Count;
        int random = Random.Range(0, size);
        prevTarget = target.connectedPoint[random];
    }

    public void GoBack()
    {
        Waypoint a = target;
        Waypoint b = prevTarget;

        target = b;
        prevTarget = a;
    }
}
