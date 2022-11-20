using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourData : MonoBehaviour
{
    public static ColourData instance;

    public int p1Colour;
    public int p2Colour;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
