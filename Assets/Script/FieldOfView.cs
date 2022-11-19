using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    public GameObject player;
    public bool canSee;
    [Range(0, 360)]
    public float angle;

    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstructionMask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVROutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FOVROutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSee = true;
                }
                else
                {
                    canSee = false;
                }
            }
            else
            {
                canSee = false;
            }
        }
        else if (canSee)
        {
            canSee = false;
        }
    }
}
