using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public string playGameLevel;
    public string gotoSettings;
    public string levelSelector;
    public string helpmenu;

    // Quit Game
    public void QuitGame() {
        Application.Quit();	
	}

    public void Continue() {
        SceneManager.LoadScene(levelSelector);
    }

    public void Settings()
    {
        SceneManager.LoadScene(gotoSettings);
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause; 
    }
    public void Help()
    {
        SceneManager.LoadScene(helpmenu);
    }
}
