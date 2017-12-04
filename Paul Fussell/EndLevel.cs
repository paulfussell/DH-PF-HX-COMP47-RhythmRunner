using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {


    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform respawnPoint;

    private ScoreManager theScoreManager;

    // Use this for initialization
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            theScoreManager.scoreIncreasing = false;
            //player.transform.position = respawnPoint.transform.position;
            yield return new WaitForSeconds(.01f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            int x = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(x);

            theScoreManager.scoreCount = 0;
            theScoreManager.scoreIncreasing = true;
        }
    }
}
