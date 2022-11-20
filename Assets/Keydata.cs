using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keydata : MonoBehaviour
{
    public List<ControllerStruct> inputList;

    public static Keydata _keydata;


    private bool isNotFirstOpened;

    private void Awake()
    {
        if (_keydata == null)
        {
            _keydata = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        CheckFIrst();
        LoadKey();
    }
    public void SetInput()
    {
        for (int i = 0; i < 2; i++)
        {
            var json = PlayerPrefs.GetString("Control" + i.ToString(), "{}");
            inputList[i] = JsonUtility.FromJson<ControllerStruct>(json);
        }
    }

    private void LoadKey()
    {

        for (int i = 0; i < 2; i++)
        {
            var json = PlayerPrefs.GetString("Control" + i.ToString(), "{}");
            inputList[i] = JsonUtility.FromJson<ControllerStruct>(json);
        }

        SetInput();
    }

    private void FirstOpen()
    {
        isNotFirstOpened = true;
        PlayerPrefs.SetInt("firstKey", 1);

        Debug.Log("its FIrst");
        SaveKey();
    }

    private void CheckFIrst()
    {

        int a = PlayerPrefs.GetInt("firstKey");

        if (a != 0)
        {
            isNotFirstOpened = true;
            LoadKey();
            Debug.Log("its Not FIrst");
        }

        if (!isNotFirstOpened)
        {
            FirstOpen();
        }
    }

    private void SaveKey()
    {
        for (int i = 0; i < 2; i++)
        {
            SaveKeyToDB(new ControllerStruct(inputList[i]._forward, inputList[i]._backward, inputList[i]._left, inputList[i]._right, inputList[i]._fire), i);
        }
    }

    public void SaveKeyToDB(ControllerStruct keys, int idx)
    {
        var json = JsonUtility.ToJson(keys);
        PlayerPrefs.SetString("Control" + idx.ToString(), json);
        Debug.Log(json);

    }
}
