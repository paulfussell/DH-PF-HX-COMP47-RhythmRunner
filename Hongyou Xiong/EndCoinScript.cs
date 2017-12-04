using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCoinScript : MonoBehaviour
{
    public LevelScript level;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene("LevelSelector");
    }
}