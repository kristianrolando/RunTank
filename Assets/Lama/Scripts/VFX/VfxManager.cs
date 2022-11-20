using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VfxManager : MonoBehaviour
{
    public static VfxManager Instance;

    [SerializeField]
    private Vfx[] visualEffect;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void PlayVfx(string name, Vector3 posSpawn)
    {
        Vfx v = Array.Find(visualEffect, vfx => vfx.name == name);
        if(v != null)
            v.CreateObject(posSpawn).transform.SetParent(this.transform);
    }

}
[Serializable]
public class Vfx
{
    public string name;
    public VfxObject visualPref;
    PoolingSystem pool = new PoolingSystem();
    public GameObject CreateObject(Vector3 pos)
    {
        return pool.CreateObject(visualPref, pos).gameObject;
    }
}
