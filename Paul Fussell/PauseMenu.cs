using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;
    public GameObject pauseMenuCanvas;

	void Update () {
        paused();
	}

    public void paused()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            AudioListener.pause = false;

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }
    public void Resume()
    {
        isPaused = !isPaused;
    }
    public void mainMenu()
    {
        Application.LoadLevel("Main Menu");
    }
    public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void quit()
    {
        Application.Quit();
    }

}
