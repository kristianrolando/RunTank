using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public GameObject itemPrefabs;

    public float countDown1;
    public float countDown2;

    [SerializeField]
    private int jumlahItem;

    private int counter1;
    private int counter2;


    [SerializeField]
    private List<Transform> spawnPoint;

    private int idx1;
    private int idx2;

    // Start is called before the first frame update
    void Start()
    {
        counter1 = jumlahItem;
        counter2 = jumlahItem;
        StartCoroutine(SpawnCountdown(1));
        StartCoroutine(SpawnCountdown(2));

    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCountdown(int idx)
    {
        yield return new WaitForSeconds(5);
       

        if(idx == 1)
        {
            if (counter1 > 0)
            {
                int rand = Random.Range(0, spawnPoint.Count);
                counter1 -= 1;
                Debug.Log("AAA1");
                GameObject objecta = Instantiate(itemPrefabs, spawnPoint[rand].position, Quaternion.identity, this.gameObject.transform);
                objecta.name =  "Tank1";
                objecta.GetComponent<ItemPick>().index = idx;
                idx1 = rand;

            }
        }

        if (idx == 2)
        {
            if(counter2 > 0)
            {
                int rand = Random.Range(0, spawnPoint.Count);
                counter2 -= 1;
                Debug.Log("AAA2");
                GameObject objectb = Instantiate(itemPrefabs, spawnPoint[rand].position, Quaternion.identity, this.gameObject.transform);
                objectb.name = "Tank2";
                objectb.GetComponent<ItemPick>().index = idx;
                idx2 = rand;
            }
        }
    }

    public void SpawnItem(int idx)
    {
        StartCoroutine(SpawnCountdown(idx));
    }
}
