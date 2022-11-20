using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSelect : MonoBehaviour
{
    [SerializeField]
    private List<PlayerMaterial> player1Mat;
    [SerializeField]
    private List<PlayerMaterial> player2Mat;


    [SerializeField]
    private GameObject P1;
    [SerializeField]
    private GameObject P2;
    [SerializeField]
    private GameObject P1a;
    [SerializeField]
    private GameObject P2a;

    [SerializeField]
    private int curP1;

    [SerializeField]
    private int curP2;
    // Start is called before the first frame update
    void Start()
    {
        changeColorP1();
        changeColorP2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchP1(int idx)
    {
        if(curP1 >= 0 && curP1 <= 3)
        {
            curP1 += idx;

            if(curP1 < 0)
            {
                curP1 = 3;
            }

            if (curP1 > 3)
            {
                curP1 = 0;
            }
        }

        changeColorP1();
    }
    public void switchP2(int idx)
    {
        if (curP2 >= 0 && curP2 <= 3)
        {
            curP2 += idx;

            if (curP2 < 0)
            {
                curP2 = 3;
            }

            if (curP2 > 3)
            {
                curP2 = 0;
            }
        }
        changeColorP2();
    }

    private void changeColorP1()
    {
        MeshRenderer render = P1.GetComponent<MeshRenderer>();
        render.material = player1Mat[curP1].bodyMat;
        MeshRenderer rendera = P1a.GetComponent<MeshRenderer>();
        rendera.material = player1Mat[curP1].bodyMat;

        ColourData.instance.p1Colour = curP1;
    }

    private void changeColorP2()
    {
        MeshRenderer render = P2.GetComponent<MeshRenderer>();
        render.material = player2Mat[curP2].bodyMat;
        MeshRenderer rendera = P2a.GetComponent<MeshRenderer>();
        rendera.material = player2Mat[curP2].bodyMat;


        ColourData.instance.p2Colour = curP2;
    }
}
