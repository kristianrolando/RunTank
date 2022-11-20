using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject pause;
    
    [SerializeField]
    private GameObject mainMenu;
    
    [SerializeField]
    private GameObject colorSelect;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }


    public void MainMenuButton()
    {
        pause.SetActive(false);
        mainMenu.SetActive(true);
        colorSelect.SetActive(false);
    }

    public void PlayButton()
    {
        pause.SetActive(false);
        mainMenu.SetActive(false);
        colorSelect.SetActive(true);
    }

    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }
}
