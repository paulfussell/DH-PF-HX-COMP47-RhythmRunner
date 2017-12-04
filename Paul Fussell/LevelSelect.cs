using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public string level_1;
    public string level_2;
    public string level_3;
    public string level_4;
    public string level_5;
    public string level_6;
    public string goBACK;

    public void startlevel_1()
    {
        SceneManager.LoadScene(level_1);
        
    }

    public void startlevel_2()
    {
        SceneManager.LoadScene(level_2);
    }

    public void startlevel_3()
    {
        SceneManager.LoadScene(level_3);
    }

    public void goBACKTOMENU()
    {
        SceneManager.LoadScene(goBACK);
    }



}
