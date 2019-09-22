using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialCollision : MonoBehaviour
{

    private ScoreCounter scoreCounter;
    public GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = scoreText.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            scoreCounter.Score += 200;
        }


    }
}
