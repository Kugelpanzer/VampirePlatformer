using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float glideTime=0.5f;
    private float currGlideTime;


    private float moveInput;

    private bool facingRight = true;
    private Vector2 move;
    private Rigidbody2D rb;

    private bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Vector2 pos2d;
    private float currGravityScale;

    public float jumpReload=0.3f;
    private float currJumpReload;

    private float prevVelocityY;
    private bool glideFlag;
    private bool flyFlag;

    private Vector2 vLeft,vRight,vUp,vDown;
    private Vector3 moveVector;

    public GameObject test;
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
        rb = GetComponent<Rigidbody2D>();
        currGravityScale = rb.gravityScale;
        currGlideTime = glideTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos2d = transform.position;
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);



        if (!flyFlag)
        {
            //JUMPING
            if (currJumpReload <= 0)
            {
                if (Input.GetButton("Jump") && grounded)
                {
                    rb.velocity += Vector2.up * jumpForce * Time.deltaTime;
                    Debug.Log("skok");
                    currJumpReload = jumpReload;
                }
            }
            else
            {
                currJumpReload -= Time.deltaTime;
            }


            //MOVING 
            if (grounded)
            {
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
            else if (!grounded && rb.velocity.y >= -0.1 && rb.velocity.y <= 0.1 && currJumpReload > 0 && !glideFlag)
            {
                glideFlag = true;
                /* Instantiate(test);
                 test.transform.position = transform.position;*/
            }
            else if (glideFlag)
            {
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
            moveInput = Input.GetAxis("Horizontal") * speed;
        }




        //sets prevVelocityY
        prevVelocityY = rb.velocity.y;
    }




    private void DeathTrigger()
    {
    }

}
