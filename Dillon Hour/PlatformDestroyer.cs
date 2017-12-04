using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platformDestructionPoint;         //will determine when the platforms are behind the player 


    // Use this for initialization
    void Start()
    {

        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        //Find any object that has the name platformdestruction point

    }

    // Update is called once per frame
    void Update()
    {

        //if the platform is behind the player then it will be destroyed 
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject); 

            //gameObject.SetActive(false);        //deactivates the object if its not being used

        }
    }
}
