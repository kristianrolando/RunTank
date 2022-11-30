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
    void UpdateSlider()
    {
        healthSlider.value = health;
    }

    public void GotDamage(float damage)
    {

        AudioPlayer.instance.Play("hit");
        health -= damage;
        UpdateSlider();
        if (health <= 0)
        {
            DieCondition();
        }
    }
    void DieCondition()
    {
        GameManager.instance.GameOver();
    }
    public void HealthEffect(float health)
    {
        
    }
    public void ImmuneEffect(float immune)
    {

    }
}
