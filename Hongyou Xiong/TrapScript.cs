using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapScript : MonoBehaviour
{

    [SerializeField]
    private LevelScript level;
    public float respawntime;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            level.mScoreManager.scoreIncreasing = false;
            yield return new WaitForSeconds(respawntime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            level.mScoreManager.scoreCount = 0;
            level.mScoreManager.scoreIncreasing = true;
            level.mCoinsCollected = 0;
        }
    }
}