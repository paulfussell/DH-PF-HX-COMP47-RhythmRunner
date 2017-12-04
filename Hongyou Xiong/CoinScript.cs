using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public LevelScript level;
    private AudioSource coinSound;
    public int scoreToGive;

    private void Start()
    {
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        level.mScoreManager.scoreCount += scoreToGive;
        level.mCoinsCollected += 1;
        Destroy(gameObject);

        if (coinSound.isPlaying)
        {
            coinSound.Stop();
            coinSound.Play();
        }
        else
        {
            coinSound.Play();
        }
    }
}
