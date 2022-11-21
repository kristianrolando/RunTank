using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private List<PlayerMaterial> player1Mat;
    [SerializeField]
    private List<PlayerMaterial> player2Mat;

    [SerializeField]
    private TankMovement player1obj;

    [SerializeField]
    private TankMovement player2obj;

    // Start is called before the first frame update
    void Start()
    {
        SetController();
        ChangeMaterialColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeMaterialColor()
    {
        if(ColourData.instance != null)
        {
            player1obj.SetMaterial(player1Mat[ColourData.instance.p1Colour].bodyMat);
            player2obj.SetMaterial(player2Mat[ColourData.instance.p2Colour].bodyMat);
        }
        
    }

    private void SetController()
    {
        player1obj.SetController(Keydata._keydata.inputList[0]);

        player2obj.SetController(Keydata._keydata.inputList[1]);
    }
}
