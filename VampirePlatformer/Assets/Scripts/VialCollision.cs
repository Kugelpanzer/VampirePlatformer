using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialCollision : MonoBehaviour
{

    private ScoreCounter scoreCounter;
    public GameObject scoreText;
    public int VialScore = 200;
    // Start is called before the first frame update
    void Start()
    {

        scoreCounter = GameObject.Find("Controller").GetComponent<ScoreCounter>(); //scoreText.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            scoreCounter.Score += VialScore;
        }


    }
}
