using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject
{
    [HideInInspector]
    public float speed = 5f;
    [HideInInspector]
    public string tagTarget;
    [HideInInspector]
    public float damage;

    Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        //Invoke("StoreToPool", 3f);
    }
    public void Move(Transform firePoint)
    {
        Debug.Log("Move");
        rb.velocity = firePoint.forward * speed;
    }

    public override void StoreToPool()
    {
        base.StoreToPool();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null && other.gameObject.tag == tagTarget)
        {
            other.gameObject.GetComponent<IDamageable>().GotDamage(damage);
            StoreToPool();
        }
        StoreToPool();
    }
}
