using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerControls thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMove; 


    /*private Rigidbody2D myRigidBody;        //Creating a variable for the RigidBody2D function
    public int moveSpeed;*/

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerControls>();
        lastPlayerPosition = thePlayer.transform.position;

        //myRigidBody = GetComponent<Rigidbody2D>();      //Calls onto the RigidBody function
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;

        //myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);      //X = -1 >Move negative on the x axis and y = 0 > Y cant move up or down
    }
}
