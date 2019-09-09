using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    float moveHorizontal = Input.GetAxis("Horizontal");
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayerMove()
    {

        /*if(Input. GetButton("Horizontal"))
        {
           
        }*/
        /*if (Input.GetAxis("Horizontal")>0)
        {
            Debug.Log("kretanje");
        }
        */
        rb.MovePosition(transform.position+new Vector3(Input.GetAxis("Horizontal"),0) * Time.deltaTime);


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
}
