using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            string nameTemp = other.gameObject.GetComponent<Item>().itemPlayer;

            if (nameTemp == gameObject.name)
            {
                Debug.Log("RIGHT ITEM");
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("WRONG ITEM");
            }
        }

        if(other.gameObject.tag == "PowerUpItem")
        {
            PowerUpItem pwItem = GameObject.Find("Power Up Item Generator").GetComponent<PowerUpItem>();
            pwItem.CheckItem();
        }
    }
}
