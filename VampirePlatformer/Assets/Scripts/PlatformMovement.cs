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
    public int constraintLeft = 1;
    [Tooltip("How many steps to the right the platform can move. Do not set to 0.")]
    public int constraintRight = 1;
    [Tooltip("How many steps upwards the platform can move. Do not set to 0.")]
    public int constraintUp = 1;
    [Tooltip("How many steps downwards the platform can move. Do not set to 0.")]
    public int constraintDown = 1;

    int stepsHorizontal = 0;
    int stepsVertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speedX);
        transform.Translate(Vector2.up * Time.deltaTime * speedY);

        //Moving left
        if (speedX < 0)
        {
            stepsHorizontal++;
            if (stepsHorizontal == constraintLeft)
            {
                speedX = -speedX;
            }

        }
        //Moving right
        else if (speedX > 0)
        {
            stepsHorizontal--;
            if (-stepsHorizontal == constraintRight)
            {
                speedX = -speedX;
            }
        }

        //Moving down
        if (speedY < 0)
        {
            stepsVertical++;
            if (stepsVertical == constraintDown)
            {
                speedY = -speedY;
            }

        }
        //Moving up
        else if (speedY > 0)
        {
            stepsVertical--;
            if (-stepsVertical == constraintUp)
            {
                speedY = -speedY;
            }
        }

    }
}
