using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float health = 100f;

    public void GotDamage(float damage)
    {
        health -= health;
    }
}
