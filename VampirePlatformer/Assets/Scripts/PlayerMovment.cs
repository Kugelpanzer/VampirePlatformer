using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    public float batSpeed;
    public float jumpForce;
    public float glideTime = 0.5f;
    private float currGlideTime;


    private float moveInput;

    private bool facingRight = true;
    private Vector2 move;
    private Rigidbody2D rb;

    public bool grounded;
    private bool headHit;

    [Tooltip("yoffset is height of ground check")]
    public float yOffset = 0.1f, xOffset = 0.1f;
    public LayerMask whatIsGround;

    private Vector2 pos2d;
    private float currGravityScale;

    [Tooltip("jump reloads after player hits ground")]
    public float jumpReload = 0.3f;
    private float currJumpReload;

    private float prevVelocityY;
    public bool glideFlag;
    public bool flyFlag;
    private bool wasGrounded;
    private bool hasJump = true;
    //public bool sideFlag, bottomFlag;


    private GameObject controller;
    private Vector2 vLeft, vRight, vUp, vDown;
    private Vector3 moveVector;
    private Animator anim;
    //   public GameObject test;
    public BoxCollider2D playerCollider;
    private float collY, collX;
    private float startCollX, startCollY;


    // public float testCol=0.2f,currCol;

    public bool getFlyFlag() {
        return flyFlag;
    }


    void Flip() // flips crharacter sprite 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        xOffset = -xOffset;
    }
    void FlipInput()
    {
        if (facingRight == false && moveInput < 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();



        startCollX = playerCollider.size.x;
        startCollY = playerCollider.size.y;
        currGravityScale = rb.gravityScale;
        currGlideTime = glideTime;


        collX = playerCollider.size.x * transform.localScale.x + xOffset;
        collY = playerCollider.size.y * transform.localScale.y;



    }

    private void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            hasJump = true;
        }
    }
    void FixedUpdate()
    {
        pos2d = transform.position;



        //grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - (collX / 2), transform.position.y - (collY / 2)), new Vector2(transform.position.x + (collX / 2), transform.position.y - (collY / 2) - yOffset), whatIsGround);




        /*sideFlag= Physics2D.OverlapArea(new Vector2(transform.position.x - ((collX+xOffset) / 2), transform.position.y +((collY - yOffset) / 2)), new Vector2(transform.position.x + ((collX+xOffset) / 2), transform.position.y - ((collY-yOffset) / 2) ), whatIsGround);
        if(!sideFlag && bottomFlag)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }*/
        //headHit= Physics2D.OverlapArea(new Vector2(transform.position.x - (collX / 2), transform.position.y + (collY / 2)), new Vector2(transform.position.x + (collX / 2), transform.position.y + (collY / 2) + yOffset), whatIsGround);


        //Debug.DrawLine(new Vector2(transform.position.x +(ePoints[2].x+xOffset ), transform.position.y + (ePoints[2].y )), new Vector2(transform.position.x + (ePoints[3].x - xOffset), transform.position.y + (ePoints[3].y ) - yOffset),Color.red);

        // Debug.DrawLine(new Vector2(transform.position.x - ((collX + xOffset) / 2), transform.position.y + ((collY - yOffset) / 2)), new Vector2(transform.position.x + ((collX + xOffset) / 2), transform.position.y - ((collY - yOffset) / 2)));
        //Debug.DrawLine(new Vector2(transform.position.x - (collX / 3), transform.position.y + (collY / 2)) , new Vector2(transform.position.x + (collX / 3), transform.position.y + (collY / 2) + yOffset) );



        if (!flyFlag)
        {
            rb.gravityScale = currGravityScale;
            //JUMPING
            if (currJumpReload <= 0)
            {
                if (Input.GetButton/*Down*/("Jump") && grounded && hasJump)
                {
                    rb.gravityScale = currGravityScale;
                    rb.velocity += Vector2.up * jumpForce * Time.deltaTime;
                    currJumpReload = jumpReload;
                    hasJump = false;
                }
            }

            else if (grounded)
            {
                currJumpReload -= Time.deltaTime;
            }


            //MOVING 
            if (grounded)
            {
                rb.gravityScale = currGravityScale * 10;
                wasGrounded = true;
                moveInput = Input.GetAxis("Horizontal") * speed;
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
            }
            else if (glideFlag)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(moveInput * speed, 0);
                //Debug.Log("zum");

                if (Input.GetButton("Jump"))
                {
                    flyFlag = true;
                }
                //Change to bat 
                /*if (grounded)
                {
                    glideFlag = false;
                    currGlideTime = glideTime;
                }*/
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
                // Debug.Log(rb.velocity.y);
            }



            FlipInput();
        }
        else
        {

            vLeft = Vector2.zero;
            vRight = Vector2.zero;
            vUp = Vector2.zero;
            vDown = Vector2.zero;
            if (Input.GetAxis("Horizontal") < 0)
                vRight = -Vector2.right;

            if (Input.GetAxis("Vertical") > 0)
                vUp = Vector2.up;

            if (Input.GetAxis("Horizontal") > 0)
                vLeft = Vector2.right;

            if (Input.GetAxis("Vertical") < 0)
                vUp = -Vector2.up;

            if (!Input.GetButton("Jump") || controller.GetComponent<ScoreCounter>().Score <= 0/* || grounded*/)
            {
                glideFlag = false;
                flyFlag = false;
            }

            moveVector = (vLeft + vRight + vUp + vDown).normalized * batSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + moveVector);
            moveInput = Input.GetAxis("Horizontal") * speed;
            rb.velocity = new Vector2(moveInput * speed, 0);
            FlipInput();
        }


        #region animation


        if ((glideFlag || rb.velocity.y > 0) && !grounded && !flyFlag)
        {
            VampJump();
            //SetBat();
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else if (flyFlag /*&& !grounded*/)
        {
            SetFlyBat();
        }
        else
        {
            if (grounded && Input.GetAxis("Horizontal") != 0)
            {
                if (anim.GetInteger("State")!=4)
                {
                    SetVampRun();
                }
            }
            else if (grounded)
            {
                Debug.Log("stajanje ");
                SetVamp();
            }
            

        }


        //sets prevVelocityY
        prevVelocityY = rb.velocity.y;
    }

    private void SetBat()
    {
        anim.SetInteger("State", 2);
        playerCollider.size = new Vector2(playerCollider.size.x, startCollY / 2);


        playerCollider.offset = new Vector2(0, 0.1475f);

    }
    private void SetFlyBat()
    {
        anim.SetInteger("State", 3);
        playerCollider.size = new Vector2(playerCollider.size.x, startCollY / 2);


        playerCollider.offset = new Vector2(0, 0.1475f);

    }
    private void SetFall()
    {
        anim.SetInteger("State", 5);
    }
    private void SetVamp()
    {
        anim.SetInteger("State", 0);
        playerCollider.size = new Vector2(playerCollider.size.x, startCollY);

        playerCollider.offset = new Vector2(0, 0);
    }

    private void SetVampRun()
    {
        anim.SetInteger("State", 4);

        playerCollider.size = new Vector2(playerCollider.size.x, startCollY);

        playerCollider.offset = new Vector2(0, 0);
    }
    private void VampJump()
    {
        anim.SetInteger("State", 1);
        playerCollider.size = new Vector2(playerCollider.size.x, startCollY);

        playerCollider.offset = new Vector2(0, 0);
    }
    public void EndJump()
    {
        Debug.Log("skok");
        SetBat();
    }

    #endregion
    /* void OnCollisionEnter2D(Collision2D col)
     {
         if (col.gameObject.layer == 8)
         {
             if(glideFlag || flyFlag)
             {
                 glideFlag = false;
                 flyFlag = false;
             }
         }

     }*/


    private void DeathTrigger()
    {
        
        controller.GetComponent<LevelController>().ResetLevel();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            DeathTrigger();
        }
    }

//mala promena 

}
