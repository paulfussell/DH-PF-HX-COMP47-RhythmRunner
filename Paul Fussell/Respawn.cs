using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform respawnPoint;

    private ScoreManager theScoreManager;

    public float respawntime;

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
          
            yield return new WaitForSeconds(respawntime);

            //SceneManager.LoadScene("Dillon");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            theScoreManager.scoreCount = 0;
            theScoreManager.scoreIncreasing = true; 
        }
    }
}
