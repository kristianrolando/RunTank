using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float damageBullet;
    [SerializeField] string tagTarget = "Enemy";
    [SerializeField] KeyCode shootInput;

    [SerializeField] Bullet bulletPref;
    PoolingSystem pool = new PoolingSystem();

    private void Update()
    {
        if(Input.GetKeyDown(shootInput))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject _bullet = CreateObject(firePoint.position);
        var b = _bullet.GetComponent<Bullet>();
        b.damage = damageBullet;
        b.speed = bulletSpeed;
        b.tagTarget = tagTarget;
        b.Move(firePoint);
    }

    public GameObject CreateObject(Vector3 pos)
    {
        return pool.CreateObject(bulletPref, pos).gameObject;
    }
}
