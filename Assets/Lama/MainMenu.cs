using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string selectedMap;


    [SerializeField]
    private GameObject pause;
    
    [SerializeField]
    private GameObject mainMenu;
    
    [SerializeField]
    private GameObject colorSelect;

    [SerializeField]
    private GameObject mapSelect;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionButton()
    {
        pause.SetActive(true);
        mainMenu.SetActive(false);
        colorSelect.SetActive(false);
        mapSelect.SetActive(false);
    }


    public void MainMenuButton()
    {
        pause.SetActive(false);
        mainMenu.SetActive(true);
        colorSelect.SetActive(false);
        mapSelect.SetActive(false);
    }

    public void PlayButton()
    {
        mapSelect.SetActive(true);
        pause.SetActive(false);
        mainMenu.SetActive(false);
        colorSelect.SetActive(false);
    }

    public void ColorSelect()
    {
        mapSelect.SetActive(false);
        pause.SetActive(false);
        mainMenu.SetActive(false);
        colorSelect.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(selectedMap);
    }

    public void SelectMap(string mapname)
    {
        selectedMap = mapname;
        ColorSelect();
    }
}
