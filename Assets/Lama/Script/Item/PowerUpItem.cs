using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField] GameObject[] powerUpItem;
    public ItemPosition[] itemPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckItem();
        }
    }

    public void CheckItem()
    {
        foreach(GameObject objTemp in powerUpItem)
        {
            if (!objTemp.activeInHierarchy)
            {
                StartCoroutine(DelayTime(objTemp));
            }
        }
    }

    IEnumerator DelayTime(GameObject obj)
    {
        yield return new WaitForSeconds(5f);

        obj.SetActive(true);
        //ItemPosition(obj);
        //RandomPos();
    }

    //void ItemPosition(GameObject obj)
    //{
    //    int rand = Random.Range(0, itemPos.Length);

    //    if (!itemPos[rand].isFull)
    //    {
    //        obj.transform.position = itemPos[rand].spawnItemPos.position;
    //        itemPos[rand].isFull = true;
    //    }
    //}

    //void CheckItemPos()
    //{
    //    for (int i = 0; i < itemPos.Length; i++)
    //    {
    //        itemPos[i].isFull = false;

    //        foreach (GameObject posTemp in powerUpItem)
    //        {
    //            if (posTemp.transform.position == itemPos[i].spawnItemPos.position)
    //            {
    //                itemPos[i].isFull = true;
    //            }
    //        }
    //    }
    //}

    //void RandomPos()
    //{
    //    int rand = Random.Range(0, itemPos.Length);

    //    SetItemPosition(rand);
    //}

    //void SetItemPosition(int index)
    //{
    //    if (!itemPos[index].isFull)
    //    {
    //        for (int i = 0; i < powerUpItem.Length; i++)
    //        {
    //            if (!powerUpItem[i].activeInHierarchy)
    //            {
    //                powerUpItem[i].transform.position = itemPos[index].spawnItemPos.position;
    //                //powerUpItem[i].SetActive(true);

    //                CheckItemPos();

    //                break;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        RandomPos();
    //    }
    //}
}
