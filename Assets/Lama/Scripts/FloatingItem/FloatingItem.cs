using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public enum ItemType { health, immune}
    [SerializeField] ItemType typeItem;
    [SerializeField] float immune_time = 10f;
    [SerializeField] float health_recover = 20f;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject _obj = collision.gameObject;
            GetEffect(_obj);
            Destroy(gameObject);
        }
    }
    void GetEffect(GameObject obj)
    {
        switch (typeItem)
        {
            case ItemType.health:
                Health(obj);
                break;
            case ItemType.immune:
                Immune(obj);
                break;
            default:
                break;
        }
    }
    void Health(GameObject obj)
    {
        obj.GetComponent<TankHealth>().HealthEffect(health_recover);
    }
    void Immune(GameObject obj)
    {
        obj.GetComponent<TankHealth>().HealthEffect(immune_time);
    }

}
