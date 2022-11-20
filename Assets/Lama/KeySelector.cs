using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class KeySelector : MonoBehaviour
{
    [SerializeField]
    private Text textA;
    [SerializeField]
    private Button buttonA;

    [SerializeField]
    private int pIndex;
    [SerializeField]
    private int keyIndex;

    [SerializeField]
    private List<InputButtonStruct> btnList;

    [SerializeField]
    private List<ControllerStruct> inputList;

    private bool isNotFirstOpened;

    private bool isSelect;
    void OnGUI()
    {
        if (isSelect)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                Debug.Log("Detected key code: " + e.keyCode);
                textA.text = e.keyCode.ToString();


                //change 1
                if(keyIndex == 1)
                {
                    KeyCode keycode = e.keyCode;
                    var kcode = inputList[pIndex];
                    kcode._forward = keycode;
                    inputList[pIndex] = kcode;
                }
                //change 2
                if(keyIndex == 2)
                {
                    KeyCode keycode = e.keyCode;
                    var kcode = inputList[pIndex];
                    kcode._backward = keycode;
                    inputList[pIndex] = kcode;
                }
                //change 3
                if(keyIndex == 3)
                {
                    KeyCode keycode = e.keyCode;
                    var kcode = inputList[pIndex];
                    kcode._left = keycode;
                    inputList[pIndex] = kcode;
                }
                //change 1
                if(keyIndex == 4)
                {
                    KeyCode keycode = e.keyCode;
                    var kcode = inputList[pIndex];
                    kcode._right = keycode;
                    inputList[pIndex] = kcode;
                }
                //change 1
                if(keyIndex == 5)
                {
                    KeyCode keycode = e.keyCode;
                    var kcode = inputList[pIndex];
                    kcode._fire = keycode;
                    inputList[pIndex] = kcode;
                }




                SaveKey();
                isSelect = false;
            }
        }
    }

    private void Awake()
    {
        SetupFirst();
        
        CreateButton();
    }

    private void CreateButton()
    {
        for (int i = 0; i < 2; i++)
        {
            Button up = btnList[i]._forward;

            int idx = i;
            
            up.onClick.AddListener(delegate
            {
                ClickedButton(up, up.transform.GetChild(0).GetComponent<Text>(), idx, 1);
            });

            Button down = btnList[i]._backward;
            down.onClick.AddListener(delegate
            {
                ClickedButton(down, down.transform.GetChild(0).GetComponent<Text>(), idx, 2);
            });


            Button left = btnList[i]._left;
            left.onClick.AddListener(delegate
            {
                ClickedButton(left, left.transform.GetChild(0).GetComponent<Text>(), idx, 3);
            });


            Button right = btnList[i]._right;
            right.onClick.AddListener(delegate
            {
                ClickedButton(right, right.transform.GetChild(0).GetComponent<Text>(), idx, 4);
            });


            Button fire = btnList[i]._fire;
            fire.onClick.AddListener(delegate
            {
                ClickedButton(fire, fire.transform.GetChild(0).GetComponent<Text>(), idx, 5);
            });


        }
    }


    private void ClickedButton(Button btn, Text txt, int idx, int kindex)
    {
        buttonA = btn;
        textA = txt;
        pIndex = idx;
        keyIndex = kindex;
        isSelect = true;
        Debug.Log("buttonss");
    }

    private void SetupFirst()
    {
        int a = PlayerPrefs.GetInt("firstKey");

        if(a != 0)
        {
            isNotFirstOpened = true;
            LoadKey();
            Debug.Log("its Not FIrst");
        }

        if (!isNotFirstOpened)
        {
            FirstOpen();
        }

        SetText();
    }

    private void FirstOpen()
    {
        isNotFirstOpened = true;
        PlayerPrefs.SetInt("firstKey", 1);

        Debug.Log("its FIrst");

        inputList[0] = Keydata._keydata.inputList[0];
        inputList[1] = Keydata._keydata.inputList[1];

        SaveKey();
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
        PlayerPrefs.SetString("Control"+ idx.ToString(), json);
        Debug.Log(json);




        Keydata._keydata.SetInput();

    }

    private void SetText()
    {
        for (int i = 0; i < 2; i++)
        {
            btnList[i]._forward.transform.GetChild(0).GetComponent<Text>().text = inputList[i]._forward.ToString();
            btnList[i]._backward.transform.GetChild(0).GetComponent<Text>().text = inputList[i]._backward.ToString();
            btnList[i]._left.transform.GetChild(0).GetComponent<Text>().text = inputList[i]._left.ToString();
            btnList[i]._right.transform.GetChild(0).GetComponent<Text>().text = inputList[i]._right.ToString();
            btnList[i]._fire.transform.GetChild(0).GetComponent<Text>().text = inputList[i]._fire.ToString();
        }
    }

    private void LoadKey()
    {

        for (int i = 0; i < 2; i++)
        {
            var json = PlayerPrefs.GetString("Control" + i.ToString(), "{}");
            inputList[i] = JsonUtility.FromJson<ControllerStruct>(json);
        }

        Keydata._keydata.SetInput();
    }
}
