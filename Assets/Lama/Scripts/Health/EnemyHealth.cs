using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] Slider healthSlider;

    [HideInInspector] public int id;

    public EnemySpawner spawner;

    public EnemyDetector detector;

    float health;

    private void Start()
    {
        detector.spawner = spawner;
        detector.health = this;
    }
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
        Instantiate(vfxList.instance.vfxs[0], gameObject.transform.position, Quaternion.identity);
        AudioPlayer.instance.Play("die");
        GameObject _spawner = FindObjectOfType<EnemySpawner>().gameObject;
        var _s = _spawner.GetComponent<EnemySpawner>();
        _s.posSpawn[id].isFull = false;
        _s.enemyActive -= 1;
        int idx = spawner.enemyList.IndexOf(gameObject);
        spawner.enemyList.RemoveAt(idx);

        GameManager.instance.AddScore();
        Destroy(gameObject);
    }
}
