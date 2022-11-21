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

    [SerializeField]
    private List<Material> bulletMat;

    private int idx1;
    private int idx2;

    private int mat1;
    private int mat2;

    public bool havMis1;
    public bool havMis2;

    public GameObject canva1;
    public GameObject canva2;

    public GameObject canvamat1;
    public GameObject canvamat2;


    // Start is called before the first frame update
    void Start()
    {
        counter1 = jumlahItem;
        counter2 = jumlahItem;
        mat1 = 1;
        mat2 = 2;
        canva1.SetActive(false); 
        canva2.SetActive(false);
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
        if(counter1 + counter2 == 0)
        {
            GameManager.instance.Win();
        }
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

                int randmat = Random.Range(0, 3);
                for (int i = 0; i < 100; i++)
                {
                    if(randmat != mat2)
                    {
                        break;
                    }
                    randmat = Random.Range(0, 3);
                }
                objecta.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = bulletMat[randmat];
                canvamat1.GetComponent<MeshRenderer>().material = bulletMat[randmat];
                mat1 = randmat;


                objecta.name =  "Tank1";
                objecta.GetComponent<ItemPick>().index = idx;
                idx1 = rand;
                canva1.SetActive(true);
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

                int randmat = Random.Range(0, 3);
                for (int i = 0; i < 100; i++)
                {
                    if (randmat != mat1)
                    {
                        break;
                    }
                    randmat = Random.Range(0, 3);
                }
                objectb.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = bulletMat[randmat];
                canvamat2.GetComponent<MeshRenderer>().material = bulletMat[randmat];
                mat2 = randmat;

                objectb.name = "Tank2";
                objectb.GetComponent<ItemPick>().index = idx;
                idx2 = rand;
                canva2.SetActive(true);
            }
        }
    }

    public void SpawnItem(int idx)
    {
        StartCoroutine(SpawnCountdown(idx));
    }

    public void HideItem(int idx)
    {
        if(idx == 1)
        {
            canva1.SetActive(false);
        }

        if (idx == 2)
        {
            canva2.SetActive(false);
        }
    }
}
