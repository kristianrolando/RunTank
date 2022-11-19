using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float health = 100;
    [SerializeField] Slider healthSlider;

    private void OnEnable()
    {
        UpdateSlider();
    }
    void UpdateSlider()
    {
        healthSlider.value = 1/health;
    }

    public void GotDamage(float damage)
    {
        health -= health;
        UpdateSlider();

        if(health <= 0)
        {
            DieCondition();
        }
    }
    void DieCondition()
    {

    }
}
