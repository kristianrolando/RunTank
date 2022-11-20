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
    [SerializeField] float fireRate = 5f;
    [SerializeField] Bullet bulletPref;
    PoolingSystem pool = new PoolingSystem();

    float time;
    bool isCanShoot;

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f)
        {
            isCanShoot = true;
            time = 1 / fireRate;
        }
        if (Input.GetKeyDown(shootInput) && isCanShoot)
        {
            Shoot();
            isCanShoot = false;
            time = 1 / fireRate;
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

    public void SetShootInput(KeyCode key)
    {
        shootInput = key;
    }
}
