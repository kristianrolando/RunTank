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

    public float fireRate;
    public float rangeShoot;
    public float damagePower;

    public float turnSpeed = 10f;

    [SerializeField]
    private float fireCountdown;

    EnemyShoot shoot;
    private void Awake()
    {
        shoot = GetComponent<EnemyShoot>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FOVROutine());
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
                    player = target.gameObject;
                }
                else
                {
                    canSee = false;
                    player = null;
                }
            }
            else
            {
                canSee = false;
                player = null;
            }
        }
        else if (canSee)
        {
            canSee = false;
            player = null;
        }
    }

    private void Update()
    {
        if (player == null)
        {

            return;
        }
        LockOnTarget();
        if (fireCountdown <= 0f)
        {
            Debug.Log("Shoot");
            shoot.Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = player.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
