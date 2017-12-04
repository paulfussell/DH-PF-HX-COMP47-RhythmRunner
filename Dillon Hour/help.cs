using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class help : MonoBehaviour {

    public string mainmenu;
    public string page2;
    public string page1;

    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }

    public void pageOne()
    {
        SceneManager.LoadScene(page1);
    }

    public void pageTwo()
    {
        SceneManager.LoadScene(page2);
    }

    public void mainMenuScreen()
    {
        SceneManager.LoadScene(mainmenu);
    }
}
