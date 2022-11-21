using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{

    public int index;
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == other.gameObject.name)
        {
            ItemManager.instance.SpawnItem(index);
            Destroy(gameObject);
        }
    }
}
