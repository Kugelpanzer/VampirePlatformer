﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentVariant : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float glideTime=0.5f;
    private float currGlideTime;


    private float moveInput;
    private float prevMoveInput;

    private bool facingRight = true;
    private Vector2 move;
    private Rigidbody2D rb;

    private bool grounded;
    public Transform groundCheck;
    public float yOffset;
    public LayerMask whatIsGround;

    private Vector2 pos2d;
    private float currGravityScale;

    [Tooltip("jump reloads after player hits ground")]
    public float jumpReload=0.3f;
    private float currJumpReload;

    private float prevVelocityY;
    private bool glideFlag;
    private bool flyFlag;
    private bool wasGrounded;

    private Vector2 vLeft,vRight,vUp,vDown;
    private Vector3 moveVector;
    private Animator anim;
    public GameObject test;
    public BoxCollider2D playerCollider;
    private float collX, collY;
    void Flip() // flips crharacter sprite 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        currGravityScale = rb.gravityScale;
        currGlideTime = glideTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos2d = transform.position;
        collX = playerCollider.size.x * transform.localScale.x;
        collY = playerCollider.size.y * transform.localScale.y;
        //grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - (collX / 2), transform.position.y - (collY / 2)), new Vector2(transform.position.x + (collX / 2), transform.position.y - (collY / 2) - yOffset), whatIsGround);

        //grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);



        if (!flyFlag)
        {
            rb.gravityScale = currGravityScale;
            //JUMPING
            if (currJumpReload <= 0)
            {
                if (Input.GetButtonDown("Jump") && grounded)
                {
                    rb.velocity += Vector2.up * jumpForce * Time.deltaTime;
                    Debug.Log("skok");
                    currJumpReload = jumpReload;
                }
            }
            else if(grounded)
            {
                currJumpReload -= Time.deltaTime;
            }


            //MOVING 
            if (grounded)
            {
                wasGrounded = true;
                moveInput = Input.GetAxis("Horizontal") * speed;
                prevMoveInput = moveInput;
                if (Input.GetAxis("Horizontal") > 0)
                {

                    //rb.MovePosition(transform.position + new Vector3(speed, 0, 0) * Time.deltaTime);
                    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    // rb.MovePosition(transform.position + new Vector3(-speed, 0, 0) * Time.deltaTime);
                    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                }
            }
            else if (!grounded && rb.velocity.y >= -0.1 && rb.velocity.y <= 0.1 && currJumpReload > 0 && !glideFlag && wasGrounded)
            {
                wasGrounded = false;
                glideFlag = true;
                /* Instantiate(test);
                 test.transform.position = transform.position;*/
                Debug.Log("zum");
            }
            if (!wasGrounded)
            {
                if (Input.GetButton("Jump"))
                {
                    flyFlag = true;
                }
            }
            else if (glideFlag)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(moveInput * speed, 0);
                //Debug.Log("zum");

                if(Input.GetButton("Jump"))
                {
                    flyFlag = true;
                }
                //Change to bat 

                if (currGlideTime <= 0)
                {
                    glideFlag = false;
                    currGlideTime = glideTime;
                }
                else
                {
                    currGlideTime -= Time.deltaTime;
                }
            }
            if (!grounded)
            {
                //Debug.Log(rb.velocity.y);
            }
            


            if (facingRight == false && moveInput < 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput > 0)
            {
                Flip();
            }
        }
        else
        {
            vLeft = Vector2.zero;
            vRight = Vector2.zero;
            vUp = Vector2.zero;
            vDown = Vector2.zero;
            if (Input.GetAxis("Horizontal")<0)   
                vRight = -Vector2.right;

            if (Input.GetAxis("Vertical") > 0)
                vUp = Vector2.up;

            if (Input.GetAxis("Horizontal") > 0)
                vLeft = Vector2.right;

            if (Input.GetAxis("Vertical")< 0)
                vUp = -Vector2.up;

            if(!Input.GetButton("Jump"))
            {
                flyFlag = false;
            }

            moveVector = (vLeft + vRight + vUp + vDown).normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + moveVector);
            if (Input.GetAxis("Horizontal") != 0)
            { moveInput = Input.GetAxis("Horizontal") * speed; }
            else
            {
                moveInput = prevMoveInput;
            }
        }

        if(glideFlag || flyFlag)
        {
            anim.SetBool("Bat", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            anim.SetBool("Bat", false);
            transform.localScale = new Vector3(3, 3, 3);
        }


        //sets prevVelocityY
        prevVelocityY = rb.velocity.y;
    }




    private void DeathTrigger()
    {
    }

}