using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {
    /// <summary>
    /// Generate a very long platform so that I can generate coins to match.
    /// </summary>
    /// <param name="x">Middle of the platform x position</param>
    /// <param name="heightType">LOW, MIDDLE, HIGH are the three options. Uses LOW for long platform</param>
    /// <param name="length">How long the platform will be</param>
    public void CreateNewPlatform(float x, PLATFORM_HEIGHT heightType, int length)
    {
        float y = GetHeight(heightType);

        const int startWiggle = 5; // How many pixels behind the player we would want to start.

        GameObject platform = new GameObject();
        platform.name = "Super Long Platform";
        platform.layer = 8; // Ground Layer
        platform.transform.position = new Vector3(x - startWiggle + (length / 2), y, 0);

        BoxCollider2D boxCol = platform.AddComponent<BoxCollider2D>();
        boxCol.size = new Vector2(length, 1);

        GameObject pStart = new GameObject();
        pStart.transform.SetParent(platform.transform);
        pStart.transform.localPosition = new Vector3(-length / 2, 0, 0);
        SpriteRenderer pStartSprite = pStart.AddComponent<SpriteRenderer>();
        pStartSprite.sprite = Resources.Load<Sprite>("Floors/Night/Dark Curved Left");

        for (int i = 1; i < length; i++)
        {
            GameObject pMiddle = new GameObject();
            pMiddle.transform.SetParent(platform.transform);
            pMiddle.transform.localPosition = new Vector3((length / 2) - i, 0, 0);
            SpriteRenderer pMiddleSprite = pMiddle.AddComponent<SpriteRenderer>();
            pMiddleSprite.sprite = Resources.Load<Sprite>("Floors/Night/Dark Curved Filler");
        }

        GameObject pEnd = new GameObject();
        pEnd.transform.SetParent(platform.transform);
        pEnd.transform.localPosition = new Vector3(length / 2, 0, 0);
        SpriteRenderer pEndSprite = pEnd.AddComponent<SpriteRenderer>();
        pEndSprite.sprite = Resources.Load<Sprite>("Floors/Night/Dark Curved Right");
    }

    private float GetHeight(PLATFORM_HEIGHT height)
    {
        switch (height)
        {
            default:
            case PLATFORM_HEIGHT.LOW:
                return -2;
            case PLATFORM_HEIGHT.MIDDLE:
                return 0;
            case PLATFORM_HEIGHT.HIGH:
                return 2;
        }
    }

    public enum PLATFORM_HEIGHT
    {
        LOW,
        MIDDLE,
        HIGH
    }

    // Use this for initialization
    public void Start () {
        mCoinTimers = new ArrayList();

        mAudioSource.clip = mAudioClip;
        mAudioSource.Play();

        /*
         * UNCOMMENT LINE BELOW TO GENERATE DEBUG PLATFORM.
         * CreateNewPlatform(mPlayer.transform.position.x, PLATFORM_HEIGHT.LOW, 5 * 90);
         */
    }

    public void Update()
    {
        /*
         * UNCOMMENT LINE BELOW TO GENERATE MARKERS ON WHERE COINS SHOULD GO.
         * Pause right before end of platform so that you can record the positions
         * of all the coin markers.
         * DebugMarkBeat();
         */
        
        //Coins needed to speed up pitch and movespeed by .04 is 20 coins.
        float speedMultiplierIncrease = .04f * (int)(mCoinsCollected / 20);
        PlayerControls playerControls = mPlayer.GetComponent<PlayerControls>();
        playerControls.speedMultiplier = 1 + speedMultiplierIncrease;
        mAudioSource.pitch = 1 + speedMultiplierIncrease;
    }

    public AudioClip mAudioClip;
    public AudioSource mAudioSource;
    public GameObject mPlayer;
    public ScoreManager mScoreManager; // Going to use score to speed up the audio.
    public GameObject debugText;
    public float mCoinsCollected;

    /// <summary>
    /// This function was used to generate markers where I should put coins
    /// The coins were generated whenever a note was below a D3 on the piano
    /// IN terms of frequency, that would be below 147 hertz
    /// </summary>
    private void DebugMarkBeat()
    {
        float currentFrequency = GetPitchForThisWindow(mAudioSource);
        if (currentFrequency < 146.832 && mNextSpawnTime <= 0) // Lower than a D3
        {
            GameObject marker = new GameObject();
            marker.transform.position = new Vector3(mPlayer.transform.position.x + 1, 5, 0);
            SpriteRenderer pMiddleSprite = marker.AddComponent<SpriteRenderer>();
            pMiddleSprite.sprite = Resources.Load<Sprite>("Floors/Night/Dark Curved Filler");

            mNextSpawnTime = .2f; //Every 1 unit of distance.
            mCoinTimers.Add(mPlayer.transform.position.x);
        }

        mNextSpawnTime -= Time.deltaTime;

        Text textObj = debugText.GetComponent<Text>();
        textObj.text = currentFrequency.ToString();

        if (Time.time > 90.0f)
        {
            //Break here
            Debug.Break();
            textObj.text = "BROKEN HERE";
        }
    }

    // Uses DFFT to convert audio source into frequency of sound.
    private float GetPitchForThisWindow(AudioSource audio)
    {
        float fundamentalFrequency = 0.0f;
        float[] spectrum = new float[1024];
        audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float maxSpectrum = 0.0f;
        int maxIndex = 0;

        for (int i = 1; i < 1024; i++)
        {
            if (maxSpectrum < spectrum[i])
            {
                maxSpectrum = spectrum[i];
                maxIndex = i;
            }
        }

        fundamentalFrequency = maxIndex * AudioSettings.outputSampleRate / 1024;

        return fundamentalFrequency;
    }

    private float mNextSpawnTime = 2;
    private ArrayList mCoinTimers;
}
