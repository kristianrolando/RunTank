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
        rb.velocity = firePoint.forward * speed;
    }

    public override void StoreToPool()
    {
        base.StoreToPool();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null && collision.gameObject.tag == tagTarget)
        {
            collision.gameObject.GetComponent<IDamageable>().GotDamage(damage);
            StoreToPool();
        }
        StoreToPool();
    }
}
