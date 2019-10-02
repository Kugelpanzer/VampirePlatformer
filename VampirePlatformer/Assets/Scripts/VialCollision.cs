using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialCollision : MonoBehaviour
{

    private ScoreCounter scoreCounter;
    public GameObject scoreText;
    public int VialScore = 200;
    AudioMenager audioObj;
    // Start is called before the first frame update
    void Start()
    {
        audioObj = GameObject.Find("SoundController").GetComponent<AudioMenager>();
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
            audioObj.PlaySound("Boca");
            Destroy(gameObject);
            scoreCounter.Score += VialScore;
        }


    }
}
