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

    public GameObject plyr;

    Rigidbody rb;
    Vector3 startPos;

    public bool fromPlayer;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
    private void Update()
    {
        if(Vector3.Distance(startPos, transform.position) > 50f)
        {
            StoreToPool();
        }
    }
    public void Move(Transform firePoint)
    {
        rb.velocity = firePoint.forward * speed;
    }

    public override void StoreToPool()
    {
        base.StoreToPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null && other.gameObject.tag == tagTarget && other.gameObject == plyr && !fromPlayer)
        {
            Instantiate(vfxList.instance.vfxs[1], gameObject.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<IDamageable>().GotDamage(damage);
            StoreToPool();

            return;
        }
        if (other.gameObject.tag == "Detector" && fromPlayer)
        {
            Instantiate(vfxList.instance.vfxs[1], gameObject.transform.position, Quaternion.identity);
            other.GetComponent<EnemyDetector>().GotDamage(damage);
            StoreToPool();

            return;
        }

        if (other.gameObject.tag == "Tembok")
        {
            Instantiate(vfxList.instance.vfxs[1], gameObject.transform.position, Quaternion.identity);
            StoreToPool();
            AudioPlayer.instance.Play("hit");
            return;
        }
    }
}
