using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Tooltip("Vertical speed.")]
    public float speedY = 0;
    [Tooltip("Horizontal speed.")]
    public float speedX = 0;

    [Tooltip("How many steps to the left the platform can move. Do not set to 0.")]
    public float constraintLeft = 1;
    [Tooltip("How many steps to the right the platform can move. Do not set to 0.")]
    public float constraintRight = 1;
    [Tooltip("How many steps upwards the platform can move. Do not set to 0.")]
    public float constraintUp = 1;
    [Tooltip("How many steps downwards the platform can move. Do not set to 0.")]
    public float constraintDown = 1;

    float stepsHorizontal = 0;
    float stepsVertical = 0;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.Translate(Vector2.right * Time.deltaTime * speedX);
        // transform.Translate(Vector2.up * Time.deltaTime * speedY);
        rb.MovePosition(transform.position + Vector3.right * Time.deltaTime * speedX+ Vector3.up * Time.deltaTime * speedY);
        //Moving left
        if (speedX < 0)
        {
            stepsHorizontal+= speedX;
            if (-stepsHorizontal >= constraintLeft)
            {
                speedX = -speedX;
            }

        }
        //Moving right
        else if (speedX > 0)
        {
            stepsHorizontal += speedX;
            if (stepsHorizontal >= constraintRight)
            {
                speedX = -speedX;
            }
        }

        //Moving down
        if (speedY < 0)
        {
            stepsVertical += speedY;
            if (-stepsVertical >= constraintDown)
            {
                speedY = -speedY;
            }

        }
        //Moving up
        else if (speedY > 0)
        {
            stepsVertical += speedY;
            if (stepsVertical >= constraintUp)
            {
                speedY = -speedY;
            }
        }

    }
}
