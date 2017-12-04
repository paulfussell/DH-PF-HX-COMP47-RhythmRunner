using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private Rigidbody2D myRigidBody;                                                        //Creating a variable for the RigidBody2D function
    private Animator myAnimator;                                                            //making the Amination function be called myAnimation

    private bool facingRight;                                                               //creating a variable for player view
    //private bool slide;                                                                     //Sliding variable 
    private bool isGrounded;    
    private bool jump;

    public float speedMultiplier;

    public float speedIncreaseMileStone;
    private float speedMilestoneCount;

    [SerializeField]                                                                        //Makes it accessible to the user only
    private float movementSpeed;                                                            //Setting the Movement Speed

    [SerializeField]                                                                        //Makes it accessible to the user only
    private float originalMoveSpeed;

    [SerializeField]
    private Transform[] groundPoints;                                                       //setting ground points for player

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private float jumpForce; 

    [SerializeField]
    private LayerMask whatIsGround;                                                         //Tells the player what is a ground

    [SerializeField]
    private bool airControl;                                                                //makes sure player doesnt jump and run at the same time

    void Start()
    {
        facingRight = true;                                                                 //Player will be always be facing right
        myRigidBody = GetComponent<Rigidbody2D>();                                          //Calls onto the RigidBody function
        myAnimator = GetComponent<Animator>();                                              //Calls onto the animation function

        speedMilestoneCount = speedIncreaseMileStone;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");                                     //Looks at the input and moves horizontally

            isGrounded = IsGrounded();
            HandleMovement(horizontal);
            HandleLayers();
            ResetValues();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        movementSpeed = originalMoveSpeed * speedMultiplier;
    }

    private void HandleMovement(float horizontal)
    {
        if (!myAnimator.GetBool("slide") && (isGrounded || airControl))                     //Get the current animation and if its not attack then you can move the player
        {
            myRigidBody.velocity = new Vector2(movementSpeed, myRigidBody.velocity.y);      //X = -1 >Move negative on the x axis and y = 0 > Y cant move up or down
        }

        if(myRigidBody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true);           
        }

        if(isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0,jumpForce));                                 //Will set the value of the Jump force
            myAnimator.SetTrigger("jump");
        }

        //if(slide && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("ninja_Slide"))   //making sure the player can slide
        //{
        //    myAnimator.SetBool("slide", true);
        //}

        //    else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("ninja_Slide"))
        //    {
        //        myAnimator.SetBool("slide", false);                    
        //    }

        myAnimator.SetFloat("speed", Mathf.Abs(movementSpeed));                             //Checks the speed for the animation
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)                //If he is facing right then
        {
            facingRight = !facingRight;                                                     //Make it false if true, and true if false

            Vector3 theScale = transform.localScale;                                        //transforming the player

            theScale.x *= -1;                                                               //Multiplies x position by -1
            transform.localScale = theScale;                                                //changes the x value after multiplying
        }
    }

    private void HandleInput()
    {
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetMouseButtonUp(1))                                          //Lft Crtl will be the key for slide
        //{
        //    slide = true;
        //}

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jump = true;
        }

    }
    private void ResetValues()                                                              //Reset the value keys once the play finishes clicking the button
    {
        //slide = false;
        jump = false;
    }

    private bool IsGrounded()
    {
        if (myRigidBody.velocity.y <= 0)                                                    //If less than 0 then were falling down 
        { 
            foreach(Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for(int i = 0; i < colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("jump");                                    //reseting the jump position
                        myAnimator.SetBool("land", false);
                        return true; 
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);                                                //Activating the layer to the air layer
        }
            else
            {
                myAnimator.SetLayerWeight(1, 0);                                            //Deactivating the air layer back to the ground layer
            }
    }
}
