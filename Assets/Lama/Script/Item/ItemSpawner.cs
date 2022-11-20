using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItemPosition[] itemPos;
    [SerializeField] GameObject[] item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsItemNotActive())
        {
            RandomPos();
        }
    }

    bool IsItemNotActive()
    {
        for(int i = 0; i < item.Length; i++)
        {
            if (!item[i].activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    void CheckItemPos()
    {
        for (int i = 0; i < itemPos.Length; i++)
        {
            itemPos[i].isFull = false;

            foreach (GameObject posTemp in item)
            {
                if(posTemp.transform.position == itemPos[i].spawnItemPos.position)
                {
                    itemPos[i].isFull = true;
                }
            }
        }
    }

    void RandomPos()
    {
        int rand = Random.Range(0, itemPos.Length);

        SetItemPosition(rand);
    }

    void SetItemPosition(int index)
    {
        if (!itemPos[index].isFull)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (!item[i].activeInHierarchy)
                {
                    item[i].transform.position = itemPos[index].spawnItemPos.position;
                    item[i].SetActive(true);

                    CheckItemPos();

                    break;
                }
            }
        }
        else
        {
            RandomPos();
        }
    }
}
