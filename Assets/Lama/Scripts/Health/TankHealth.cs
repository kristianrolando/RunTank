using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TankHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] Slider healthSlider;

    float health;

    private void OnEnable()
    {
        health = maxHealth;
        healthSlider.maxValue = health;
        UpdateSlider();
    }
    bool isImmune;
    float timer;
    private void Update()
    {
        if(isImmune)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isImmune = false;
            }
        }
        
    }
    void UpdateSlider()
    {
        healthSlider.value = health;
    }

    public void GotDamage(float damage)
    {
        if(!isImmune)
        {
            health -= damage;
            UpdateSlider();
            if (health <= 0)
            {
                DieCondition();
            }
        }
    }
    void DieCondition()
    {

    }
    public void HealthEffect(float health)
    {
        this.health += health;
    }
    public void ImmuneEffect(float immune)
    {
        isImmune = true;
        timer = immune;
    }
}
