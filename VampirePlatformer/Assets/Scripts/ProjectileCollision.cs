using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public float speedX;
    AudioMenager audioObj;
    // Start is called before the first frame update
    void Start()
    {
            audioObj = GameObject.Find("SoundController").GetComponent<AudioMenager>();
            speedX = GetComponent<Rigidbody2D>().velocity.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Rigidbody2D projectyleRB = GetComponent<Rigidbody2D>();
        
        if (col.gameObject.tag == "Player")
        {
            audioObj.PlaySound("Hit");
            GameObject player = col.gameObject;
            PlayerMovment PlayerObject = player.GetComponent<PlayerMovment>();
            if (speedX > 0)
            {
                PlayerObject.pushX += 50;
            }
            else
            {
                PlayerObject.pushX -= 50;
            }
                

        }
        Destroy(gameObject);
    }

}
