using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeStart = 0;
    public Text countdownText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("AddTime");
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("" + timeStart);
    }

    IEnumerator AddTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            timeStart++;
        }
    }
}