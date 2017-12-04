using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCollider : MonoBehaviour {

    public BoxCollider2D player;
    public Animation myAnimator;

    public bool slide; 

	// Use this for initialization
	void Start () {

        player = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.S) || Input.GetMouseButtonUp(1))                                          //Lft Crtl will be the key for slide
        {
            player.enabled = !player.enabled;
        }

    }
}
