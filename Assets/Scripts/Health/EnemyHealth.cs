using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] Slider healthSlider;

    [HideInInspector] public int id;

    float health;

    private void OnEnable()
    {
        health = maxHealth;
        healthSlider.maxValue = health;
        UpdateSlider();
    }
    void UpdateSlider()
    {
        healthSlider.value = health;
    }

    public void GotDamage(float damage)
    {
        health -= damage;
        UpdateSlider();
        if (health <= 0)
        {
            DieCondition();
        }
    }
    void DieCondition()
    {
        GameObject _spawner = FindObjectOfType<EnemySpawner>().gameObject;
        var _s = _spawner.GetComponent<EnemySpawner>();
        _s.posSpawn[id].isFull = false;
        _s.enemyActive -= 1;
        Destroy(gameObject);
    }
}
